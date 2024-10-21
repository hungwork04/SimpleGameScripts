using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator ani;
    public float runSpeed = 5f;
    public float jumpHeight = 5f;
    public GameObject body;

    public body_p1 bd1;

    public KeyCode right;
    public KeyCode left;
    public KeyCode up;
    public KeyCode down;

    public bool facingRight;
    public Transform parentObj;
    bool ground=true;
    public int jumpTime = 2;
    private int currentJumpTime;
    /*    private bool doubleJump = false;*/
    void Start()
    {
/*        parentObj = transform.parent;*/
        currentJumpTime = jumpTime;
    }
    void Update()
    {

        //di chuyen
        if (Input.GetKey(right)) { 
            rb.velocity = new Vector2(runSpeed,rb.velocity.y);
            
        }
        else if (Input.GetKey(left)) { 
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
        }
        else { 
            rb.velocity = new Vector2(0, rb.velocity.y);}

        if (Input.GetKeyDown(up) && (ground == true || currentJumpTime>0))
        {
            ground = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            bd1.ani.SetBool("isjumping", !ground);
            /*            doubleJump = !doubleJump;*/
            currentJumpTime--;
        }



        if (Input.GetKeyDown(right) && facingRight ==false)
        {
            /* theScale.x *= -1;
            transform.localScale = theScale;*/
            facingRight = true;
            body.transform.Rotate(0f, 180f, 0f);
        }
        if(Input.GetKeyDown(left) && facingRight==true)
        {
            /*            theScale.x *= -1;
                        transform.localScale = theScale;*/ 
            facingRight =false;
            body.transform.Rotate(0f, 180f, 0f);

        }


        bd1.ani.SetFloat("xvelocity",Mathf.Abs(rb.velocity.x));
        bd1.ani.SetFloat("yvelocity", rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "matdat")
        {
            ground = true;
            bd1.ani.SetBool("isjumping", !ground);
            currentJumpTime = jumpTime;
        }
        
    }
}
