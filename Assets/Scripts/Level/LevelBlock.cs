using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlock : MonoBehaviour
{

    private Transform Player;

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
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hello");
            transform.position.Set(0.0f, 0.0f, Player.position.z + 30.0f);
        }
    }
}
