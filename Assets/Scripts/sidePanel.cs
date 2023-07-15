using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidePanel : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	public void slideIn(){
		anim.SetTrigger ("slideIn");
	}

	public void slideOut(){
		anim.SetTrigger ("slideOut");
	}

}
