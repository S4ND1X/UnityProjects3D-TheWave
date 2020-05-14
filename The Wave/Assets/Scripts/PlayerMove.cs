using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //Player Movement Config values
    [SerializeField] private float walkingSpeed = 10.0f, 
                                   runningSpeed = 15.0f, 
                                   runningTransitionSpeed = 2.0f, 
                                   jumpForce = 5.0f, 
                                   slopePush = 3.0f, 
                                   slopeRayCastDistance = 3.0f;
    private float movementSpeed;
    private bool isJumping = false;

    //Player Controllers Config
    [SerializeField] private KeyCode runK = KeyCode.LeftShift, 
                                     jumpK = KeyCode.Space;

  
    //Chached references
    private CharacterController charController;
    [SerializeField] private AnimationCurve jumpFallOff;

    

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        Vector3 forwardMove = transform.forward * vertInput;
        Vector3 rightMove = transform.right * horizInput;

        charController.SimpleMove(Vector3.ClampMagnitude(forwardMove + rightMove, 1.0f) * movementSpeed);

        if ((vertInput != 0 || horizInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopePush * Time.deltaTime);


        SetMovementSpeed();
        JumpInput();
    }

    //The transition from walking to running it's smooth, so that why 
    private void SetMovementSpeed()
    {
        if (Input.GetKey(runK))
            movementSpeed = Mathf.Lerp(movementSpeed, runningSpeed, Time.deltaTime * runningTransitionSpeed);
        else
            movementSpeed = Mathf.Lerp(movementSpeed, walkingSpeed, Time.deltaTime * runningTransitionSpeed);
    }


    private bool OnSlope()
    {
        if (isJumping) { return false; } // If is jumping, it cannot be a slope

        RaycastHit hitSlope; // Throws a ray at the surface to check if is a slope

        if (Physics.Raycast(transform.position, Vector3.down, out hitSlope, 
                            charController.height / 2 * slopeRayCastDistance))
        {
            if (hitSlope.normal != Vector3.up)
            {
                Debug.Log("Slope");
                return true;
            }
        }
        return false;
    }

    private void JumpInput()
    {
        
        if (Input.GetKeyDown(jumpK) && !isJumping)
        {
            Debug.Log("Jumping");
            isJumping = true;
            StartCoroutine(JumpingEvent()); //Start to evalute the jumping mechanics
        }
    }


    /*Basically what it does is that when your player is falling off or jumping
     * the more time you are in air, the less force is applied upwards
     */ 
    private IEnumerator JumpingEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeAir); // The force is equal to the function an that moment
            charController.Move(Vector3.up * jumpForce * this.jumpForce * Time.deltaTime);
            timeAir += Time.deltaTime; //Add every frame as time
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}