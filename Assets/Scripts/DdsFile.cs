using System.IO;
using UnityDds.Utilities;

namespace UnityDds
{
	public class DdsFile
	{
		private const string magicNumber = "DDS ";
		private const string dx10Identifier = "DX10";

		public string dwMagic;
		public DdsHeader header;
		public DdsDX10Extension dx10Extension;
		public byte[] data;

		public static DdsFile Deserialize(BinaryReader reader)
		{
			var file = new DdsFile();

			file.dwMagic = reader.ReadString(4);
			if (file.dwMagic != magicNumber)
				throw new IOException($"Expected header file identifier ({magicNumber}) does not match the deserialized identifier ({file.dwMagic})");

			file.header = DdsHeader.Deserialize(reader);
			if (file.header.ddspf.fourCC == dx10Identifier)
				file.dx10Extension = DdsDX10Extension.Deserialize(reader);

			file.data = reader.ReadRemainingBytes();

			return file;
		}
	}
}
