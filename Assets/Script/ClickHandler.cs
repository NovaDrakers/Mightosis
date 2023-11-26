using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftClicked(GameObject Panel)
    {
        if (!Panel.activeSelf)
        {
            if (!Panel.activeSelf)
            {
                GameObject[] TempPanels;
                TempPanels = GameObject.FindGameObjectsWithTag("TempPanel");
                foreach (GameObject panel in TempPanels)
                {
                    panel.SetActive(false);
                }
                Panel.SetActive(true);
            }
        }
    }
}
