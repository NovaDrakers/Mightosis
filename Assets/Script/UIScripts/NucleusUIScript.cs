using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleusUIScript : MonoBehaviour
{
    float spawnDistance;
    public GameObject Builder;
    GameObject Nucleus;
    Vector3 NucleusPosition;

    // Start is called before the first frame update
    void Start()
    {
        Nucleus = GameObject.Find("Nucleus");
        NucleusPosition = Nucleus.transform.position;
        spawnDistance = Nucleus.GetComponent<NucleusScript>().spawnDistance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public void GiveProtein()
    {
        GameObject.Find("Nucleus").GetComponent<NucleusScript>().protein += 100;
    }*/

    public void CreateWorker()
    {
        if (Builder == null)
        {
            Debug.Log("builder prefab not found");
        }
        else if (GameObject.Find("Nucleus").GetComponent<NucleusScript>().protein >= 100 && (GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().population < GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().maxPopulation))
        {
            float randomAngle = Random.Range(1f, 2f * Mathf.PI);
            float xOffset = spawnDistance * Mathf.Cos(randomAngle);
            float zOffset = spawnDistance * Mathf.Sin(randomAngle);

            Instantiate(Builder, new Vector3(NucleusPosition.x + xOffset, 0f, NucleusPosition.z + zOffset), Nucleus.transform.rotation);

            GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().population++;

            GameObject.Find("Nucleus").GetComponent<NucleusScript>().protein -=  100;
            Debug.Log("builder instantiated");
        }

    }
}
