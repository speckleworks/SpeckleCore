using NUnit.Framework;
using SpeckleCore;

namespace SpeckleTests
{
  public class GenericTests
  {
    [SetUp]
    public void Setup()
    {
      System.IO.Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\SpeckleKits\");
      SpeckleCore.SpeckleInitializer.Initialize();
    }

    [Test]
    public void LoadingKits()
    {
      var kits = SpeckleCore.SpeckleInitializer.GetAssemblies();
      var types = SpeckleCore.SpeckleInitializer.GetTypes();

      Assert.GreaterOrEqual(types.Count, 1);
      Assert.GreaterOrEqual(kits.Count, 1);
    }
  }
}