using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    Slider slider;
    int maxhealth;
    public Vector3 offset;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = gameObject.GetComponentInParent<UnitScript>().maxHealth;

        offset = new Vector3(-.05f, 0f, -0.33f);
    }

    private void Update()
    {
        slider.value = gameObject.GetComponentInParent<UnitScript>().currentHealth;

        transform.localPosition = offset;
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
