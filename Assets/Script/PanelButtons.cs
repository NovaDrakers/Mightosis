//using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelButtons : MonoBehaviour
{
    public GameObject Builder;
    public GameObject Ranged;
    public GameObject Melee;
    public GameObject Tank;

    public GameObject Nucleus;
    public GameObject Golgi;

    public int ranged = 0;
    public int melee = 0;
    public int tank = 0;
    float spawnDistance = 1f;


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
        Nucleus = GameObject.FindGameObjectWithTag("Nucleus");
        
        
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

    public void SpawnTroop(string troop)
    {
        Golgi = GameObject.FindGameObjectWithTag("Golgi");
        float randomAngle = Random.Range(1f, 2f * Mathf.PI);
        float xOffset = spawnDistance * Mathf.Cos(randomAngle);
        float zOffset = spawnDistance * Mathf.Sin(randomAngle);

        switch (troop)
        {
            case "Ranged":

                if (ranged > 0)
                {
                   Instantiate(Ranged, new Vector3(Golgi.transform.position.x + xOffset, 0f, Golgi.transform.position.z + zOffset), transform.rotation);
                   ranged--;
                }
                break;

            case "Melee":

                if (melee > 0)
                {
                    Instantiate(Melee, new Vector3(Golgi.transform.position.x + xOffset, 0f, Golgi.transform.position.z + zOffset), transform.rotation);
                    melee--;
                }
                break;

            case "Tank":

                if (tank > 0)
                {
                    Instantiate(Tank, new Vector3(Golgi.transform.position.x + xOffset, 0f, Golgi.transform.position.z + zOffset), transform.rotation);
                    tank--;
                }
                break;

            default:

                break;
        }

    }
}
