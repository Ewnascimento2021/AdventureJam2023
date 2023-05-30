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
    private float rotateSpeed;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private Vector2 turn;
    [SerializeField]
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

        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * rotateSpeed * Time.deltaTime;
        cc.transform.Translate(deltaMove);

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
        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        cc.Move(moveDirection * Time.deltaTime);
    }
}
