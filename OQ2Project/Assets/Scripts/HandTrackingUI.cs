using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using OculusSampleFramework;

public class HandTrackingUI : MonoBehaviour
{
    public HandsManager hand;
    OVRHand RightHand;
    public OVRInputModule inputModule;
    private void Start()
    {
        RightHand = hand.GetComponent<HandsManager>().RightHand;
        inputModule.rayTransform = RightHand.PointerPose;
    }
} 
