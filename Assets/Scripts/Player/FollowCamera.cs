using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform Player;
    private Vector3 cameraPosition = new Vector3(1.75f, 7.5f, 0.0f);


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, Player.position.z);
            
        }
    }
}
