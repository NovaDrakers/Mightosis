using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GolgiScript : MonoBehaviour
{
    public GameObject PanelPrefab;

    public int ranged = 0;
    public int melee = 0;
    public int tank = 0;

    public float spawnDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseDown()
    {
        GetComponent<ClickHandler>().LeftClicked(PanelPrefab, gameObject);
    }
}
