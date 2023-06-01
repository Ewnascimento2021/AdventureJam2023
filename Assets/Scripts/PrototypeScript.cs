using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeScript : MonoBehaviour
{

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
    private float timerSpeedAttack;
    [SerializeField]
    private Vector3 movDirection;


    private Animator anim;
    private CharacterController cc;
    private float rotation;
    private float directionY;
    private bool doubleJumping;
    public bool acertou;

    //state state_;
    //enum state
    //{
    //    STANDING,
    //    JUMPING,
    //    ATTACKING,
    //    DEFENDING,
    //    WALKINGFRONT,
    //}

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
      //  state_ = state.STANDING;
    }

    void Update()
    {
        handleInpet();
       
    }

    private void handleInpet()
    {
        Vector3 moviment = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movDirection = Vector3.forward * walkingSpeed;
            anim.SetBool("isWalking", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("isRunning", true);
                movDirection = Vector3.forward * runningSpeed;
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movDirection = Vector3.forward * walkingSpeed * -1;
            anim.SetBool("BackSide", true);
        }
        else
        {
            anim.SetBool("BackSide", false);
        }
   
        if (cc.isGrounded)
        {
            doubleJumping = false;
            anim.SetBool("isAttack2", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isDoubleJump", false);

            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpingForce;
                movDirection = Vector3.forward * jumpingForce;
                anim.SetBool("isJumping", true);
            }
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttack1", true);
                movDirection = Vector3.zero;
            }
            else
            {
                anim.SetBool("isAttack1", false);
            }
            if (Input.GetMouseButton(1))
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isDefend", true);
                movDirection = Vector3.zero;
            }
            else
            {
                anim.SetBool("isDefend", false);
            }


        }
        else if (!cc.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isAttack2", true);
            }

            directionY -= gravityForce * Time.deltaTime;

            anim.SetBool("isWalking", false);

            if (Input.GetButtonDown("Jump") && doubleJumping == false)
            {
                doubleJumping = true;
                directionY = jumpingForce;
                anim.SetBool("isDoubleJump", true);
                movDirection = Vector3.forward * jumpingForce;
            }

        }
        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        movDirection = transform.TransformDirection(movDirection);
        movDirection.y = directionY;
        movDirection *= Time.deltaTime;
        cc.Move(movDirection);


    }
}
