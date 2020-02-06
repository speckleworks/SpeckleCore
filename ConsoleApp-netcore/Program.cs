using System;
using SpeckleCore;

namespace ConsoleApp_netcore
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      SpeckleCore.SpeckleInitializer.Initialize();
      var types = SpeckleCore.SpeckleInitializer.GetTypes();
      var test = types;
    }
  }
}
