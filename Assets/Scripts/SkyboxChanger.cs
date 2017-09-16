using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChanger : MonoBehaviour {
	public Material[] skybox;
	private int count;
	private Material m;
	private int color;
	// Use this for initializationS
	void Start () {
		count = 0;
		color = 0;
		m = new Material(skybox[color]);
		this.GetComponent<Skybox>().material = m; 
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count >= 300) {
			color++;
			if (color >= 3) {
				color = 0;
			}
			m = new Material (skybox [color]);
			this.GetComponent<Skybox> ().material = m; 
			count = 0;
		}
	}
}
