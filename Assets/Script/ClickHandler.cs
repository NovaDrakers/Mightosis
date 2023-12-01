using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("MainUICanvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftClicked(GameObject Panel, GameObject Object)
    {
        GameObject[] TempPanels;
        TempPanels = GameObject.FindGameObjectsWithTag("TempPanel");
        foreach (GameObject panel in TempPanels)
        {
            Destroy(panel);
        }

        GameObject temp = Instantiate(Panel);
        temp.transform.SetParent(canvas.transform);
        temp.GetComponent<UIScript>().Selected = Object;
    }
}
