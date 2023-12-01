using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemyScript : MonoBehaviour
{
    public GameObject Melee, Ranged, Tank;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FIGHTME());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FIGHTME()
    {
        
        
        yield return null;
    }
}
