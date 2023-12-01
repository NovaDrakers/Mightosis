using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderUIScript : MonoBehaviour
{
    public GameObject HoverPrefab;
    GameObject cursor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cursor != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                cursor.transform.position = hit.point;
            }
        }
    }

    private void OnDestroy()
    {
        Destroy(cursor);
    }

    public void createHover(GameObject building)
    {
        Debug.Log("Cursor is a " + building.name);

        Destroy(cursor);
        cursor = Instantiate(HoverPrefab);

        cursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;

        StartCoroutine(PlacingBuilding(building));
    }

    IEnumerator PlacingBuilding(GameObject building)
    {
        while (!Input.GetMouseButton(0))
        {
            yield return null;
        }

        if (GameObject.Find("Nucleus").GetComponent<NucleusScript>().protein >= building.GetComponent<BuildingScript>().cost)
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                RaycastHit[] collisions = Physics.SphereCastAll(hit.point, building.GetComponent<SphereCollider>().radius, new Vector3(0, -1, 0), 20);
                bool valid = true;

                foreach (RaycastHit i in collisions)
                {
                    if (i.collider.gameObject.name != "Map")
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    GameObject temp = Instantiate(building);
                    temp.transform.position = new Vector3(cursor.transform.position.x, 0, cursor.transform.position.z);

                    GameObject.Find("Nucleus").GetComponent<NucleusScript>().protein -= building.GetComponent<BuildingScript>().cost;
                } else Debug.Log("This is not a valid location");
            }
        } else Debug.Log("Not Enough Protein");

        Destroy(cursor);
    }
}
