using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_body : MonoBehaviour
{
    public float maxHealth = 100f;
    float currentHealth;
    public Animator ani;
    bool isDead = true;
    public GameObject dieEffect;

    public healthbarScript helbar;
    void Start()
    {
        currentHealth = maxHealth;
        helbar.setMaxhealth(maxHealth);
    }


    public void takeDameP1(int d)
    {
        ani.SetTrigger("takedame");
        currentHealth -= d;
        helbar.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            ani.SetBool("isdead", isDead);
            Die();
        }
    }
    void Die()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        /*        ani.SetBool("isdead", true);
                GetComponent<Collider2D>().enabled = false;
                this.enabled = false;*/
    }
}
