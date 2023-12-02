using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<GlobalScript>().maxHealth = 120 + (120 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[0]/100);
        GetComponent<GlobalScript>().attack = 15 + (15 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[2]/100);
        GetComponent<GlobalScript>().defense = 10 + (10 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[1] / 100);
        GetComponent<GlobalScript>().range = 1f;
    }

    void Update()
    {

    }
}
