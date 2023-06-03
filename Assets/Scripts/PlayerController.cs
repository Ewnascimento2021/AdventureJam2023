using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        IDLE,
        WALKING,
        RUNNING,
        JUMPING,
        DOUBLEJUMPING,
        ATTACK1,
        ATTACK2,
        DEFEND,
    }
    [SerializeField]
    private float gravityForce;
    [SerializeField]
    private float jumpingForce;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float walkingSpeed;
    [SerializeField]
    private float runningSpeed;
    [SerializeField]
    private Vector3 movDirection;

    private Animator anim;
    private CharacterController cc;
    private PlayerState currentState;
    private float rotation;
    private float directionY;
    private bool doubleJumping;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        SetState(PlayerState.IDLE);
    }

    void Update()
    {
        handleInpet();
        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        movDirection = transform.TransformDirection(movDirection);
        movDirection.y = directionY;
        movDirection *= Time.deltaTime;
        cc.Move(movDirection);
    }



    private void handleInpet()
    {
        switch (currentState)
        {
            case PlayerState.IDLE:
                HandleIdleState();
                break;
            case PlayerState.WALKING:
                HandleWalkingState();
                break;
            //case PlayerState.RUNNING:
            //    HandleRunningState();
            //    break;
            case PlayerState.JUMPING:
                HandleJumpingState();
                break;
            case PlayerState.DOUBLEJUMPING:
                HandleDoubleJumpingState();
                break;
                //case PlayerState.ATTACK1:
                //    HandleAttack1State();
                //    break;
                //case PlayerState.ATTACK2:
                //    HandleAttack2State();
                //    break;
                //case PlayerState.DEFEND:
                //    HandleDefendState();
                //    break;
        }

    }
    private void SetState(PlayerState newState)
    {
        if (newState != currentState)
        {
            currentState = newState;
            // anim.SetBool(newState.ToString(), true);
        }
    }
    private void HandleIdleState()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SetState(PlayerState.WALKING);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            SetState(PlayerState.RUNNING);
        }
        else if (Input.GetButtonDown("Jump"))
        {
            SetState(PlayerState.JUMPING);
        }
        else if (Input.GetMouseButton(0))
        {
            SetState(PlayerState.ATTACK1);
        }
        else if (Input.GetMouseButton(1))
        {
            SetState(PlayerState.DEFEND);
        }
    }
    private void HandleWalkingState()
    {
        movDirection = Vector3.forward * walkingSpeed;
        anim.SetBool("isWalking", true);

        if (!Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", false);
            Vector3 movement = Vector3.zero;
            SetState(PlayerState.IDLE);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isWalking", false);
            SetState(PlayerState.RUNNING);
        }
        else if (Input.GetButton("Jump"))
        {
            anim.SetBool("isWalking", false);
            SetState(PlayerState.JUMPING);
        }
        else if (Input.GetMouseButton(0))
        {
            anim.SetBool("isWalking", false);
            SetState(PlayerState.ATTACK1);
        }
        else if (Input.GetMouseButton(1))
        {
            anim.SetBool("isWalking", false);
            SetState(PlayerState.DEFEND);
        }
        //else
        //{
        //    movDirection = Vector3.forward * walkingSpeed;
        //    anim.SetBool("isWalking", true);
        //}

    }
    private void HandleJumpingState()
    {
        //Vector3 movement = Vector3.zero;

        
        if (cc.isGrounded)
        {
            anim.SetBool("isJumping", true);
            doubleJumping = false;
            directionY = jumpingForce;
            movDirection = Vector3.forward * jumpingForce;
            Debug.Log("HERE");
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("isJumping", false);
                SetState(PlayerState.ATTACK2);
            }

            else if (Input.GetButtonDown("Jump") && !doubleJumping)
            {
                anim.SetBool("isJumping", false);
                SetState(PlayerState.DOUBLEJUMPING);
            }
            //else
            //{
            //    SetState(PlayerState.IDLE);
            //}
            //else if (Input.GetKey(KeyCode.W))
            //{
            //    anim.SetBool("isJumping", false);
            //    SetState(PlayerState.WALKING);
            //}
            //else if (Input.(KeyCode.LeftShift))
            //{
            //    anim.SetBool("isJumping", false);
            //    SetState(PlayerState.RUNNING);
            //}
            //else if (Input.GetKey(KeyCode.LeftShift))
            //{
            //    SetState(PlayerState.RUNNING);
            //}



            //anim.SetBool("isJumping", false);
            //anim.SetBool("isDoubleJump", true);
            //directionY = jumpingForce;
            //movDirection = Vector3.forward * jumpingForce;
            //doubleJumping = true;
        }
    }
    private void HandleDoubleJumpingState()
    {
        if (!cc.isGrounded)
        {
            anim.SetBool("isDoubleJump", true);
            directionY = jumpingForce;
            movDirection = Vector3.forward * jumpingForce;
            doubleJumping = true;
        }
        else
        {
            SetState(PlayerState.IDLE);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", false);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("isWalking", false);
            SetState(PlayerState.RUNNING);
        }
        else if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isWalking", false);
            SetState(PlayerState.JUMPING);
        }
        else if (Input.GetMouseButton(0))
        {
            anim.SetBool("isWalking", false);
            SetState(PlayerState.ATTACK1);
        }
        else if (Input.GetMouseButton(1))
        {
            anim.SetBool("isWalking", false);
            SetState(PlayerState.DEFEND);
        }
        else
        {
            SetState(PlayerState.IDLE);
        }

    }

}
//Vector3 movement = Vector3.zero;

