using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerStateManager : MonoBehaviour

{
    
    
    [HideInInspector]
    public PlayerBaseState currentState;
    

    [HideInInspector]
    public PlayerIdleState idleState = new PlayerIdleState();
    [HideInInspector]
    public PlayerWalkState walkState = new PlayerWalkState();
    [HideInInspector]
    public PlayerSneakState sneakState = new PlayerSneakState();
    [HideInInspector]
    public Vector2 movement;
    
    public float default_speed = 1.0f;

 
  

    public bool isSneaking = false;
   CharacterController controller;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        SwitchState(idleState);
        
    }



    // Update is called once per frame  
    void Update()
    {
       
   
        currentState.UpdateState(this);
       
        //if (hasJumped)
        //{
         //   hasJumped = false;
         //   ySpeed = jumpHeight;
       // }
        //ySpeed -= gravityVal * Time.deltaTime;
        

       

        //if (controller.isGrounded)
        
           // dashState.ResetDash(); // Allow air dashing again
        
    }

    //Handle Input// 

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
        print("Moving!");

    }
   
    void OnSprint(InputValue sprintVal)
    {
        if (sprintVal.isPressed)
        {
            isSneaking = true;
        }
        else
        {
            isSneaking = false;
        }
    }
    public void MovePlayer(float player_speed)
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = new Vector3(moveX, 0, moveZ);


        controller.Move(actual_movement * Time.deltaTime * player_speed);
    }
    


       
    

public void SwitchState(PlayerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
