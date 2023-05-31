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
       
        if (cc.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                movDirection.y = jumpingForce;
            }
            if (Input.GetKey(KeyCode.W))
            {
                movDirection = Vector3.forward * walkingSpeed;
            }
        }
        else if (!cc.isGrounded)
        {
            movDirection.y -= gravityForce * Time.deltaTime;
        }


        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);
        //moviment = transform.TransformDirection(moviment);
        moviment.y = movDirection.y;
        moviment *= Time.deltaTime;
        cc.Move(moviment);
        

    }
}
