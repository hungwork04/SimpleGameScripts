using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3_apple : MonoBehaviour
{
    public float speed=13;
    public int dame = 10;
    public Rigidbody2D rb1;
    public Animator ani;
    public GameObject appleEffect;
    public int life = 3;
    Vector3 lastVelocity;

    public Transform atkPoint;
    public float atkRange;
    public LayerMask enemyLayer;

    void Start()
    {
        rb1.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity= rb1.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        life--;
        if (collision.gameObject.tag != "player")
        {
            if (life < 0)
            {
                Collider2D[] hitenems = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemyLayer);
                foreach (Collider2D e in hitenems)
                {
                    e.GetComponent<P1_body>().takeDameP1(10);

                }
            }
        }


        P1_body bd= collision.gameObject.GetComponent<P1_body>();
        if (bd != null)
        {
            bd.GetComponent<P1_body>().takeDameP1(dame);
            
            Instantiate(appleEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        var Speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb1.velocity= direction * Speed;

        if(collision.gameObject.tag == "player"||life<0)
        {
            Instantiate(appleEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (atkPoint == null)
            return;
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }
}
