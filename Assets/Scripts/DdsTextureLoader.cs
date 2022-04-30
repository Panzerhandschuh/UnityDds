using System;
using System.IO;
using UnityDds.Utilities;
using UnityEngine;

namespace UnityDds
{
	public static class DdsTextureLoader
	{
		public static Texture2D LoadTexture(string path, bool isLinear = false)
		{
			using (var stream = File.Open(path, FileMode.Open))
				return LoadTexture(stream, isLinear);
		}

		public static Texture2D LoadTexture(Stream stream, bool isLinear = false)
		{
			var file = GetDdsFile(stream);
			var format = DdsUtil.GetTextureFormat(file);
			var hasMipMaps = file.header.mipMapCount > 1;

			var texture = new Texture2D((int)file.header.width, (int)file.header.height, format, hasMipMaps, isLinear);
			texture.LoadRawTextureData(file.data);
			texture.Apply(false, true);

			return texture;
		}

		private static DdsFile GetDdsFile(Stream stream)
		{
			using (var reader = new BinaryReader(stream))
			{
				return DdsFile.Deserialize(reader);
			}
		}
	}
}
