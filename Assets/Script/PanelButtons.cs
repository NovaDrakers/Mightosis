//using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePanel()
    {
        GameObject[] TempPanels;
        TempPanels = GameObject.FindGameObjectsWithTag("TempPanel");
        foreach (GameObject panel in TempPanels)
        {
            panel.SetActive(false);
        }
    }

    
}
