using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GolgiScript : MonoBehaviour
{
    public GameObject Panel;
    Canvas canvas;

    public GameObject Nucleus;

    public int ranged = 0;
    public int melee = 0;
    public int tank = 0;

    public TextMeshProUGUI ProteinText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        Debug.Log("" + ranged + ", " + melee + ", " + tank);
    }

    public float spawnDistance = 1f;

    public GameObject Ranged;
    public GameObject Melee;
    public GameObject Tank;

    public void SpawnTroop(string troop)
    {
        float randomAngle = Random.Range(1f, 2f * Mathf.PI);
        float xOffset = spawnDistance * Mathf.Cos(randomAngle);
        float zOffset = spawnDistance * Mathf.Sin(randomAngle);


        switch (troop)
        {
            case "Ranged":

                if (ranged > 0)
                {
                    
                    Instantiate(Ranged, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset), transform.rotation);
                   

                    ranged--;
                }
                break;

            case "Melee":

                if (melee > 0)
                {
                    Instantiate(Melee, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset), transform.rotation);
                    
                    melee--;
                }
                break;

            case "Tank":

                if (tank > 0)
                {
                    Instantiate(Tank, new Vector3(transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset), transform.rotation);
                    
                    tank--;
                }
                break;

            default:

                break;
        }

    }


    private void OnMouseDown()
    {
        GetComponent<ClickHandler>().LeftClicked(Panel);
    }


}
