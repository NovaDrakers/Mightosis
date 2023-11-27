using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MitochondriaScript : MonoBehaviour
{

    public int ATP;

    public GameObject panel;
    public TextMeshProUGUI[] atpText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var atp in atpText)
        {
            atp.text = "ATP:  " + ATP.ToString();
        }
    }
}
