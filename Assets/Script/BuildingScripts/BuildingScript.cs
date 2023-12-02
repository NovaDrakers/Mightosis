using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public int cost;
    public int team;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<GlobalScript>().team = team;
        GetComponent<GlobalScript>().isAlive = true;

        GetComponent<GlobalScript>().maxHealth = 1000;
        GetComponent<GlobalScript>().type = "building";

        GetComponent<GlobalScript>().defense = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
