using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Extends the functionality of some DTO classes to be more accesible.
/// So wow. Much partial.
/// </summary>

namespace SpeckleCore
{
    public partial class SpeckleObject
    {
        public string GenerateHash(string type, object fromWhat)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter().Serialize(ms, fromWhat);

                byte[] hash;
                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    hash = md5.ComputeHash(ms.ToArray());
                    StringBuilder sb = new StringBuilder();
                    foreach (byte bbb in hash)
                        sb.Append(bbb.ToString("X2"));

                    return type + "." + sb.ToString().ToLower().Substring(0, 16);
                }
            }
        }
    }

    public partial class SpeckleBoolean
    {
        public SpeckleBoolean() { }

        public SpeckleBoolean(bool value)
        {
            this.Value = value;
        }
    }

    public partial class SpeckleNumber
    {
        public SpeckleNumber() { }

        public SpeckleNumber(double value)
        {
            this.Value = value;
            this.Type = "Number";
        }

        public static implicit operator double? (SpeckleNumber n)
        {
            return n.Value;
        }

        public static implicit operator SpeckleNumber(double n)
        {
            return new SpeckleNumber(n);
        }
    }

    public partial class SpeckleString
    {
        public SpeckleString() { }

        public SpeckleString(string value)
        {
            this.Value = value;
        }

        public static implicit operator string(SpeckleString s)
        {
            return s.Value;
        }

        public static implicit operator SpeckleString(string s)
        {
            return new SpeckleString(s);
        }
    }

    public partial class SpeckleInterval
    {
        public SpeckleInterval() { }

        public SpeckleInterval(double start, double end)
        {
            this.Start = start;
            this.End = end;
        }
    }

    public partial class SpeckleInterval2d
    {
        public SpeckleInterval2d() { }

        public SpeckleInterval2d(SpeckleInterval U, SpeckleInterval V)
        {
            this.U = U;
            this.V = V;
        }

        public SpeckleInterval2d(double start_u, double end_u, double start_v, double end_v)
        {
            this.U = new SpeckleInterval(start_u, end_u);
            this.V = new SpeckleInterval(start_v, end_v);
        }
    }

    public partial class SpecklePoint
    {
        public SpecklePoint() { }

        public SpecklePoint(double x, double y, double z = 0, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Value = new double[] { x, y, z };
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, this.Value);
        }

        public static implicit operator double[] (SpecklePoint p)
        {
            return p.Value;
        }

        public static implicit operator SpeckleVector(SpecklePoint p)
        {
            return new SpeckleVector(p.Value[0], p.Value[1], p.Value[2], null, p.Properties);
        }
    }

    public partial class SpeckleVector
    {
        public SpeckleVector() { }

        public SpeckleVector(double x, double y, double z = 0, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Value = new double[] { x, y, z };
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, this.Value);
        }

        public static implicit operator double[] (SpeckleVector p)
        {
            return p.Value;
        }

        public static implicit operator SpecklePoint(SpeckleVector p)
        {
            return new SpecklePoint(p.Value[0], p.Value[1], p.Value[2], null, p.Properties);
        }
    }

    public partial class SpecklePlane
    {
        public SpecklePlane() { }

        public SpecklePlane(SpecklePoint origin, SpeckleVector normal, SpeckleVector XDir, SpeckleVector YDir, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Origin = origin;
            this.Normal = normal;
            this.Xdir = XDir;
            this.Ydir = YDir;
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, origin.GeometryHash + normal.GeometryHash + XDir.GeometryHash + YDir.GeometryHash);
        }
    }

    public partial class SpeckleLine
    {
        public SpeckleLine() { }

        public SpeckleLine(SpecklePoint start, SpecklePoint end, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Start = start;
            this.End = end;
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, start.GeometryHash + end.GeometryHash);
        }
    }

    public partial class SpeckleRectangle
    {
        public SpeckleRectangle() { }

        public SpeckleRectangle(SpecklePoint A, SpecklePoint B, SpecklePoint C, SpecklePoint D, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, A.GeometryHash + B.GeometryHash + C.GeometryHash + D.GeometryHash);
        }
    }

    public partial class SpeckleCircle
    {
        public SpeckleCircle() { }

        public SpeckleCircle(SpecklePoint center, SpeckleVector normal, double radius, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Center = center;
            this.Normal = normal;
            this.Radius = radius;
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, center.GeometryHash + normal.GeometryHash + radius);
        }
    }

    public partial class SpeckleBox
    {
        public SpeckleBox() { }

        public SpeckleBox(SpecklePlane basePlane, SpeckleInterval xSize, SpeckleInterval ySize, SpeckleInterval zSize, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.BasePlane = basePlane;
            this.XSize = xSize;
            this.YSize = ySize;
            this.ZSize = zSize;
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, basePlane.GeometryHash + XSize.ToJson() + YSize.ToJson() + zSize.ToJson());
        }
    }

    public partial class SpecklePolyline
    {
        public SpecklePolyline() { }

        public SpecklePolyline(IEnumerable<SpecklePoint> pointArray, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Value = pointArray.SelectMany(item => (double[])item).ToArray();
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, this.Value);
        }

        public SpecklePolyline(IEnumerable<double> coordinatesArray, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Value = coordinatesArray.ToArray();
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, this.Value);
        }
    }

    public partial class SpeckleCurve
    {
        public SpeckleCurve() { }

        public SpeckleCurve(string base64, string provenance, SpecklePolyline poly, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Base64 = base64;
            this.Provenance = provenance;
            this.DisplayValue = poly;
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, this.DisplayValue);
        }
    }

    public partial class SpeckleMesh
    {
        public SpeckleMesh() { }

        public SpeckleMesh(double[] vertices, int[] faces, int[] colors, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Vertices = vertices;
            this.Faces = faces;
            this.Colors = colors;
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, this);
        }
    }

    public partial class SpeckleBrep
    {
        public SpeckleBrep() { }

        public SpeckleBrep(string base64, string provenance, SpeckleMesh displayValue, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Base64 = base64;
            this.Provenance = provenance;
            this.DisplayValue = displayValue;
            this.ApplicationId = applicationId;
            this.Properties = properties;
            this.GeometryHash = this.GenerateHash(this.Type, this.DisplayValue);
        }
    }

    public partial class SpeckleLayer
    {
        public SpeckleLayer() { }

        public SpeckleLayer(string name, string guid, string topology, int objectCount, int startIndex, int orderIndex)
        {
            this.Name = name;
            this.Guid = guid;
            this.Topology = topology;
            this.StartIndex = startIndex;
            this.ObjectCount = objectCount;
            this.OrderIndex = orderIndex;
        }
    }
}
