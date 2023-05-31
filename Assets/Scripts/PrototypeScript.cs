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
    private Vector3 movDirection;


    private Animator anim;
    private CharacterController cc;
    private float rotation;
    private float directionY;
    private bool doubleJumping;

    state state_;
    enum state
    {
        STANDING,
        JUMPING,
        ATTACKING,
        DEFENDING,
        WALKINGFRONT,
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        state_ = state.STANDING;
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
        }
        if (Input.GetKey(KeyCode.S))
        {
            movDirection = Vector3.forward * walkingSpeed * -1;
        }
        if (cc.isGrounded)
        {
            doubleJumping = false;

            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpingForce;
                movDirection = Vector3.forward * jumpingForce;
            }
        }
        else if (!cc.isGrounded)
        {
            directionY -= gravityForce * Time.deltaTime;

            if (Input.GetButtonDown("Jump") && doubleJumping == false)
            {
                doubleJumping = true;
                directionY = jumpingForce;
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
