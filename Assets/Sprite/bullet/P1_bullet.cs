using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class P1_bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public Animator ani;
    public GameObject affectShoot;
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        P3_body body = collision.GetComponent<P3_body>();
        if (body != null) { 
            body.GetComponent<P3_body>().takeDameP3(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "matdat"|| collision.gameObject.tag =="wall")
        {

            Instantiate(affectShoot, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }

}
