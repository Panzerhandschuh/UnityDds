using System.IO;
using UnityDds.Utilities;

namespace UnityDds
{
	public class DdsHeader
	{
		public uint size;
		public uint flags;
		public uint height;
		public uint width;
		public uint pitchOrLinearSize;
		public uint depth;
		public uint mipMapCount;
		public uint[] reserved1; // 11 ints
		public DdsPixelFormat ddspf;
		public uint caps;
		public uint caps2;
		public uint caps3;
		public uint caps4;
		public uint reserved2;

		public static DdsHeader Deserialize(BinaryReader reader)
		{
			var header = new DdsHeader();

			header.size = reader.ReadUInt32();
			header.flags = reader.ReadUInt32();
			header.height = reader.ReadUInt32();
			header.width = reader.ReadUInt32();
			header.pitchOrLinearSize = reader.ReadUInt32();
			header.depth = reader.ReadUInt32();
			header.mipMapCount = reader.ReadUInt32();
			header.reserved1 = reader.ReadArray((x) => x.ReadUInt32(), 11);
			header.ddspf = DdsPixelFormat.Deserialize(reader);
			header.caps = reader.ReadUInt32();
			header.caps2 = reader.ReadUInt32();
			header.caps3 = reader.ReadUInt32();
			header.caps4 = reader.ReadUInt32();
			header.reserved2 = reader.ReadUInt32();

			return header;
		}
	}
}