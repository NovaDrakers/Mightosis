using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<GlobalScript>().maxHealth = 100 + (100 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[3] / 100);
        GetComponent<GlobalScript>().attack = 18 + (18 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[5] / 100);
        GetComponent<GlobalScript>().defense = 10 + (10 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[4] / 100);
        GetComponent<GlobalScript>().range = 5f;
    }

    void Update()
    {

    }

}
