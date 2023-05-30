using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkingSpeed;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float rotSpeed;
    [SerializeField]
    private Vector2 turn;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private Vector3 deltaMove;
    [SerializeField]
    private float rotateSpeed;


    private float movRot;

    private CharacterController cc;
    private Animator anim;
    private Vector3 moveDirection;


    state state_;
    enum state
    {
        STANDING,
        JUMPING,
        ATTACKING,
        DEFENDING,
        WALKING,
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        state_ = state.STANDING;
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        handleInput();
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        cc.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        // transform.localRotation = Quaternion.Euler(-turn.x, 0, 0);

        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * rotateSpeed * Time.deltaTime;
        cc.transform.Translate(deltaMove);

        //if (turn.x > 0)
        //{
        //    anim.SetBool("RightSide", true);
        //}
        //else if (turn.x < 0)
        //{
        //    anim.SetBool("LeftSide", true);
        //}
    }
    private void handleInput()
    {
        switch (state_)
        {
            case state.STANDING:
                if (moveDirection != Vector3.zero)
                {
                    state_ = state.WALKING;
                }
                break;

            case state.WALKING:

                if (Input.GetKey(KeyCode.W))
                {
                    moveDirection = Vector3.forward * walkingSpeed;
                    anim.SetBool("Walk", true);
                    anim.SetBool("RightSide", false);
                    anim.SetBool("LeftSide", false);
                    anim.SetBool("BackSide", false);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    moveDirection = Vector3.forward * walkingSpeed * -1;
                    anim.SetBool("Walk", false);
                    anim.SetBool("RightSide", false);
                    anim.SetBool("LeftSide", false);
                    anim.SetBool("BackSide", true);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    moveDirection = Vector3.right * walkingSpeed;
                    anim.SetBool("Walk", false);
                    anim.SetBool("BackSide", false);
                    anim.SetBool("LeftSide", false);
                    anim.SetBool("RightSide", true);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    moveDirection = Vector3.right * walkingSpeed * -1;
                    anim.SetBool("Walk", false);
                    anim.SetBool("BackSide", false);
                    anim.SetBool("RightSide", false);
                    anim.SetBool("LeftSide", true);
                }
                else
                {
                    moveDirection = Vector3.zero;
                    anim.SetBool("Walk", false);
                    anim.SetBool("RightSide", false);
                    anim.SetBool("LeftSide", false);
                    anim.SetBool("BackSide", false);
                    state_ = state.STANDING;
                }
                break;
        }

        //movRot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, movRot, 0);
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        cc.Move(moveDirection * Time.deltaTime);

        //moveDirection.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //cc.Move(moveDirection * walkingSpeed * Time.deltaTime);
        //cc.Move(Vector3.down * Time.deltaTime);

    }


}
//private void Move()

//{
//    if (cc.isGrounded)
//    {
//        if (Input.GetKey(KeyCode.W))
//        {
//            moveDirection = Vector3.forward * walkingSpeed;
//            anim.SetInteger("transition", 1);
//        }
//        else if (Input.GetKey(KeyCode.S))
//        {
//            moveDirection = Vector3.forward * walkingSpeed * -1;
//            anim.SetInteger("transition", 1);
//        }
//        else //if(Input.GetKeyUp(KeyCode.W))
//        {
//            moveDirection = Vector3.zero;
//            anim.SetInteger("transition", 0);
//        }
//    }




//    //Ataque
//    if (Input.GetKey(KeyCode.Q))
//    {
//        anim.SetInteger("transition", 2);
//    }
//    //Defende
//    if (Input.GetKey(KeyCode.E))
//    {
//        anim.SetInteger("transition", 3);
//    }
//    //Anda para Trás
//    if (Input.GetKey(KeyCode.S))
//    {
//        anim.SetInteger("transition", 4);
//    }
//    //Pulo
//    if (Input.GetKey(KeyCode.Space))
//    {
//        anim.SetInteger("transition", 5);
//    }





//    


//    if (moveDirection != Vector3.zero)
//    {
//        anim.SetInteger("transition", 1);
//        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * slerp);
//    }
//    else
//    {
//        anim.SetInteger("transition", 0);
//    }