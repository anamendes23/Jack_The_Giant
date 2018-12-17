using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;

    //[SerializeField]
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //FixedUpdate is called every other frame
    //so it's better to use when you have physics
    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(rb.velocity.x);
        //if press A, D, left, or right -> return number -1 if left, 0 if none, 1 if right
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 temp = transform.localScale;

        if(h>0) //going right
        {
            if(vel<maxVelocity)
            {
                forceX = speed;
            }
            anim.SetBool("Walk", true);
            temp.x = 1.3f;
            transform.localScale = temp;
        }
        else if (h<0) //going left
        {
            if (vel < maxVelocity)
            {
                forceX = - speed;
            }
            anim.SetBool("Walk", true);
            temp.x = -1.3f;
            transform.localScale = temp;
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        rb.AddForce(new Vector2(forceX, 0));
    }
}
