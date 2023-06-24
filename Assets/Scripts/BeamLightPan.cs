using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLightPan : MonoBehaviour
{
    public Transform player;
    public GameObject bubbleLight;
    private float angleDeg;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            swapLight();
        }

        angleDeg = calcBeamAngle(); // Grab the angle (in degress) of the players mouse (Where the beam should go)
        moveBeam(angleDeg); // Rotate the light object with the new beam angle

        transform.position = new Vector3(player.position.x, player.position.y, 0);
    }

    private void moveBeam(float angleDeg)
    {
        transform.rotation = Quaternion.Euler(0, 0, -angleDeg);
    }

    private float calcBeamAngle() {
        float xDiff;
        float yDiff;
        Vector3 mousePos = Input.mousePosition; // Grab the position of player's mouse

        // Calculate the x and y coordinates of the mouse relative to the player
        // We assume that the player will always be in the middle of the screen
        xDiff = mousePos.x - (Screen.width / 2); 
        yDiff = mousePos.y - (Screen.height / 2);

        // Convert the coordinates to an angle in radians
        float angleRad;
        angleRad = Mathf.Atan2(xDiff , yDiff);

        return angleRad * Mathf.Rad2Deg;
    }

    private void swapLight()
    {
        bubbleLight.SetActive(true);
    }
}
