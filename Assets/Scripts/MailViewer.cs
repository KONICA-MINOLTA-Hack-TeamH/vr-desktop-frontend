using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailViewer : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void SetMail(string type, string s){
		s =  type + " : " + s + "/n";
		this.GetComponent<TextMesh> ().text = s;
	}
	public void Visible(bool t){
		this.GetComponent<MeshRenderer>().enabled = t;
	}
}
