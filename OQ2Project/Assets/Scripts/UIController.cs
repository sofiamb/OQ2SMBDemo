using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image imageBall;
    public TMP_Text pointsText;
    public TMP_Text SelectedStoneText;

    public GameObject[] Panels;
    public Sprite[] sphereSprites;

    MainSceneController MSController;

    private void Start()
    {
        MSController = GameObject.FindGameObjectWithTag("MainController").GetComponent<MainSceneController>();
    }
    public void openPanel(int actualPanel) {

        for (int i = 0; i < Panels.Length; i++)
        {
            if (i == actualPanel)
                Panels[i].SetActive(true);
            else
                Panels[i].SetActive(false);

        }
    }

    public void changeImage(int numberImage, string selectedStone)
    {
        imageBall.sprite = sphereSprites[numberImage];
        imageBall.preserveAspect = true;
        SelectedStoneText.text = selectedStone;

    }
}
