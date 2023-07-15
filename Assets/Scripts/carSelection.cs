//-------------carSelection script---------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSelection : MonoBehaviour
{
    //we create an empty list of gameObject.
    private GameObject[] carList;
    private int currentCar = 0;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        //Count the Child gameobject from the cars transform.
        carList = new GameObject[transform.childCount];

        //loop through the child and fill the list in the correct slote.
        for(int i = 0; i < transform.childCount; ++i){
            carList[i] = transform.GetChild (i).gameObject;
        }

        //Deactivate all the gameobj in the list
        foreach(GameObject gameObj in carList){
            gameObj.SetActive(false);
        }

        //Set the initial GameObject to be active.
        if(carList[0]){
            carList[0].SetActive(true);
            //resotore the spingrow animation.....
            if(carList[0].name == "blueLambo"){
                carList[0].GetComponent<Animator>().SetTrigger("intro");
                //particle effect-------
                 GameObject cloudSystem = Instantiate (Resources.Load ("cloudParticle")) as GameObject;
                 ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
                 cloudPuff.Play();
                 cloudPuff.transform.position = new Vector3(22f, -0.5f, 0f);
                 Destroy (cloudSystem, 2f);
            }
        }
    }

   public void toggleCar(string direction){
    carList[currentCar].SetActive(false);

    if(direction == "Right"){
        currentCar++;
        if(currentCar > carList.Length - 1){
            currentCar = 0;
        }
    }
    else if(direction == "Left"){
        currentCar--;
        if(currentCar < 0){
            currentCar = carList.Length - 1;
        }
    }
    //set the currentcar to be active from the list
    carList[currentCar].SetActive(true);
    //resotore the spingrow animation.....
    carList[currentCar].GetComponent<Animator>().SetTrigger("intro");

    GameController.currentSelectedCar = carList[currentCar].name;
    //particle effect......
    GameObject cloudSystem = Instantiate (Resources.Load ("cloudParticle")) as GameObject;
    ParticleSystem cloudPuff = cloudSystem.GetComponent<ParticleSystem>();
    cloudPuff.Play();
    cloudPuff.transform.position = new Vector3(22f, -0.5f, 0f);
    Destroy (cloudSystem, 2f);
   }

   public void showPanel(){
    panel.SetActive(true);
   }
}
