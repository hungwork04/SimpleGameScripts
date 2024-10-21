using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTele : MonoBehaviour
{
    private GameObject currentTeleport;
    public KeyCode teleKey;
    public float nextTimePress=0;
    private void Update()
    {
        if (Time.time > nextTimePress)
        {
            if (Input.GetKeyDown(teleKey))
            {
                if (currentTeleport != null)
                {
                    transform.position = currentTeleport.GetComponent<Teleport>().getDestination().position;
                    nextTimePress = Time.time+5.5f;
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "teleport")
        {
            currentTeleport = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "teleport")
        {
            if (collision.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
        }
    }
}
