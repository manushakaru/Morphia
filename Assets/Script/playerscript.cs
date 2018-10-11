using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour {

    private float inputDirection;
    private float verticalVelocity;

    private float gravity = 30.0f;
    private float speed = 5.0f;
    private Vector3 lastMotion; 

    private bool secondJumpAvail = false;


    private Vector3 moveVector;
    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
        inputDirection = Input.GetAxis("Horizontal")*speed;
        moveVector = Vector3.zero;
        
        if (controller.isGrounded)
        {
            verticalVelocity = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = 10;
                secondJumpAvail = true;
            }

            moveVector.x = inputDirection;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (secondJumpAvail)
                {
                    verticalVelocity = 10;
                    secondJumpAvail = false;
                }
                
            }
            verticalVelocity -= gravity * Time.deltaTime;
            moveVector.x = lastMotion.x;
        }

        
        moveVector.y = verticalVelocity;

        //moveVector = new Vector3(inputDirection, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
        lastMotion = moveVector;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name);
    }

}
