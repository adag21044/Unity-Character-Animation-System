using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Camera camera;
    CharacterController characterController;
    public float speed = 5.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Create a vector in local space based on input
        Vector3 localMove = new Vector3(x, 0.0f, z); // Set the Y component to 0 to restrict movement to the X and Z axes only

        // Get the camera's forward and right vectors
        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraRight = camera.transform.right;

        // Project the movement onto the camera's plane (remove the vertical component)
        Vector3 move = Vector3.ProjectOnPlane(localMove, Vector3.up);

        // Combine the camera's forward and right vectors to get the desired movement direction
        Vector3 rotatedMovement = cameraForward * move.z + cameraRight * move.x;

        characterController.Move(rotatedMovement * speed * Time.deltaTime);
    }
}