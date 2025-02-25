using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float mouseSensitivity = 100f;
    public Transform cameraTransform; // Assign your actual camera in Inspector
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate around X-axis (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 75f); // Limits vertical rotation

        // Rotate the camera and player
        transform.Rotate(Vector3.up * mouseX);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Ensure camera follows the player
        transform.position = player.position;
    }
}