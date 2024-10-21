using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healthbarScript : MonoBehaviour
{
    public Slider slider;
/*    Quaternion r;*/
/*    private void Start()
    {
        r= transform.localRotation;
    }*/
    public void setMaxhealth(float health)
    {
        slider.maxValue= health;
        slider.value= health;
    }
    public void setHealth(float health)
    {
        slider.value = health;
    }
/*    private void Update()
    {
        transform.rotation= r;
    }*/
}
