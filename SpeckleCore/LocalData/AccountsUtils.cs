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

  public static class SpeckleLocalContext
  {
    public static SQLiteConnection Database;

    public static string DbPath = System.Environment.GetFolderPath( System.Environment.SpecialFolder.LocalApplicationData ) + @"\SpeckleSettings\SpeckleCache.db";

    public static string SettingsFolderPath = System.Environment.GetFolderPath( System.Environment.SpecialFolder.LocalApplicationData ) + @"\SpeckleSettings\";

    public static void Init( )
    {
      Database = new SQLiteConnection( DbPath );
      Database.CreateTable<Account>();
      Database.CreateTable<CachedObject>();
    }

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
      }
      else
        Debug.WriteLine( "No existing account text files found." );
    }

    public static void AddAccount( Account a )
    {
      var res = Database.Insert( a );
    }

    public static List<Account> GetAccountByRestApi( string RestApi )
    {
      return Database.Query<Account>( "SELECT * from Account WHERE RestApi = ?", RestApi );
    }

    public static Account GetDefaultAccount( )
    {
      var res = Database.Query<Account>( "SELECT * FROM Account WHERE IsDefault='true' LIMIT 1" );
      if ( res.Count == 1 ) return res[ 0 ];
      else throw new Exception( "No default account set." );
    }



  }

  /// <summary>
  /// An account is a speckle account
  /// </summary>
  public class Account
  {
    [PrimaryKey, AutoIncrement]
    public int AccountId { get; set; }
    public string ServerName { get; set; }
    [Indexed]
    public string RestApi { get; set; }
    [Indexed]
    public string Email { get; set; }
    public string Token { get; set; }
    public bool IsDefault { get; set; } = false;
  }

  public class CachedObject
  {
    [PrimaryKey, Indexed, Unique]
    public string Hash { get; set; }
    public string Json { get; set; }
  }

}
