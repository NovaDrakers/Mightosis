using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.EventSystems;

public class NucleusScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int protein;
    public int health;
    GameObject Panel;
    Canvas canvas;

    public TextMeshProUGUI ProteinText;

    public GameObject builder;

    void Start()
    {
        protein = 0;
        Panel = GameObject.Find("NucleusPanel");
        canvas = GameObject.FindAnyObjectByType<Canvas>();

        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ProteinText.text = "Protein = " + protein.ToString();
        

        //handling of game lose
        if(health == 0)
        {
            GameManager.Instance.UpdateGameState(GameState.SceneLose);
        }

    }

    private void OnMouseDown()
    {
        if (!Panel.activeSelf)
        {
            Transform canvasTransform = canvas.transform;

            // Iterate through all the children of the Canvas
            for (int i = 0; i < canvasTransform.childCount; i++)
            {
                // Access each child using the getChild method
                Transform child = canvasTransform.GetChild(i);

                child.gameObject.SetActive(false);
            }
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
