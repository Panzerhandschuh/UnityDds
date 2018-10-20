using NUnit.Framework;
using System.IO;

namespace UnityDds.Tests
{
	public class DdsFileTests
	{
		[Test]
		public void CanReadDdsFile()
		{
			const string path = @"Assets\Scenes\Texture.DDS";
			using (var stream = File.Open(path, FileMode.Open))
			using (var reader = new BinaryReader(stream))
			{
				var file = DdsFile.Deserialize(reader);
				Assert.NotNull(file);
			}
		}
	}
}
