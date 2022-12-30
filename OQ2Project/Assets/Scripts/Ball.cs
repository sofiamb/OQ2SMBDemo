using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public MainSceneController MSController;
    private void Start()
    {
        MSController = GameObject.FindGameObjectWithTag("MainController").GetComponent<MainSceneController>();
    }
    void OnTriggerEnter(Collider otherCollider)
    {
        GameObject box = otherCollider.gameObject;
        if (box.tag == "Box")
        {
            //Debug.Log("IN!!!!");
            MSController.setBoxEvent(box.GetComponent<Box>().boxNumber);

        }
    }
}
