using Newtonsoft.Json;
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
        /// <summary>
        /// Generates a truncated (to 12) md5 hash of an object.
        /// </summary>
        /// <param name="fromWhat"></param>
        public string GetMd5FromObject(object fromWhat, int length = 0)
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

                    if (length != 0)
                        return sb.ToString().ToLower().Substring(0, length);
                    else
                        return sb.ToString().ToLower();
                }
            }
        }

        /// <summary>
        /// Generates and sets this object's full hash, generated from its GeometryHash + Properties.
        /// Does not apply to non-geometric types.
        /// </summary>
        public void SetFullHash()
        {
            this.Hash = GetMd5FromObject(this.GeometryHash + JsonConvert.SerializeObject(this.Properties));
        }

        public void SetGeometryHash(object fromWhat)
        {
            this.GeometryHash = this.Type + "." + GetMd5FromObject(fromWhat, 12);
        }

        public void SetHashes(object uniqueProperties)
        {
            SetGeometryHash(uniqueProperties);
            SetFullHash();
        }
    }

    public partial class SpeckleBoolean
    {
        public SpeckleBoolean() { }

        public SpeckleBoolean(bool value, Dictionary<string, object> properties = null)
        {
            this.Value = value;
            this.Properties = properties;

            SetHashes(this.Value);
        }
    }

    public partial class SpeckleNumber
    {
        public SpeckleNumber() { }

        public SpeckleNumber(double value, Dictionary<string, object> properties = null)
        {
            this.Value = value;
            this.Properties = properties;

            SetHashes(this.Value);
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

        public SpeckleString(string value, Dictionary<string, object> properties = null)
        {
            this.Value = value;
            this.Properties = properties;

            SetHashes(this.Value);
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

        public SpeckleInterval(double start, double end, Dictionary<string, object> properties = null)
        {
            this.Start = start;
            this.End = end;
            this.Properties = properties;

            SetHashes(start + "." + end);
        }
    }

    public partial class SpeckleInterval2d
    {
        public SpeckleInterval2d() { }

        public SpeckleInterval2d(SpeckleInterval U, SpeckleInterval V, Dictionary<string, object> properties = null)
        {
            this.U = U;
            this.V = V;
            this.Properties = properties;

            SetHashes(U.GeometryHash + V.GeometryHash);
        }

        public SpeckleInterval2d(double start_u, double end_u, double start_v, double end_v, Dictionary<string, object> properties = null)
        {
            this.U = new SpeckleInterval(start_u, end_u);
            this.V = new SpeckleInterval(start_v, end_v);
            this.Properties = properties;

            SetHashes(U.GeometryHash + V.GeometryHash);
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

            SetHashes(this.Value);
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

            SetHashes(this.Value);
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

            SetHashes(origin.GeometryHash + normal.GeometryHash + Xdir.GeometryHash + YDir.GeometryHash);
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

            SetHashes(Start.GeometryHash + End.GeometryHash);
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

            SetHashes(A.GeometryHash + B.GeometryHash + C.GeometryHash + D.GeometryHash);
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

            SetHashes(Center.GeometryHash + Normal.GeometryHash + Radius);
        }
    }

    public partial class SpeckleArc
    {
        public SpeckleArc() { }

        public SpeckleArc(SpecklePlane plane, double radius, double startAngle, double endAngle, double angleRadians, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Plane = plane;
            this.Radius = radius;
            this.StartAngle = startAngle;
            this.EndAngle = endAngle;
            this.AngleRadians = angleRadians;
            this.ApplicationId = applicationId;
            this.Properties = properties;

            SetHashes(plane.GeometryHash + radius + startAngle + endAngle);
        }
    }

    public partial class SpeckleEllipse
    {
        public SpeckleEllipse() { }

        public SpeckleEllipse(SpecklePlane plane, double radius1, double radius2, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Plane = plane;
            this.FirstRadius = radius1;
            this.SecondRadius = radius2;
            this.ApplicationId = applicationId;
            this.Properties = properties;

            SetHashes(Plane.GeometryHash + radius1 + radius2);
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

            SetHashes(BasePlane.GeometryHash + XSize.GeometryHash + YSize.GeometryHash + ZSize.GeometryHash);
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

            SetHashes(this.Value);
        }

        public SpecklePolyline(IEnumerable<double> coordinatesArray, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Value = coordinatesArray.ToArray();
            this.ApplicationId = applicationId;
            this.Properties = properties;

            SetHashes(this.Value);
        }
    }

    public partial class SpeckleCurve
    {
        public SpeckleCurve() { }

        public SpeckleCurve(SpecklePolyline poly, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.DisplayValue = poly;
            this.ApplicationId = applicationId;
            this.Properties = properties;

            SetHashes(this.DisplayValue.GeometryHash);
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

            SetHashes(JsonConvert.SerializeObject(Vertices) + JsonConvert.SerializeObject(Faces) + JsonConvert.SerializeObject(Colors));
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

            SetHashes(this.DisplayValue.GeometryHash);
        }
    }

    public partial class  SpeckleExtrusion
    {
        public SpeckleExtrusion() { }

        public SpeckleExtrusion(SpeckleCurve profile, double length, bool capped, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Profile = profile;
            this.Length = length;
            this.Capped = capped;
            this.ApplicationId = applicationId;
            this.Properties = properties;

            this.SetHashes(Profile.GeometryHash + "len " + length + "cap " + capped);
        }
    }

    [Serializable]
    public class SpeckleAnnotation : SpeckleObject
    {
        public override string Type { get; set; } = "Annotation";
        public string Text { get; set; }
        public double TextHeight { get; set; }
        public string FaceName { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public SpecklePlane Plane { get; set; }
        public SpecklePoint Location { get; set; }


        public SpeckleAnnotation() { }

        public SpeckleAnnotation(string text, double textHeight, string faceName, bool bold, bool italic, SpecklePlane plane, SpecklePoint location, string applicationId = null, Dictionary<string, object> properties = null)
        {
            this.Text = text;
            this.TextHeight = textHeight;
            this.FaceName = faceName;
            this.Bold = bold;
            this.Italic = italic;
            this.Plane = plane;
            this.Location = location;
            this.ApplicationId = applicationId;
            this.Properties = properties;

            SetHashes(this.Text + this.FaceName + this.Bold.ToString() + this.Italic.ToString() + this.Plane.GeometryHash + this.Location.GeometryHash);
        }
    }


    public partial class SpeckleLayer : IEquatable<SpeckleLayer>
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

        public static void DiffLayerLists(IEnumerable<SpeckleLayer> oldLayers, IEnumerable<SpeckleLayer> newLayers, ref List<SpeckleLayer> toRemove, ref List<SpeckleLayer> toAdd, ref List<SpeckleLayer> toUpdate)
        {
            toRemove = oldLayers.Except(newLayers, new SpeckleLayerComparer()).ToList();
            toAdd = newLayers.Except(oldLayers, new SpeckleLayerComparer()).ToList();
            toUpdate = newLayers.Intersect(oldLayers, new SpeckleLayerComparer()).ToList();
        }

        public bool Equals(SpeckleLayer other)
        {
            return this.Guid == other.Guid;
        }
    }

    internal class SpeckleLayerComparer : IEqualityComparer<SpeckleLayer>
    {
        public bool Equals(SpeckleLayer x, SpeckleLayer y)
        {
            return x.Guid == y.Guid;
        }

        public int GetHashCode(SpeckleLayer obj)
        {
            return obj.Guid.GetHashCode();
        }
    }

    public interface ISpeckleControllerParam
    {
    }

    [Serializable]
    public class SpeckleOutputParam : ISpeckleControllerParam
    {
        public string Name { get; set; }

        public int OrderIndex { get; set; }

        public bool IsPrincipal { get; set; } = false;

        public string Unit { get; set; }

        public string Value { get; set; }

        public string Guid { get; set; }

        public string Type { get; set; } = "Text";
    }

    [Serializable]
    public class SpeckleInputParam : ISpeckleControllerParam
    {
        public string Name { get; set; }

        public int OrderIndex { get; set; }

        public string Type { get; set; }

        public string Guid { get; set; }
    }

    [Serializable]
    public class SpeckleNumberInput : SpeckleInputParam
    {
        public string Name { get; set; }

        public double Min { get; set; } = 1;

        public double Max { get; set; } = -1;

        public double Step { get; set; } = 1 / 10e2;

        public double Value { get; set; } = 0;
    }

    [Serializable]
    public class SpeckleTextInput : SpeckleInputParam
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }

    [Serializable]
    public class SpeckleToggleInput : SpeckleInputParam
    {
        public string Name { get; set; }

        public bool Value { get; set; }
    }

    [Serializable]
    public class SpecklePointInput : SpeckleInputParam
    {
        public string Name { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double MaxX { get; set; }
        public double MaxY { get; set; }
        public double MaxZ { get; set; }
        public double MinX { get; set; }
        public double MinY { get; set; }
        public double MinZ { get; set; }
    }


}
