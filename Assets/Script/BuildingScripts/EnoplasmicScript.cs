using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnoplasmicScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().maxPopulation += 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
