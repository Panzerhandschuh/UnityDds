using System.IO;
using UnityDds.Utilities;

namespace UnityDds
{
	public class DdsPixelFormat
	{
		public uint size;
		public uint flags;
		public string fourCC;
		public uint RGBBitCount;
		public uint RBitMask;
		public uint GBitMask;
		public uint BBitMask;
		public uint ABitMask;

		public static DdsPixelFormat Deserialize(BinaryReader reader)
		{
			var format = new DdsPixelFormat();

			format.size = reader.ReadUInt32();
			format.flags = reader.ReadUInt32();
			format.fourCC = reader.ReadString(4);
			format.RGBBitCount = reader.ReadUInt32();
			format.RBitMask = reader.ReadUInt32();
			format.GBitMask = reader.ReadUInt32();
			format.BBitMask = reader.ReadUInt32();
			format.ABitMask = reader.ReadUInt32();

			return format;
		}
	}
}