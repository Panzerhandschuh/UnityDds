using System.IO;
using UnityDds.Utilities;

namespace UnityDds
{
	public class DdsFile
	{
		private const string magicNumber = "DDS ";

		public string dwMagic;
		public DdsHeader header;
		public byte[] data;

		public static DdsFile Deserialize(BinaryReader reader)
		{
			var file = new DdsFile();

			file.dwMagic = reader.ReadString(4);
			if (file.dwMagic != magicNumber)
				throw new IOException($"Expected header file identifier ({magicNumber}) does not match the deserialized identifier ({file.dwMagic})");

			file.header = DdsHeader.Deserialize(reader);
			file.data = reader.ReadRemainingBytes();

			return file;
		}
	}
}
