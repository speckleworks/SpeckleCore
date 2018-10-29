using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SpeckleCore
{

  public static partial class SpeckleLocalContext
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

      Database = new SQLiteConnection( DbPath );
      Database.CreateTable<Account>();
      Database.CreateTable<CachedObject>();

      MigrateAccounts();

      IsInit = true;
    }

    public static void Close( )
    {
      Database?.Close();
    }

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
        int k = 0;
        foreach ( string file in Directory.EnumerateFiles( SettingsFolderPath, "*.txt" ) )
          File.Move( file, SettingsFolderPath + @"\MigratedAccounts\old_account_" + k++ + ".txt" );
      }
      else
        Debug.WriteLine( "No existing account text files found." );
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
    /// <returns></returns>
    public static Account GetAccountByEmailAndRestApi( string email, string restApi )
    {
      var res = Database.Query<Account>( String.Format("SELECT * from Account WHERE RestApi = '{0}' AND Email='{1}'", restApi, email) );
      if ( res.Count >= 1 ) return res[ 0 ];
      else throw new Exception( "Could not find account." );
    }

    /// <summary>
    /// Returns the default account, if any. Otherwise throws an error.
    /// </summary>
    /// <returns></returns>
    public static Account GetDefaultAccount( )
    {
      var res = Database.Query<Account>( "SELECT * FROM Account WHERE IsDefault='true' LIMIT 1" );
      if ( res.Count == 1 ) return res[ 0 ];
      else throw new Exception( "No default account set." );
    }

    /// <summary>
    /// Sets an account as being the default one, and de-sets defaultness on all others. 
    /// </summary>
    /// <param name="account"></param>
    public static void SetDefaultAccount( Account account )
    {
      try
      {
        var currentDefault = GetDefaultAccount(); currentDefault.IsDefault = false;
        Database.Update( currentDefault );
      }
      catch ( Exception e )
      {

      }

      account.IsDefault = true;
      Database.Update( account );
    }

    #endregion

    #region Objects
    // TODO
    #endregion
  }



}
