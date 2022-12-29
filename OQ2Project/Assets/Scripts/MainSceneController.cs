using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using System;
using TMPro;

public class MainSceneController : MonoBehaviour
{
    
    public GameObject OVRPlayerController;
    public GameObject sphere;
    public GameObject mainUI;
    public GameObject Canvas;

    public GameObject checkPoint;

    public GameObject[] Boxes;//A-B-C
    public TMP_Text testMainUIText;
    public TMP_Text testBoxesText;


    public  event Action<int> SucceededEvent;
    private bool grabbed;
    private bool isRespawned = true;
    private int countTimesMenuOpened;
    private Vector3 ballInitialPosition;
    

    void Start()
    {
        SucceededEvent += setBoxEvent;
        ballInitialPosition = sphere.transform.localPosition;
       

    }
   

    void Update()
    {
        Canvas.transform.localPosition = new Vector3(0, 0.532f, 2.381f);
        grabbed = sphere.GetComponent<OVRGrabbable>().isGrabbed;
        if (grabbed == true && isRespawned == true)
        {
           
            showMainMenu(true);
            testMainUIText.text = grabbed.ToString();
            this.GetComponent<UIController>().changeImage(0);
            isRespawned = false;   
            

        }

    }

    public void showMainMenu(bool active) {

        mainUI.SetActive(active);
    }

    public void setBoxEvent(int boxNumber) {

        switch (boxNumber) {
            case 0:
                //Particle effect 1
                testBoxesText.text = "Box A selected";
                Boxes[0].GetComponent<Box>().activeParticleEffect();
             break;
            case 1:
                //Particle effect 2
               // testBoxesText.text = "Box B selected";
                Boxes[1].GetComponent<Box>().activeParticleEffect();
                Boxes[1].GetComponent<Box>().activeAnimation(); 
                break;
            case 2:
                //Respwan to teleportation area
                Vector3 CharacterPosition = OVRPlayerController.transform.localPosition;
                OVRPlayerController.transform.localPosition = new Vector3(checkPoint.transform.localPosition.x, -0.397f, checkPoint.transform.localPosition.z);
                OVRPlayerController.transform.localRotation = new Quaternion(0,0,0,0);
                sphere.transform.localPosition = ballInitialPosition;
                Boxes[2].GetComponent<Box>().activeTeleportation();
                break; 


        }
    }

}
