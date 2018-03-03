using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
    public interface ISpeckleSerializable
    {
        SpeckleObject ToSpeckle();
    }
}
