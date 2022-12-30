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
    public Ball[] Stones;
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
    private int teleportingCount;
    

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
           // testMainUIText.text = grabbed.ToString();
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
                testBoxesText.gameObject.SetActive(true);
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
                slignStonesToInitialPosition();
                 Boxes[2].GetComponent<Box>().activeTeleportation();
                isRespawned = true;
                testBoxesText.gameObject.SetActive(false);
                changeSphereStoneGO(0);
                teleportingCount++;
                mainUI.GetComponent<UIController>().pointsText.text = teleportingCount.ToString() + "times respawned to check point";
                break; 


        }
    }

    public void changeSphereStoneGO(int StoneNumber) {
       
       
            activeSelectedStone(StoneNumber);
       
    }
    private void activeSelectedStone(int num)
    {
        testMainUIText.text = "Stone nro " + num;
        for (int i = 0; i< Stones.Length; i++)
        {
            if (i != num)
                Stones[i].gameObject.SetActive(false);
            else
                Stones[i].gameObject.SetActive(true);
        }       
    }
    private void slignStonesToInitialPosition()
    {
        sphere.transform.localPosition = ballInitialPosition;
        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
        sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        for (int i = 0; i < Stones.Length; i++)
        {
           Stones[i].gameObject.SetActive(false);
           Stones[i].transform.localPosition = ballInitialPosition;
           Stones[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
           Stones[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

}
