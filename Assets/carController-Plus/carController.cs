//-----------carContriller script-------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class carController : MonoBehaviour {

	Animator anim;
	AudioSource audio;
	VideoPlayer video;
	public static carController instance;
 	
    //Car Controller
    public static int selectedIndex = 0;

	//Create a cloned object so we can access the functions
	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
 
		//Loop through the child items activating the correct item by name
		for (int i = 0; i < transform.childCount; ++i) {
			
			//Check the current selected item and activate
 			if (transform.GetChild (i).gameObject.name == GameController.currentSelectedCar) {
				transform.GetChild (i).gameObject.SetActive (true);

				//Inside Start
    			selectedIndex = i;

				//Get the animator componant from the active item
				anim = transform.GetChild (i).gameObject.GetComponent<Animator> ();
			} else {
				//Deactivate all other cars
				transform.GetChild (i).gameObject.SetActive (false);
			}
 		}

		 
	}

	//Called from _Handle
 	public void triggerAnimation(string action){
		//anim = GameObject.Find("/groundPlane/activeItems/" + GameController.currentSelectedCar).GetComponent<Animator>();
		anim = GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar).GetComponent<Animator>();
		anim.SetTrigger (action);
	}

	//Called from _Handle
	public void showMessage(){
		//TODO
	}
	//----------------------------------------------MY OWN CODE----------------------------------------------------------------
    //car engine sound
	public void playSound(){
		audio = GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar).GetComponent<AudioSource>();
		audio.Play();
	}
	public void stopSound(){
		audio = GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar).GetComponent<AudioSource>();
		audio.Stop();
	}

    //video controller from handel
	public void playVideo(){
		video = GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar + "/video").GetComponent<VideoPlayer>();
		video.Play();
	}
	public void stopVideo(){
		video = GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar + "/video").GetComponent<VideoPlayer>();
		video.Pause();
	}

   //audiofix
	public void killSound(){
		GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar + "/video").GetComponent<AudioSource>().volume = 0f;
		GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar).GetComponent<AudioSource>().volume = 0f;
		
	}
	public void resetSound(){
	    GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar + "/video").GetComponent<AudioSource>().volume = 100f;
	    GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar).GetComponent<AudioSource>().volume = 100f;
		
	}

}
