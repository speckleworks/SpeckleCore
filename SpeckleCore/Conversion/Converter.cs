using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace SpeckleCore
{
  public abstract partial class Converter
  {
    public static Dictionary<string, MethodInfo> toSpeckleMethods = new Dictionary<string, MethodInfo>();

    public static Dictionary<string, MethodInfo> toNativeMethods = new Dictionary<string, MethodInfo>();
  }

}
