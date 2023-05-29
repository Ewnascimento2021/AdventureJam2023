using System.Collections;
using System.Collections.Generic;
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
    private float slerp;


    private CharacterController cc;
    private Animator anim;

    private float movRot;
    private Vector3 moveDirection;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveDirection.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        cc.Move(moveDirection * walkingSpeed * Time.deltaTime);
        cc.Move(Vector3.down * Time.deltaTime);


        if (moveDirection != Vector3.zero)
        {
            anim.SetInteger("transition", 1);
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * slerp);
        }
        else
        {
            anim.SetInteger("transition", 0);
        }


        //if (cc.isGrounded)
        //{
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        moveDirection = Vector3.forward * walkingSpeed;
        //        anim.SetInteger("transition", 1);
        //    }
        //    else //if(Input.GetKeyUp(KeyCode.W))
        //    {
        //        moveDirection = Vector3.zero;
        //        anim.SetInteger("transition", 0);
        //    }
        //}

        ////Ataque
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    anim.SetInteger("transition", 2);
        //}
        ////Defende
        //if (Input.GetKey(KeyCode.E))
        //{
        //    anim.SetInteger("transition", 3);
        //}
        ////Anda para Trás
        //if (Input.GetKey(KeyCode.S))
        //{
        //    anim.SetInteger("transition", 4);
        //}
        ////Pulo
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    anim.SetInteger("transition", 5);
        //}



        //movRot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, movRot, 0);
        //moveDirection.y -= gravity * Time.deltaTime;
        //moveDirection = transform.TransformDirection(moveDirection);
        //cc.Move(moveDirection * Time.deltaTime);
    }



}
