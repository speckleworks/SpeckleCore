using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpeckleCore
{

  public class SpeckleLocalContext : DbContext
  {
    private static bool created = false;

    public DbSet<Account> Accounts { get; set; }

    public SpeckleLocalContext( )
    {

    }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
      //base.OnConfiguring( optionsBuilder );
      //optionsBuilder.UseSqlite( "Data Source=/*" + System.Environment.GetFolderPath( System.Environment.SpecialFolder.LocalApplicationData ) + @"\SpeckleSettings\SpeckleLocal.db" );*/

      optionsBuilder.UseSqlite( "Data Source=SpeckleLocal.db" );

    }

  }

  /// <summary>
  /// An account is a speckle account
  /// </summary>
  public class Account
  {
    public int AccountId { get; set; }
    public string ServerName { get; set; }
    public string RestApi { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public bool IsDefault { get; set; } = false;
  }
}
