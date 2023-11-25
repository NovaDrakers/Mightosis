using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GolgiScript : MonoBehaviour
{
    GameObject Panel;
    Canvas canvas;

    public TextMeshProUGUI ProteinText;

    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("GolgiPanel");
        canvas = GameObject.FindAnyObjectByType<Canvas>(); 


        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
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
            Panel.SetActive(true);
        }
    }

    
}
