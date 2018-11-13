using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SpeckleCore
{
  /// <summary>
  /// A class for a generic speckle account, composed of all the identification props for a user & server combination. 
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

  /// <summary>
  /// Special class for efficiently storing sent objects. Why? We do not want to store them fully as they are already stored in the users's file. Kind of duplicates the CachedObject.
  /// </summary>
  public class SentObject
  {
    /// <summary>
    /// Represents the api this object came from
    /// </summary>
    [Indexed]
    public string RestApi { get; set; }

    [Indexed]
    public string DatabaseId { get; set; }

    [PrimaryKey, Indexed]
    public string Hash { get; set; }
  }

  /// <summary>
  /// A class for storing cached objects (that have been retrieved from a database).
  /// </summary>
  public class CachedObject
  {
    /// <summary>
    /// Represents hash(databaseId + restApi)
    /// </summary>
    [PrimaryKey, Indexed( Unique = true )]
    public string CombinedHash { get; set; }
    
    /// <summary>
    /// Represents the api this object came from
    /// </summary>
    [Indexed]
    public string RestApi { get; set; }

    [Indexed]
    public string DatabaseId { get; set; }

    [Indexed]
    public string Hash { get; set; }

    public DateTime AddedOn {get;set;}

    public byte[ ] Bytes { get; set; }

    /// <summary>
    /// Returns the speckle object from cache.
    /// </summary>
    /// <returns></returns>
    public SpeckleObject ToSpeckle( )
    {
      return SpeckleCore.Converter.getObjFromBytes( this.Bytes ) as SpeckleObject;
    }
  }

  public class CachedStream
  {
    /// <summary>
    /// Represents hash(streamId + restApi)
    /// </summary>
    [PrimaryKey, Indexed( Unique = true )]
    public string CombinedHash { get; set; }

    /// <summary>
    /// Represents the api this object came from
    /// </summary>
    [Indexed]
    public string RestApi { get; set; }

    [Indexed]
    public string StreamId { get; set; }

    public DateTime AddedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public byte[ ] Bytes { get; set; }

    public SpeckleStream ToSpeckle()
    {
      return SpeckleStream.FromJson( SpeckleCore.Converter.getObjFromBytes( this.Bytes ) as string ); // ((SpeckleCore.Converter.getObjFromBytes( this.Bytes ) as SpeckleStream;
    }
  }
}
