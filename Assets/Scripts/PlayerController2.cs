using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {
    public float runningSpeed = 5;
    public float jumpForce = 10;
    Rigidbody rb;


    Collider col;
    Vector3 direction;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();

        direction = Vector3.forward;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        rb.velocity = new Vector3(direction.x * runningSpeed, rb.velocity.y, direction.z * runningSpeed);

        //listen for user input 
        if(Input.GetButtonDown("Fire1")) {

            //make the player jump
            Jump();
        }

	}

    private void Jump()
    {
        // check we are on the ground



        // add a force to jump

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool isGrounded() {

        // get height of player

        float SizyY = col.bounds.size.y;

        return Physics.Raycast(transform.position, Vector3.down, SizyY / 2);


    }
}
