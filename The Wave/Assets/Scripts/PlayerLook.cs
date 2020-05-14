using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    //Cached References
    [SerializeField] private float sensitivity = 30;
    [SerializeField] private Transform playerTransform;


    private float xAxisClamp;

    private void Awake()
    {
        xAxisClamp = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;//This is to lock the cursor at the center of the screen
        
    }

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        //Time.deltaTime get's the time between frame, and makes it frame independent
        float indepentSensitivity = sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * indepentSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * indepentSensitivity;

        xAxisClamp += mouseY;

        if (xAxisClamp <= -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampToRotation(90.0f);
        }
        else if (xAxisClamp >= 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampToRotation(270.0f);
        }

        playerTransform.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.left * mouseY); 
    }

    private void ClampToRotation(float value)
    {
        //Make the new vector
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
