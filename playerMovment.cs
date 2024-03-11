using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    Rigidbody2D rig;

    Animator anim;

    SpriteRenderer sprite;

   BoxCollider2D coll;

    

    

    [SerializeField] LayerMask groundjump;

    [SerializeField] AudioSource jumpsfx;


    float dirX = 0;

    enum movement {idle,running,jumping,falling};


    [SerializeField]float jumpforce = 14f;

    [SerializeField]float speed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();

        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    public void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(dirX * speed, rig.velocity.y);


        movement state;


        if (dirX > 0.1f)
        {
            state = movement.running;

            sprite.flipX = false;
        }
        else if (dirX < -0.1f)
        {

            state = movement.running;

            sprite.flipX = true;

        }
        else
        {

            state = movement.idle;
        }

        if (rig.velocity.y > 0f)
        {
            state = movement.jumping;
        }
        else if (rig.velocity.y < 0f)
        {
            state = movement.falling;
        }

        anim.SetInteger("state", (int)state);


       if (Input.GetButtonDown("Jump") && Groundcheck())
        {
            jumpsfx.Play();
            rig.velocity = new Vector2(rig.velocity.x, jumpforce);
        }





    }

    




    public  bool Groundcheck()
    {
     return  Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f,Vector2.down,1f,groundjump);
    }
}