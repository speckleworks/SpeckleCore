using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SQLite;

namespace SpeckleCore
{
  /// <summary>
  /// <para>This class holds the keys to the local sqlite database that acts as a local cache for various speckle things.</para>
  /// <para>You can access accounts from here across speckle integrations, as well as the local object cache.</para>
  /// <para>The cache holds the following tables: Accounts, CachedObjects, SentObjects, CachedStreams.</para>
  /// <para>Cached objects are objects that a receiver requested. They are stored fully (with a binary blob of their speckle representation). SentObjects are objects that have been previously sent by a sender and are stored without their speckle representation (they're just refs) as a log against which to diff what to send or not.</para>
  /// </summary>
  public static partial class LocalContext
  {
    private static bool IsInit = false;

    private static SQLiteConnection Database;

    public static string DbPath = System.Environment.GetFolderPath( System.Environment.SpecialFolder.LocalApplicationData ) + @"\SpeckleSettings\SpeckleCache.db";

    public static string SettingsFolderPath = System.Environment.GetFolderPath( System.Environment.SpecialFolder.LocalApplicationData ) + @"\SpeckleSettings\";

    /// <summary>
    /// Initialises the database context, ensures tables are created and powers up the rocket engines.
    /// </summary>
    public static void Init( )
    {
      if ( IsInit ) return;

      if ( !Directory.Exists( SettingsFolderPath ) )
        Directory.CreateDirectory( SettingsFolderPath );

      Database = new SQLiteConnection( DbPath );
      Database.CreateTable<Account>();
      Database.CreateTable<CachedObject>();
      Database.CreateTable<SentObject>();
      Database.CreateTable<CachedStream>();

      MigrateAccounts();

      IsInit = true;
    }

    public static void Close( )
    {
      Database?.Close();
    }

    #region Cleanup & Table Purging
    /// <summary>
    /// Purges the sent objects table. WARNING: Don't do this unless you know what you're doing.
    /// </summary>
    public static void PurgeSentObjects( )
    {
      Database?.Execute( "DELETE FROM SentObject" );
    }

    /// <summary>
    /// Purges the received objects table. WARNING: Don't do this unless you know what you're doing.
    /// </summary>
    public static void PurgeCachedObjects( )
    {
      Database?.Execute( "DELETE FROM CachedObject" );
    }

    /// <summary>
    /// Purges the accounts. WARNING: Don't do this unless you know what you're doing.
    /// </summary>
    public static void PurgeAccounts( )
    {
      Database?.Execute( "DELETE FROM Account" );
    }

    /// <summary>
    /// Purges the streams table. WARNING: Don't do this unless you know what you're doing.
    /// </summary>
    public static void PurgeCachedStreams( )
    {
      Database?.Execute( "DELETE FROM CachedStream" );
    }

    #endregion

