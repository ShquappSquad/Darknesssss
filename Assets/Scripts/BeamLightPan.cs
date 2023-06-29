using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamLightPan : MonoBehaviour
{
    public Transform player;
    private float angleDeg;

    public float damageAmount;
    public LayerMask enemyLayers;

    private float distance = 5f;
    RaycastHit2D enemiesHit;

    float xDiff;
    float yDiff;

    void Start()
    {
        damageAmount = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        moveBeam();
    }

    void FixedUpdate()
    {
        Attack();
    }

    private void rotateBeam(float angleDeg)
    {
        transform.rotation = Quaternion.Euler(0, 0, -angleDeg);
    }

    private void moveBeam()
    {
        angleDeg = calcBeamAngle(); // Grab the angle (in degress) of the players mouse (Where the beam should go)
        rotateBeam(angleDeg); // Rotate the light object with the new beam angle

        transform.position = new Vector3(player.position.x, player.position.y, 0);
    }

    private float calcBeamAngle() {
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

    private void Attack() {
        enemiesHit = Physics2D.Raycast(transform.position, new Vector2(xDiff, yDiff).normalized, distance, enemyLayers);

        // new Vector2(Input.mousePosition.x, Input.mousePosition.y),
        if (enemiesHit)
        {
            enemiesHit.collider.GetComponent<monsterHealth>().takeDamage(damageAmount);
            Debug.Log("Hit something : " + enemiesHit.collider.name);
            Debug.DrawRay(transform.position, new Vector2(xDiff, yDiff).normalized, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, new Vector2(xDiff, yDiff).normalized, Color.red);
        }
    }
}
