//--------------GameController Script--------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static string currentSelectedCar = "blueLambo";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void showNewCar(string nextCar){
       //my code
        GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar).SetActive(false);
        currentSelectedCar = nextCar;
        GameObject.Find("/GroundPlaneStage/activeItems/" + GameController.currentSelectedCar).SetActive(true);

// 	GameObject.Find (colourSwitcher.instance.getCurrentTracked ().name + "/activeItems/" + gameController.currentSelectedCar).SetActive(false);
// 	currentSelectedCar = nextCar;
// 	GameObject.Find (colourSwitcher.instance.getCurrentTracked ().name + "/activeItems/" + gameController.currentSelectedCar).SetActive(true);
 }
   

    // Update is called once per frame
    // void Update()
    // {
    //     print(currentSelectedCar);
    // }
    public void quit(){
        Application.Quit ();
    }

    public void changeLevel(string scene){
        SceneManager.LoadScene(scene);
    }
}
