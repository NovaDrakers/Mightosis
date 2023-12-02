using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    private void Start()
    {
        GetComponent<GlobalScript>().maxHealth =  150 + (150 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[6] / 100);
        GetComponent<GlobalScript>().attack = 12 + (12 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[8] / 100);
        GetComponent<GlobalScript>().defense = 10 + (10 * GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().upgradeValues[7] / 100);
        GetComponent<GlobalScript>().range = 1f;
    }

    void Update()
    {

    }
}
