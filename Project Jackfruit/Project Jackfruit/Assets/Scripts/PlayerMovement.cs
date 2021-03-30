using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Speed")]
    public Vector3 jump, movement;
    public float speed;
    public float runSpeed;
    public float jumpForce = 2.0f;

    [Header("Player Actions")]
    public bool isGrounded;
    public bool isSprinting;
    public Rigidbody rb;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        
    }
    
    void OnCollisionEnter()
    {
        isGrounded = true;
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        movement = new Vector3(speed * Time.deltaTime * horizontalMovement, rb.velocity.y, rb.velocity.z);

        //*******FIXED LATER CANT SPRINT AND JUMP WITHOUT BEING SUPERMAN*******
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isSprinting == false)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        /****************************************************************************************/
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(isSprinting == true)
        {
            rb.AddForce(movement * runSpeed, ForceMode.Impulse);
        }

        rb.velocity = movement;
    }


}
