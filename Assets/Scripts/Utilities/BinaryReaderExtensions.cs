using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnityDds.Utilities
{
	internal static class BinaryReaderExtensions
	{
		/// <summary>
		/// Reads an array, using the specified length to indicate the number of elements
		/// </summary>
		public static T[] ReadArray<T>(this BinaryReader reader, Func<BinaryReader, T> deserializeFunc, int length)
		{
			var array = new T[length];

			for (var i = 0; i < length; i++)
				array[i] = deserializeFunc(reader);

			return array;
		}

		/// <summary>
		/// Reads bytes until reaching the end of the file
		/// </summary>
		public static byte[] ReadRemainingBytes(this BinaryReader reader)
		{
			const int chunkSize = 4096;
			using (var ms = new MemoryStream())
			{
				var buf = new byte[chunkSize];
				int count;
				while ((count = reader.Read(buf, 0, buf.Length)) > 0)
					ms.Write(buf, 0, count);

				return ms.ToArray();
			}
		}

		/// <summary>
		/// Reads a string with the specified length
		/// </summary>
		public static string ReadString(this BinaryReader reader, int length)
		{
			var chars = reader.ReadChars(length);
			return new string(chars);
		}
	}
}
