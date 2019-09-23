using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeckleCore;

namespace SpeckleTester
{
  class Program
  {
    static void Main( string[ ] args )
    {
      Console.WriteLine( "Hello Speckle Tester." );

      var test = LocalContext.GetTelemetrySettings();

      LocalContext.SetTelemetrySettings( false );

      var secondTest = LocalContext.GetTelemetrySettings();

      SpeckleTelemetry.Initialize();

      Console.WriteLine( "Your device id is: " );
      Console.WriteLine( SpeckleTelemetry.DeviceId );

      SpeckleTelemetry.RecordTestEvent( "console" );
      SpeckleTelemetry.RecordTestEvent( "console" );
      SpeckleTelemetry.RecordTestEvent( "console" );
      SpeckleTelemetry.RecordTestEvent( "console" );
      SpeckleTelemetry.RecordTestEvent( "brebit" );
      SpeckleTelemetry.RecordTestEvent( "brebit" );
      SpeckleTelemetry.RecordTestEvent( "brebit" );
      SpeckleTelemetry.RecordTestEvent( "brebit" );
      SpeckleTelemetry.RecordTestEvent( "fopper" );
      SpeckleTelemetry.RecordTestEvent( "fopper" );
      SpeckleTelemetry.RecordTestEvent( "fopper" );
      SpeckleTelemetry.RecordTestEvent( "grino" );
      SpeckleTelemetry.RecordTestEvent( "grino" );
      SpeckleTelemetry.RecordTestEvent( "grino" );
      SpeckleTelemetry.RecordTestEvent( "grino" );
      SpeckleTelemetry.RecordTestEvent( "grino" );
      SpeckleTelemetry.RecordTestEvent( "grino" );
      SpeckleTelemetry.RecordTestEvent( "prrrft" );

      Console.ReadLine();
    }
  }
}
