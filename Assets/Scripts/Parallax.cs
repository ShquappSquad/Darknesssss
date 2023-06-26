using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPos;
    public float parallaxEffect;
    private float distance;
    public Transform player;
    public Camera mainCam;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        distance = ((mainCam.transform.position.x * parallaxEffect)/2);
        transform.position = new Vector3(startPos + distance, player.position.y,transform.position.z);
    }
}
