using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitUpgradeUIScript : MonoBehaviour
{
    public GameObject UnitUpgradeUI;

    

    public TextMeshProUGUI[] TextMeshes;

    /*
     *  
        Melee   Ranged  Tank
    HP  MHP     RHP     THP
    Def MDef    RDef    TDef
    Atk MAtk    RAtk    TAtk
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            TextMeshes[i].text = "+" + values[i].ToString() + "%";
        }
    }

    public void Close()
    {
        Destroy(UnitUpgradeUI);
    }

    public void Upgrade(int which)
    {
        
    }
}
