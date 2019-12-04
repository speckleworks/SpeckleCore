using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore.Data
{
  public class SpeckleError
  {
    public string Message { get; set; }
    public string Details { get; set; }
  }
  public class SpeckleConversionError : SpeckleError
  {
    public object SourceObject { get; set; }
  }
}
