using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /***
        @desc Responsible for the movement of the player
        @param speed - scale of speed player movement
        @param rb - RigidBody2D of the player
         */


    public float speed = 2.0f;
    public Rigidbody2D rb;
    public Animator anim;

    private Vector3 movement = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this);
        Debug.Log(gameObject);
    }

    // Update is called once per frame
    void Update()
    {


        movement = CalculateMovement();
        Move();
    }

    Vector3 CalculateMovement()
    {
        Vector3 result = new Vector3(0f, 0f, 0f);

        // Keyevents to determine player moment
        bool holdLeft = Input.GetKey("a");
        bool holdRight = Input.GetKey("d");

        bool holdUp = Input.GetKey("w");
        bool holdDown = Input.GetKey("s");

        // Adjusted speed
        float aSpeed = speed;

        // Sprint
        if (Input.GetKey(KeyCode.LeftShift)) aSpeed *= 2f;

        // Player movement

        if (holdLeft && !holdRight)
        {
            result -= new Vector3(aSpeed, 0f, 0f);
        }
        else if (holdRight && !holdLeft)
        {
            result += new Vector3(aSpeed, 0f, 0f);
        }

        if (holdUp && !holdDown)
        {
            result += new Vector3(0f, aSpeed, 0f);
        }
        else if (!holdUp && holdDown)
        {
            result -= new Vector3(0f, aSpeed, 0f);
        }

        return result;
    }

    void Move()
    {
        // Adjusts the condition "Horizontal" float value to play certain animations
        anim.SetFloat("Horizontal", movement.x); 
        rb.velocity = new Vector2(movement.x, movement.y);
    }


}
