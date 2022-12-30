using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStone : MonoBehaviour
{
    public int stoneNumber; // Sphere = 0, Wolf = 1,  lizard = 2, skull = 3;
    public MainSceneController MSController;
    private void Start()
    {
        MSController = GameObject.FindGameObjectWithTag("MainController").GetComponent<MainSceneController>();
    }
    public void selectStone()
    {

        MSController.GetComponent<UIController>().changeImage(stoneNumber);
        MSController.changeSphereStoneGO(stoneNumber);
    }

}
