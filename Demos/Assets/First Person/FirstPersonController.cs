using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class FirstPersonController : MonoBehaviour
{


    Vector2 movement;
    Vector2 mouseMovement;
    
    float cameraUpRotation;
    CharacterController controller;
    [SerializeField]
    float speed = 2.0f;
    [SerializeField]
    float mouseSensitivity = 40;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject bulletSpawner;
    [SerializeField]
    GameObject bullet;

    //Jumping
    bool hasJumped = false;
    float ySpeed = 0;
    [SerializeField]
    float jumpHeight = 1.0f;
    [SerializeField]
    float gravityVal = 9.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float lookX = mouseMovement.x * Time.deltaTime * mouseSensitivity;
        float lookY = mouseMovement.y * Time.deltaTime * mouseSensitivity;

        cameraUpRotation -= lookY;

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);

        transform.Rotate(Vector3.up * lookX);

        cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90, 90);

        float moveX = movement.x;
        float moveZ = movement.y;
        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);

        //jumping code

        if (hasJumped)
        {
            hasJumped = false;
            ySpeed = jumpHeight;
        }
        ySpeed -= gravityVal * Time.deltaTime;   
        actual_movement.y = ySpeed;

        controller.Move(actual_movement * Time.deltaTime * speed);
    }
    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }
    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnJump()
    {
        if (controller.isGrounded)
        {
            hasJumped = true;
        }
    }
    void OnAttack()
    {
        Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }
    }

