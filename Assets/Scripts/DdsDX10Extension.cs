using System.IO;

namespace UnityDds
{
	public class DdsDX10Extension
	{
		public DXGIFormat dxgiFormat;
		public uint resourceDimension;
		public uint miscFlag; // See D3D11_RESOURCE_MISC_FLAG
		public uint arraySize;
		public uint reserved;

		public static DdsDX10Extension Deserialize(BinaryReader reader)
		{
			var header = new DdsDX10Extension();

			header.dxgiFormat = (DXGIFormat)reader.ReadUInt32();
			header.resourceDimension = reader.ReadUInt32();
			header.miscFlag = reader.ReadUInt32();
			header.arraySize = reader.ReadUInt32();
			header.reserved = reader.ReadUInt32();

			return header;
		}
	}
}
