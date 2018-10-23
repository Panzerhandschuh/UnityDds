using System.IO;
using UnityDds;
using UnityEngine;

public class LoadDds : MonoBehaviour
{
	public string ddsPath;

	private void Awake()
	{
		var material = GetComponent<Renderer>().material;
		var texture = DdsTextureLoader.LoadTexture(ddsPath);
		material.SetTexture("_MainTex", texture);
	}
}
