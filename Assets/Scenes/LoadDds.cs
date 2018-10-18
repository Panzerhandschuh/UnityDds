using System.IO;
using UnityDds;
using UnityEngine;

public class LoadDds : MonoBehaviour
{
	public string ddsPath;

	private void Awake()
	{
		using (var stream = File.Open(ddsPath, FileMode.Open))
		{
			var material = GetComponent<Renderer>().material;
			var texture = DdsTextureLoader.LoadTexture(stream);
			material.SetTexture("_MainTex", texture);
		}
	}
}
