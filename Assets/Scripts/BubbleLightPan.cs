using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleLightPan : MonoBehaviour
{
    public Transform player;
    public float damageAmount;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y - 0.75f, 0);
        
    }
}
