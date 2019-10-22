using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore.Data
{
  public class SpeckleException : Exception
  {
    public SpeckleException()
    {
    }

    public SpeckleException(string message)
        : base(message)
    {
    }

    public SpeckleException(string message, Exception inner)
        : base(message, inner)
    {
    }
  }

  public class RevitFamilyNotFoundException : SpeckleException
  {
    public RevitFamilyNotFoundException()
    {
    }

    public RevitFamilyNotFoundException(string message)
        : base(message)
    {
    }

    public RevitFamilyNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
  }
}



