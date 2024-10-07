using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update(){

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        rb.velocity = Vector2.zero;

        if(Input.GetKey(KeyCode.LeftShift) && (movement.x != 0 || movement.y != 0)){
            moveSpeed = 6f;
            animator.SetBool("isRunning", true);
        }else{
            moveSpeed = 3f;
            animator.SetBool("isRunning", false);
        }
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
