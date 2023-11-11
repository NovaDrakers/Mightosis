using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManagerScript : MonoBehaviour
{
    GameObject selected;
    GameObject outline;

    public GameObject OutlinePrefab;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(outline);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                selected = hit.collider.gameObject;
                outline = Instantiate(OutlinePrefab, selected.transform.position, Quaternion.Euler(90,0,0), selected.transform);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (selected.GetComponent<BuilderScript>() != null)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    selected.GetComponent<BuilderScript>().target = hit.collider.gameObject;

                    if (!selected.GetComponent<BuilderScript>().arrived) selected.GetComponent<NavMeshAgent>().isStopped = false;
                }
            }


        }
    }

    
}
