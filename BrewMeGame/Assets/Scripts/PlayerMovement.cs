using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public float speed;
    private Vector3 change;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerAnimations();
        
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }


    private void PlayerAnimations()
    {
        if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") > 0) // Up
        {
            anim.SetFloat("moveY", 1);
        }
        else if (Input.GetButton("Vertical") && Input.GetAxisRaw("Vertical") < 0) //Down
        {
            anim.SetFloat("moveY", -1);
        }
        else
        {
            anim.SetFloat("moveY", 0);
        }
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0) // Right
        {
            anim.SetFloat("moveX", 1);
        }
        else if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0) // Right
        {
            anim.SetFloat("moveX", -1);
        }
        else
        {
            anim.SetFloat("moveX", 0);
        }
    }

    private void PlayerMove()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.z = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            PlayerMoveRB();
        }
    }
    private void PlayerMoveRB()
    {
        change.Normalize();
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
