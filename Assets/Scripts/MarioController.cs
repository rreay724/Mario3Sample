using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{

    public float characterSpeed = 3.0f;


    Rigidbody2D rigidBody2d;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); 
        vertical = Input.GetAxis("Vertical");


        Vector2 move = new Vector2(horizontal,vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("LookX", lookDirection.x);

        animator.SetFloat("Speed", move.magnitude);
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidBody2d.position;
        position.x = position.x + characterSpeed * horizontal * Time.deltaTime;
        position.y = position.y + characterSpeed * vertical * Time.deltaTime;

        rigidBody2d.MovePosition(position);
    }

  

}

