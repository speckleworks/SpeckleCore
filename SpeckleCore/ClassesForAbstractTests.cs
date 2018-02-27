using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
	public enum Subtype { TypeA, TypeB, TypeC, TypeD, Other };

	public class BaseObjectGroup
	{
		public List<BaseObject> Objects;

		public BaseObjectGroup()
		{
			Objects = new List<BaseObject>();
		}
	}

	[Serializable]
	public class BaseObject
	{
		public int PublicIntField = 4;

		[NonSerialized]
		public int PublicNonSerialised = 12;

		public Subtype PublicEnum = Subtype.Other;

		public Dictionary<string, object> CustomStringObjectDictionary { get; set; }

		public Dictionary<int, object> CustomIntObjectDictionary { get; private set; }

		public List<object> CustomList { get; set; }

		public HashSet<string> Tags;

		public Guid Guid { get; set; }

		public BaseObject()
		{
			CustomStringObjectDictionary = new Dictionary<string, object>();
			CustomList = new List<object>();
			Tags = new HashSet<string>();
			Guid = Guid.NewGuid();
		}
	}

	[Serializable]
	public class ExtendedObject : BaseObject
	{
		[NonSerialized]
		public string ModelName = "Default Car";

		public double what = 23;

		public MySuperStruct Struct;

		public ExtendedObject()
		{
			Struct = new MySuperStruct() { X = 12, Y = 12 };
		}
	}

	[Serializable]
	public struct MySuperStruct
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public double A { get; private set; }
		public string S;
	}
}
