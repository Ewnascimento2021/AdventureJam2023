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
    private float runningSpeed;
    [SerializeField]
    private float jumpingForce;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float sensitivity;
    private Vector2 turn;
    private Vector3 deltaMove;


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
        WALKINGFRONT,
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
        cc.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * rotateSpeed * Time.deltaTime;
        cc.transform.Translate(deltaMove);
        Debug.Log(cc.isGrounded);
    }
    private void handleInput()
    {
        if (cc.isGrounded)
        {
            
            switch (state_)
            {
                case state.STANDING:
                    if (Input.GetKey(KeyCode.W))
                    {
                        state_ = state.WALKINGFRONT;
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        state_ = state.JUMPING;
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        state_ = state.JUMPING;
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        state_ = state.JUMPING;
                    }
                    else if (Input.GetKey(KeyCode.Space))
                    {
                        state_ = state.JUMPING;
                    }

                    break;

                case state.WALKINGFRONT:

                    if (Input.GetKey(KeyCode.W))
                    {
                        moveDirection = Vector3.forward * walkingSpeed;
                    }


                    else
                    {
                        moveDirection = Vector3.zero;

                    }
                    break;
                case state.JUMPING:

                    moveDirection.y = jumpingForce;
                    




                    break;

            }
           
            moveDirection = transform.TransformDirection(moveDirection);
            cc.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        
    }
}
