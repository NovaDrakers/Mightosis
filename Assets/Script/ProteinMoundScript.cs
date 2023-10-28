using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProteinMoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int protein = 1000;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.protein <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
