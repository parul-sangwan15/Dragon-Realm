using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed; // Movement speed, set in the Inspector

    private FixedJoystick joystick; // Reference to the joystick 
    private Rigidbody rb; // Reference to the Rigidbody component attached to this object

    private void Awake()
    {
        joystick = GetComponentInChildren<FixedJoystick>();
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component and FixedJoystick component from a child objectfrom this object
    }

    private void FixedUpdate()
    {
        // Get the horizontal and vertical input from the joystick, ranging from -1 to 1
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        // Normalizing the input vector to ensure consistent movement speed in all directions
        Vector3 movement = new Vector3(x, 0f, z).normalized * speed;

        // Move the Rigidbody in the direction of the movement vector, based on the fixed time step
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);

        // If the movement vector has a magnitude greater than 0, rotate the Rigidbody to face the movement direction
        if (movement.magnitude > 0f)
        {
            // Calculate the target rotation for the Rigidbody 
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            // Rotate the Rigidbody towards the target rotation
            rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, Time.fixedDeltaTime * 720f);
        }
    }
}