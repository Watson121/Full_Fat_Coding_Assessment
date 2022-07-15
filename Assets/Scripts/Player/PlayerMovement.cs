using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

 

    [Header("Ship Settings")]
    public float speed = MIN_SPEED;

    [Header("Managers")]
    public LevelManager levelManager;
    public GameDirector gameDirector;

    // Input Actions
    private ShipInputActions shipInputActions;

    // Distance to reset the ship position
    private const float CHECKING_DISTANCE = 300.0f;

    // MIN & MAX Speed of the ship
    private const float MIN_SPEED = 5.0f;
    private const float MAX_SPEED = 60.0f;

    // Lanes that that the ship could be
    private float[] lanePositions;
    private int laneIndex = 2;
    private bool movingLanes = false;

    // Movement
    private Vector3 movement = new Vector3(0, 0, 0.5f);
    private float timeActive = 0.0f;

    // Shielded
    private bool shieled = false;
    private GameObject shield;

    private void Awake()
    {
        shipInputActions = new ShipInputActions();
        lanePositions = gameDirector.LanePositions;
        shield = GameObject.Find("Shield");
        shield.SetActive(false);
    }

    private void OnEnable()
    {
        shipInputActions.Ship.Left_Click.performed += MoveShipLeft;
        shipInputActions.Ship.Left_Click.Enable();

        shipInputActions.Ship.Right_Click.performed += MoveShipRight;
        shipInputActions.Ship.Right_Click.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeActive += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
    
        if (lanePositions[laneIndex] <= transform.position.x)
        {
            transform.Translate(Vector3.left * 5.0f * Time.deltaTime);
            //movingLanes = false;
        }
        if (lanePositions[laneIndex] >= transform.position.x)
        {
            transform.Translate(Vector3.right * 5.0f * Time.deltaTime);
            //movingLanes = false;
        }


        transform.Translate(movement * UpdateForwardSpeed() * Time.deltaTime);
    }

    private void MoveShipLeft(InputAction.CallbackContext obj)
    {
        laneIndex--;
        laneIndex = Mathf.Clamp(laneIndex, 0, lanePositions.Length - 1);
        movingLanes = true;
        
    }

    private void MoveShipRight(InputAction.CallbackContext obj)
    {
        laneIndex++;
        laneIndex = Mathf.Clamp(laneIndex, 0, lanePositions.Length - 1);
        movingLanes = true;
    }


    

    // Updating Forward Speed of the Ship
    private float UpdateForwardSpeed()
    {
        float forwardSpeed = (speed * timeActive);
        forwardSpeed = Mathf.Clamp(forwardSpeed, MIN_SPEED, MAX_SPEED);
        return forwardSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            levelManager.UpdateGroundPosition();
            return;
        }

        if (other.tag == "Obstcale")
        {

            if (shieled != true)
            {
                gameDirector.EndGame();
            } 
            else if (shieled == true)
            {
                shieled = false;
                shield.SetActive(false);
            }
        }

        if(other.tag == "Collectable")
        {
            shieled = true;
            shield.SetActive(true);
            other.transform.position = new Vector3(100.0f, 100.0f, 100.0f);
        }
    }

    


    public void ResetPlayer()
    {
        transform.position = new Vector3(lanePositions[laneIndex], 0, 0);
    }

    public void RestartPlayer()
    {
        transform.position = new Vector3(lanePositions[2], 0, 0);
        shield.SetActive(false);
        speed = MIN_SPEED;
        timeActive = 0.0f;
    }

}
