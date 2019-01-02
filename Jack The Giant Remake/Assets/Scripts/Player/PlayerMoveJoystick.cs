using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;

    //[SerializeField]
    private Rigidbody2D rb;
    private Animator anim;

    private bool moveLeft, moveRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (moveLeft)
            MoveLeft();

        if(moveRight)
            MoveRight();
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("Walk", false);
    }

    void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(rb.velocity.x);

        Vector3 temp = transform.localScale;

        if (vel < maxVelocity)
        {
            forceX = -speed;
        }
        anim.SetBool("Walk", true);
        temp.x = -1.3f;
        transform.localScale = temp;

        rb.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(rb.velocity.x);

        Vector3 temp = transform.localScale;

        if (vel < maxVelocity)
        {
            forceX = speed;
        }
        anim.SetBool("Walk", true);
        temp.x = 1.3f;
        transform.localScale = temp;

        rb.AddForce(new Vector2(forceX, 0));
    }
}//PlayerMoveJoystick
