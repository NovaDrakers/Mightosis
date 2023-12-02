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



    public void CreateTroop(string troop)
    {
        Nucleus = GameObject.Find("Nucleus");
        if (Nucleus.GetComponent<NucleusScript>().protein >= 100 && GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().population != GameObject.Find("PlayerMangaer").GetComponent<PlayerManagerScript>().maxPopulation)
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
        }
        Debug.Log("" + ranged + ", " + melee + ", " + tank);

        GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().population++;
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
