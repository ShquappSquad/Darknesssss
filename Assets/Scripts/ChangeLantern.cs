using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLantern : MonoBehaviour
{
    public enum LightType
    {
        bubble,
        beam
    }

    public GameObject bubbleLightObj;
    public GameObject beamLightObj;

    private LightType currentLightType = LightType.bubble;


    void Start()
    {
        SwitchToBubble();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // 0 is LMB, 1 is RMB, 2 is Middle Click
        {         
            switch(currentLightType) 
            {
                case LightType.bubble:
                    currentLightType = LightType.beam;
                    Debug.Log("Switch to beam");
                    SwitchToBeam();
                    break;
                case LightType.beam:
                    currentLightType = LightType.bubble;
                    Debug.Log("Switch to bubble");
                    SwitchToBubble();
                    break;
            }
        }
    }

    void SwitchToBeam()
    {
        bubbleLightObj.SetActive(false);
        beamLightObj.SetActive(true);
    }

    void SwitchToBubble()
    {
        bubbleLightObj.SetActive(true);
        beamLightObj.SetActive(false);
    }
}
