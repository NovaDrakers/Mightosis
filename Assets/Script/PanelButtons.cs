//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelButtons : MonoBehaviour
{
    public GameObject Builder;
    public GameObject Nucleus;

    
   

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
            float randomAngle = Random.Range(1f, 1f * Mathf.PI);
            float xOffset = spawnDistance * Mathf.Cos(randomAngle);
            float zOffset = spawnDistance * Mathf.Sin(randomAngle);
            Instantiate(Builder, new Vector3(Nucleus.transform.position.x + xOffset, 0f, Nucleus.transform.position.z + zOffset), transform.rotation);
            Nucleus.GetComponent<NucleusScript>().protein -=  100;
            Debug.Log("builder instantiated");
        }
        
    }
}
