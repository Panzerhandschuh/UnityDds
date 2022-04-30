using System;
using UnityEngine;

namespace UnityDds.Utilities
{
	public static class DdsUtil
	{
		public static TextureFormat GetTextureFormat(DdsFile file)
		{
			if (file.dx10Extension != null)
				return GetTextureFormatDX10(file.dx10Extension);
			else
				return GetTextureFormat(file.header);
		}

		private static TextureFormat GetTextureFormatDX10(DdsDX10Extension dx10Extension)
		{
			var format = dx10Extension.dxgiFormat;
			switch (format)
			{
				case DXGIFormat.DXGI_FORMAT_BC6H_UF16:
				case DXGIFormat.DXGI_FORMAT_BC6H_SF16:
					return TextureFormat.BC6H;
				case DXGIFormat.DXGI_FORMAT_BC7_UNORM:
					return TextureFormat.BC7;
				default:
					throw new Exception($"DDS file has an invalid or unsupported texture format ({format})");
			}
		}

		private static TextureFormat GetTextureFormat(DdsHeader header)
		{
			var format = header.ddspf.fourCC;
			switch (format)
			{
				case "DXT1":
					return TextureFormat.DXT1;
				case "DXT5":
					return TextureFormat.DXT5;
				case "BC4U":
					return TextureFormat.BC4;
				case "BC5U":
					return TextureFormat.BC5;
				default:
					throw new Exception($"DDS file has an invalid or unsupported texture format ({format})");
			}
		}
	}
}
