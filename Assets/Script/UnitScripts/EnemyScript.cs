using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<GlobalScript>().maxHealth = 120;
        GetComponent<GlobalScript>().attack = 15;
        GetComponent<GlobalScript>().defense = 10;

        GetComponent<GlobalScript>().range = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
