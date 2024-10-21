using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WP : MonoBehaviour
{
    public Transform atkPoint;
    public GameObject bullet;
/*    public Rigidbody2D rb;*/
    public Animator ani;
    public KeyCode atk;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(atk))
        {
            Shoot();
            ani.SetTrigger("shoot");
        }
        else
            ani.SetBool("shooting", false);
    }
    void Shoot()
    {
        Instantiate(bullet, atkPoint.position,atkPoint.rotation);
    }
}
