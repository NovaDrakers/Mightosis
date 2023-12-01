using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    Slider slider;
    int maxhealth;
    public Quaternion rotation;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = gameObject.GetComponentInParent<GlobalScript>().maxHealth;

        //offset = new Vector3(-.05f, 0f, -0.33f);
        rotation = GetComponentInParent<Transform>().rotation;
    }

    private void Update()
    {
        slider.value = gameObject.GetComponentInParent<GlobalScript>().health;

        transform.localRotation = rotation;
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;  
    }
}
