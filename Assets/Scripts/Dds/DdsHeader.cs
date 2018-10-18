using System.IO;
using UnityDds.Utilities;

namespace UnityDds
{
	public class DdsHeader
	{
		public int dwSize;
		public int dwFlags;
		public int dwHeight;
		public int dwWidth;
		public int dwPitchOrLinearSize;
		public int dwDepth;
		public int dwMipMapCount;
		public int[] dwReserved1; // 11 ints
		public DdsPixelFormat ddspf;
		public int dwCaps;
		public int dwCaps2;
		public int dwCaps3;
		public int dwCaps4;
		public int dwReserved2;

		public static DdsHeader Deserialize(BinaryReader reader)
		{
			var header = new DdsHeader();

			header.dwSize = reader.ReadInt32();
			header.dwFlags = reader.ReadInt32();
			header.dwHeight = reader.ReadInt32();
			header.dwWidth = reader.ReadInt32();
			header.dwPitchOrLinearSize = reader.ReadInt32();
			header.dwDepth = reader.ReadInt32();
			header.dwMipMapCount = reader.ReadInt32();
			header.dwReserved1 = reader.ReadArray((x) => x.ReadInt32(), 11);
			header.ddspf = DdsPixelFormat.Deserialize(reader);
			header.dwCaps = reader.ReadInt32();
			header.dwCaps2 = reader.ReadInt32();
			header.dwCaps3 = reader.ReadInt32();
			header.dwCaps4 = reader.ReadInt32();
			header.dwReserved2 = reader.ReadInt32();

			return header;
		}
	}
}