using System.IO;
using UnityDds.Utilities;

namespace UnityDds
{
	public class DdsPixelFormat
	{
		public int dwSize;
		public int dwFlags;
		public string dwFourCC;
		public int dwRGBBitCount;
		public int dwRBitMask;
		public int dwGBitMask;
		public int dwBBitMask;
		public int dwABitMask;

		public static DdsPixelFormat Deserialize(BinaryReader reader)
		{
			var format = new DdsPixelFormat();

			format.dwSize = reader.ReadInt32();
			format.dwFlags = reader.ReadInt32();
			format.dwFourCC = reader.ReadString(4);
			format.dwRGBBitCount = reader.ReadInt32();
			format.dwRBitMask = reader.ReadInt32();
			format.dwGBitMask = reader.ReadInt32();
			format.dwBBitMask = reader.ReadInt32();
			format.dwABitMask = reader.ReadInt32();

			return format;
		}
	}
}