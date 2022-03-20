using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    public float moveSpeed;
 //   public Rigidbody theRB; 
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
       // theRB = GetComponent<Rigidbody>();
    }
    void Update()
    {
       /* theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
    
        if(Input.GetButtonDown("Jump"))
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
        }*/

     //   moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        if(controller.isGrounded)
        {
            moveDirection.y = 0f;
            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        moveDirection.y = moveDirection.y + Physics.gravity.y * Time.deltaTime * gravityScale;
        controller.Move(moveDirection * Time.deltaTime);

        if (moveDirection.x != 0 && moveDirection.z != 0)
        {
            animator.SetBool("IsMoving", true);
            //Debug.Log(moveDirection);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    

}
