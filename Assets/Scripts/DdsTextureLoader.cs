using System;
using System.IO;
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
			var format = GetTextureFormat(file.header.ddspf.dwFourCC);
			var hasMipMaps = file.header.dwMipMapCount > 1;

			var texture = new Texture2D(file.header.dwWidth, file.header.dwHeight, format, hasMipMaps, isLinear);
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

		private static TextureFormat GetTextureFormat(string format)
		{
			switch (format)
			{
				case "DXT1":
					return TextureFormat.DXT1;
				case "DXT5":
					return TextureFormat.DXT5;
				case "BC5U":
					return TextureFormat.BC5;
				default:
					throw new Exception($"DDS file has an invalid or unsupported texture format ({format})");
			}
		}
	}
}
