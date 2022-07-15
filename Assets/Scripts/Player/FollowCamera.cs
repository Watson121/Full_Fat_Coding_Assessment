using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform Player;
    private Vector3 cameraPosition = new Vector3(1.75f, 7.5f, 0.0f);

    // Camera Shake
    private Animator cameraAnim;

    private bool shake = true;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        cameraAnim = GetComponent<Animator>();
     
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
    
    public void ResetCamera()
    {
        cameraAnim.SetBool("Shake", false);
        cameraAnim.enabled = false;
        Time.timeScale = 0.0f;
    }

    public void ShakeCamera()
    {
        cameraAnim.enabled = true;
        cameraAnim.SetBool("Shake", true);

    }

}
