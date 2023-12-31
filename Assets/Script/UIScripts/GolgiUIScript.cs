using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GolgiUIScript : MonoBehaviour
{
    public GameObject Selected;
    Vector3 SelectedPosition;

    public GameObject Ranged;
    public GameObject Melee;
    public GameObject Tank;

    public GameObject UpgradePanel;

    GameObject Nucleus;

    int ranged = 0;
    int melee = 0;
    int tank = 0;

    public TextMeshProUGUI ProteinText;

    // Start is called before the first frame update
    void Start()
    {
        Nucleus = GameObject.FindGameObjectWithTag("Nucleus");
        Selected = GetComponent<UIScript>().Selected;


        SelectedPosition = Selected.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Selected != null)
        {
            ranged = Selected.GetComponent<GolgiScript>().ranged;
            melee = Selected.GetComponent<GolgiScript>().melee;
            tank = Selected.GetComponent<GolgiScript>().tank;
        }
    }

    public void openUpgrades()
    {
        Debug.Log("opened");
        Instantiate(UpgradePanel, GameObject.Find("MainUICanvas").transform);
    }

    public void CreateTroop(string troop)
    {
        Nucleus = GameObject.Find("Nucleus");

        if (GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().population < GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().maxPopulation)
        {
            if (Nucleus.GetComponent<NucleusScript>().protein >= 100)
            {
                Nucleus.GetComponent<NucleusScript>().protein -= 100;
                switch (troop)
                {
                    case "Ranged":

                        Selected.GetComponent<GolgiScript>().ranged++;
                        break;

                    case "Melee":

                        Selected.GetComponent<GolgiScript>().melee++;
                        break;

                    case "Tank":

                        Selected.GetComponent<GolgiScript>().tank++;
                        break;

                    default:

                        break;
                }
                GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().population++;
            }
            else
            {
                GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().Error("You do not have enough Protein");
            }
        }
        else
        {
            Debug.Log("Population is at Maximum");
            GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().Error("Population is at Maximum");
        }
            
            


        Debug.Log("" + ranged + ", " + melee + ", " + tank);

        
    }

    public void SpawnTroop(string troop)
    {
        float randomAngle = Random.Range(1f, 2f * Mathf.PI);
        float xOffset = Selected.GetComponent<GolgiScript>().spawnDistance * Mathf.Cos(randomAngle);
        float zOffset = Selected.GetComponent<GolgiScript>().spawnDistance * Mathf.Sin(randomAngle);


        switch (troop)
        {
            case "Ranged":

                if (ranged > 0)
                {

                    Instantiate(Ranged, new Vector3(SelectedPosition.x + xOffset, SelectedPosition.y, SelectedPosition.z + zOffset), Selected.transform.rotation);


                    Selected.GetComponent<GolgiScript>().ranged--;
                }
                break;

            case "Melee":

                if (melee > 0)
                {
                    Instantiate(Melee, new Vector3(SelectedPosition.x + xOffset, SelectedPosition.y, SelectedPosition.z + zOffset), Selected.transform.rotation);

                    Selected.GetComponent<GolgiScript>().melee--;
                }
                break;

            case "Tank":

                if (tank > 0)
                {
                    Instantiate(Tank, new Vector3(SelectedPosition.x + xOffset, SelectedPosition.y, SelectedPosition.z + zOffset), Selected.transform.rotation);

                    Selected.GetComponent<GolgiScript>().tank--;
                }
                break;

            default:

                break;
        }

    }

  
}
