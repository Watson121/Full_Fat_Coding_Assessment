using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private ShipInputActions shipInputActions;

    // Distance to reset the ship position
    private const float CHECKING_DISTANCE = 100.0f;

    // MIN & MAX Speed of the ship
    private const float MIN_SPEED = 3.0f;
    private const float MAX_SPEED = 30.0f;

    private float[] lanePositions = {-4.0f, -2.0f, 0.0f, 2.0f, 4.0f };
    [SerializeField] private int laneIndex = 2;
    [SerializeField] private bool movingLanes = false;

    public float speed = MIN_SPEED;
    private Vector3 movement = new Vector3(0, 0, 1);
    public float TimeActive;

    private void Awake()
    {
        shipInputActions = new ShipInputActions();
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
        TimeActive += Time.deltaTime;

     


    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        if (CheckPosition(transform.position.z))
        {
            transform.position = new Vector3(lanePositions[laneIndex], 0, 0);
        }

        if (lanePositions[laneIndex] <= transform.position.x)
        {
            transform.Translate(Vector3.left * UpdateForwardSpeed() * Time.deltaTime);
            //movingLanes = false;
        }
        if (lanePositions[laneIndex] >= transform.position.x)
        {
            transform.Translate(Vector3.right * UpdateForwardSpeed() * Time.deltaTime);
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
        float forwardSpeed = (speed * TimeActive);
        forwardSpeed = Mathf.Clamp(forwardSpeed, MIN_SPEED, MAX_SPEED);
        return forwardSpeed;
    }

    // Checking if position of ship has gone beyond checking distance
    private bool CheckPosition(float z)
    {

        if(z >= CHECKING_DISTANCE)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
