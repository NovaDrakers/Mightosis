using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class NucleusScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int protein;
    GameObject Panel;

    public TextMeshProUGUI ProteinText;

    public GameObject builder;

    void Start()
    {
        protein = 0;
        Panel = GameObject.Find("NucleusPanel");

        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ProteinText.text = "Protein = " + protein.ToString();
    }

    private void OnMouseDown()
    {
        if (!Panel.activeSelf)
        {
            Panel.SetActive(true);
        }
    }

    public void GiveProtein()
    {
        this.protein += 100;
    }

    public void CreateBuilder()
    {
        if(this.protein >= 100)
        {
            protein -= 100;
            Debug.Log("Created Builder");
        } else
        {
            Debug.Log("Not enough protein");
        }
    }

    public void ClosePanels()
    {
        GameObject[] TempPanels;
        TempPanels = GameObject.FindGameObjectsWithTag("TempPanel");
        foreach (GameObject panel in TempPanels)
        {
            panel.SetActive(false);
        }
    }
}
