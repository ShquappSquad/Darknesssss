using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggle : MonoBehaviour
{
    public GameObject bubbleLight;
    public GameObject beamLight;
    public string currentMode = "bubbleLight";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // 0 is LMB, 1 is RMB, 2 is Middle Click
        {          
            if(currentMode == "bubbleLight")
            {
                Debug.Log("Switch to beam");
                SwitchToBeam();
                currentMode = "beamLight";
                return;
            }
            if(currentMode == "beamLight")
            {
                Debug.Log("Switch to bubble");
                SwitchToBubble();
                currentMode = "bubbleLight";
                return;
            }
        }
    }

    void SwitchToBeam()
    {
        
    }

    void SwitchToBubble()
    {

    }
}
