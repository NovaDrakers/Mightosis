using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MitochondriaScript : MonoBehaviour
{
    private bool notDestroyed = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProduceAtp());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        notDestroyed = false;
    }

    IEnumerator ProduceAtp()
    {

        while(notDestroyed == true)
        {

            GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().atp += 1;

            yield return new WaitForSeconds(2f);
        }
        
    }
}
