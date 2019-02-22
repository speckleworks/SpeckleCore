using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
  class ModuleInitializer
  {
    public static void Initialize( )
    {
      var ass = new ConverterLoader().GetAssemblies();
      var assCopy = ass;
    }
  }
}