    #region Accounts
    /// <summary>
    /// Migrates existing accounts stored in text files to the sqlite db.
    /// </summary>
    private static void MigrateAccounts( )
    {
      List<Account> accounts = new List<Account>();

      if ( Directory.Exists( SettingsFolderPath ) && Directory.EnumerateFiles( SettingsFolderPath, "*.txt" ).Count() > 0 )
      {
        foreach ( string file in Directory.EnumerateFiles( SettingsFolderPath, "*.txt" ) )
        {
          string content = File.ReadAllText( file );
          string[ ] pieces = content.TrimEnd( '\r', '\n' ).Split( ',' );

          accounts.Add( new Account() { Email = pieces[ 0 ], Token = pieces[ 1 ], ServerName = pieces[ 2 ], RestApi = pieces[ 3 ] } );
        }

        var res = Database.InsertAll( accounts );

        Directory.CreateDirectory( SettingsFolderPath + @"\MigratedAccounts\" );

        foreach ( string file in Directory.EnumerateFiles( SettingsFolderPath, "*.txt" ) )
        {
          try
          {
            var newName = Path.Combine( SettingsFolderPath, "MigratedAccounts", Path.GetFileName( file ) );
            if ( File.Exists( newName ) )
            {
              File.Delete( newName );
            }

            File.Move( file, newName );
          }
          catch ( Exception e )
          {
            Debug.WriteLine( "yolo" );
          }
        }

      }
      else
      {
        Debug.WriteLine( "No existing account text files found." );
      }
    }

    /// <summary>
    /// Adds a new account.
    /// </summary>
    /// <param name="account"></param>
    public static void AddAccount( Account account )
    {
      var res = Database.Insert( account );
    }

    /// <summary>
    /// Gets all accounts present.
    /// </summary>
    /// <returns></returns>
    public static List<Account> GetAllAccounts( )
    {
      return Database.Query<Account>( "SELECT * FROM Account" );
    }

    /// <summary>
    /// Gets all the accounts associated with the  provided rest api.
    /// </summary>
    /// <param name="RestApi"></param>
    /// <returns></returns>
    public static List<Account> GetAccountsByRestApi( string RestApi )
    {
      return Database.Query<Account>( "SELECT * from Account WHERE RestApi = ?", RestApi );
    }

    /// <summary>
    /// Gets all the accounts associated with the  provided email.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static List<Account> GetAccountsByEmail( string email )
    {
      return Database.Query<Account>( "SELECT * from Account WHERE Email = ?", email );
    }

    /// <summary>
    /// If more accounts present, will return the first one only.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="restApi"></param>
    /// <returns>null if no account is found.</returns>
    public static Account GetAccountByEmailAndRestApi( string email, string restApi )
    {
      var res = Database.Query<Account>( String.Format( "SELECT * from Account WHERE RestApi = '{0}' AND Email='{1}'", restApi, email ) );
      if ( res.Count >= 1 )
      {
        return res[ 0 ];
      }
      else
      {
        return null;
        //throw new Exception("Could not find account.");
      }
    }

    /// <summary>
    /// Returns the default account, if any. Otherwise throws an error.
    /// </summary>
    /// <returns></returns>
    public static Account GetDefaultAccount( )
    {
      var res = Database.Query<Account>( "SELECT * FROM Account WHERE IsDefault='true' LIMIT 1" );
      if ( res.Count == 1 )
      {
        return res[ 0 ];
      }
      else
      {
        throw new Exception( "No default account set." );
      }
    }

    /// <summary>
    /// Sets an account as being the default one, and de-sets defaultness on all others. 
    /// </summary>
    /// <param name="account"></param>
    public static void SetDefaultAccount( Account account )
    {

      Database.Execute( "UPDATE Account SET IsDefault=0" );

      account.IsDefault = true;
      Database.Update( account );
    }

    public static void RemoveAccount( Account ac )
    {
      Database.Delete<Account>( ac.AccountId );
    }

    #endregion

    #region Received Objects (CachedObject)

    /// <summary>
    /// Adds a speckle object to the local cache.
    /// </summary>
    /// <param name="obj">The object to add.</param>
    /// <param name="restApi">The server url of where it has been persisted.</param>
    public static void AddCachedObject( SpeckleObject obj, string restApi )
    {
      var bytes = SpeckleCore.Converter.getBytes( obj );
      var combinedHash = Converter.getMd5Hash( obj._id + restApi );
      var cached = new CachedObject()
      {
        RestApi = restApi,
        Bytes = bytes,
        DatabaseId = obj._id,
        CombinedHash = combinedHash,
        Hash = obj.Hash,
        AddedOn = DateTime.Now
      };

      try
      {
        Database.Insert( cached );
      }
      catch
      {
        // object was already there
      }
    }

    /// <summary>
    /// Does a cache check on a list of speckle object placeholders. It will populate the original list with any objects it can find in the cache. If none are found, the list is returned unmodified.
    /// </summary>
    /// <param name="objs">Speckle object placeholders to check against the cache.</param>
    /// <param name="restApi">The rest api these objects are expected to come from.</param>
    /// <returns></returns>
    public static List<SpeckleObject> GetCachedObjects( List<SpeckleObject> objs, string restApi )
    {
      var combinedHashes = objs.Select( obj => Converter.getMd5Hash( obj._id + restApi ) ).ToList();
      var res = Database.Table<CachedObject>().Where( obj => combinedHashes.Contains( obj.CombinedHash ) ).Select( o => o.ToSpeckle() ).ToList();

      // populate the original list with whatever objects we found in the database.
      for ( int i = 0; i < objs.Count; i++ )
      {
        var placeholder = objs[ i ];
        var myObject = res.Find( o => o._id == placeholder._id );
        if ( myObject != null )
        {
          objs[ i ] = myObject;
        }
      }

      return objs;
    }

    #endregion

    #region Sent Objects (SentObject)

    /// <summary>
    /// Adds an object that has been sent by a sender in the local cache.
    /// This does not store the full object, it's just a log that it has been sent
    /// to a server so it does not get sent again.
    /// </summary>
    /// <param name="obj">Object to store as sent ref in the local database.</param>
    /// <param name="restApi">The server's url.</param>
    public static void AddSentObject( SpeckleObject obj, string restApi )
    {
      var sentObj = new SentObject()
      {
        RestApi = restApi,
        DatabaseId = obj._id,
        Hash = obj.Hash
      };

      try
      {
        Database.Insert( sentObj );
      }
      catch
      {
        // object was already there, no panic!
      }
    }

    /// <summary>
    /// Replaces any objects in the given list with placeholders if they're found in the local cache, as this means they were sent before and most probably exist on the server.
    /// </summary>
    /// <param name="objs"></param>
    /// <param name="restApi"></param>
    /// <returns>(Optinoal) The modified list.</returns>
    public static List<SpeckleObject> PruneExistingObjects( List<SpeckleObject> objs, string restApi )
    {
      // MAX SQL Vars is 900
      var MaxSqlVars = 900;

      var objHashes = objs.Select( obj => true ? obj.Hash : restApi ).ToList();

      var partitionedList = new List<List<string>>();

      for ( int i = 0; i < objHashes.Count; i += MaxSqlVars )
      {
        partitionedList.Add( objHashes.GetRange( i, Math.Min( MaxSqlVars, objHashes.Count - i ) ) );
      }

      var fullRes = new List<SentObject>();

      foreach ( var subList in partitionedList )
      {
        var res = Database.Table<SentObject>().Where( obj => subList.Contains( obj.Hash ) && obj.RestApi == restApi ).ToList();
        fullRes.AddRange( res );
      }

      for ( int i = 0; i < objs.Count; i++ )
      {
        var placeholder = objs[ i ];
        var myObject = fullRes.Find( o => o.Hash == objs[ i ].Hash );
        if ( myObject != null )
        {
          objs[ i ] = new SpecklePlaceholder() { _id = myObject.DatabaseId };
        }
      }

      return objs;
    }

    #endregion

    #region Streams (CachedStream)

    /// <summary>
    /// Updates or inserts a stream in the local cache.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="restApi"></param>
    public static void AddOrUpdateStream( SpeckleStream stream, string restApi )
    {
      var bytes = SpeckleCore.Converter.getBytes( stream.ToJson() );
      var combinedHash = Converter.getMd5Hash( stream._id + restApi );

      var cacheRes = Database.Table<CachedStream>().Where( existing => existing.CombinedHash == combinedHash ).ToList();

      if ( cacheRes.Count >= 1 )
      {
        var toUpdate = cacheRes[ 0 ];
        toUpdate.Bytes = bytes;
        toUpdate.UpdatedOn = DateTime.Now;
        Database.Update( toUpdate );
      }
      else
      {
        var toCache = new CachedStream()
        {
          CombinedHash = combinedHash,
          Bytes = bytes,
          RestApi = restApi,
          StreamId = stream.StreamId,
          AddedOn = DateTime.Now,
          UpdatedOn = DateTime.Now
        };
        Database.Insert( toCache );
      }
      //throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a stream from the local cache.
    /// </summary>
    /// <param name="streamId"></param>
    /// <param name="restApi"></param>
    /// <returns>Null, if nothing found, or the speckle stream.</returns>
    public static SpeckleStream GetStream( string streamId, string restApi )
    {
      var combinedHash = Converter.getMd5Hash( streamId + restApi );
      var res = Database.Table<CachedStream>().Where( str => str.CombinedHash == combinedHash ).ToArray();
      if ( res.Length > 0 )
      {
        return res[ 0 ].ToSpeckle();
      }

      return null;
    }

    #endregion
  }



}
