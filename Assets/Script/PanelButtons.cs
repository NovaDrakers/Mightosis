//using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelButtons : MonoBehaviour
{
    public GameObject Builder;
    public GameObject Nucleus;

    public int ranged = 0;
    public int melee = 0;
    public int tank = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateWorker()
    {
        float spawnDistance = 1f;
        
        if (Builder == null)
        {
            Debug.Log("builder prefab not found");
        }
        else if (Nucleus.GetComponent<NucleusScript>().protein >= 100)
        {
            float randomAngle = Random.Range(1f, 2f * Mathf.PI);
            float xOffset = spawnDistance * Mathf.Cos(randomAngle);
            float zOffset = spawnDistance * Mathf.Sin(randomAngle);
            Instantiate(Builder, new Vector3(Nucleus.transform.position.x + xOffset, 0f, Nucleus.transform.position.z + zOffset), transform.rotation);
            Nucleus.GetComponent<NucleusScript>().protein -=  100;
            Debug.Log("builder instantiated");
        }
        
    }

    public void CreateTroop(string troop)
    {
        Nucleus = GameObject.FindGameObjectWithTag("Nucleus");
        if (Nucleus.GetComponent<NucleusScript>().protein >= 100)
        {
            Nucleus.GetComponent<NucleusScript>().protein -= 100;
            switch (troop)
            {
                case "Ranged":

                    ranged++;
                    break;

                case "Melee":

                    melee++;
                    break;

                case "Tank":

                    tank++;
                    break;

                default:

                    break;
            }
        }
        Debug.Log("" + ranged +", " + melee + ", " + tank);
    }

    public void SpawnTroop()
    {

    }
}