//movDirection = Vector3.forward* walkingSpeed;
//anim.SetBool("isWalking", true);



//if (doubleJumping)
//{
//    doubleJumping = false;
//    SetState(PlayerState.DoubleJumping);
//}

//        else if (!doubleJumping)
//        {
//            doubleJumping = true;
//            verticalVelocity = jumpingForce
//}

//private void HandleRunningState()
//{
//    if (!Input.GetKey(KeyCode.W))
//    {
//        SetState(PlayerState.IDLE);
//    }
//    else if (Input.GetButtonDown("Jump"))
//    {
//        Jump();
//    }
//}
//    }


//if (Input.GetKey(KeyCode.W))
//{
//    movDirection = Vector3.forward * walkingSpeed;
//    anim.SetBool("isWalking", true);

//    if (Input.GetKey(KeyCode.LeftShift))
//    {
//        anim.SetBool("isRunning", true);
//        movDirection = Vector3.forward * runningSpeed;
//    }
//    else
//    {
//        anim.SetBool("isRunning", false);
//    }
//}
//else
//{
//    anim.SetBool("isRunning", false);
//    anim.SetBool("isWalking", false);
//}
//if (Input.GetKey(KeyCode.S))
//{
//    movDirection = Vector3.forward * walkingSpeed * -1;
//    anim.SetBool("BackSide", true);
//}
//else
//{
//    anim.SetBool("BackSide", false);
//}

//if (cc.isGrounded)
//{
//    doubleJumping = false;
//    anim.SetBool("isAttack2", false);
//    anim.SetBool("isJumping", false);
//    anim.SetBool("isDoubleJump", false);

//    if (Input.GetButtonDown("Jump"))
//    {
//        directionY = jumpingForce;
//        movDirection = Vector3.forward * jumpingForce;
//        anim.SetBool("isJumping", true);
//    }

//    if (Input.GetMouseButton(0))
//    {
//        anim.SetBool("isWalking", false);
//        anim.SetBool("isAttack1", true);
//        movDirection = Vector3.zero;
//        ReferenceController.Instance.isAttack = true;
//    }
//    else
//    {
//        anim.SetBool("isAttack1", false);
//        ReferenceController.Instance.isAttack = false;
//    }
//    if (Input.GetMouseButton(1))
//    {
//        anim.SetBool("isWalking", false);
//        anim.SetBool("isDefend", true);
//        movDirection = Vector3.zero;
//    }
//    else
//    {
//        anim.SetBool("isDefend", false);
//    }


//}
//else if (!cc.isGrounded)
//{
//    if (Input.GetMouseButtonDown(0))
//    {
//        anim.SetBool("isJumping", false);
//        anim.SetBool("isAttack2", true);
//    }

//    directionY -= gravityForce * Time.deltaTime;

//    anim.SetBool("isWalking", false);

//    if (Input.GetButtonDown("Jump") && doubleJumping == false)
//    {
//        doubleJumping = true;
//        directionY = jumpingForce;
//        anim.SetBool("isDoubleJump", true);
//        movDirection = Vector3.forward * jumpingForce;
//    }

//}


