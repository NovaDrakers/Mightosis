using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerManagerScript : MonoBehaviour
{
    GameObject selected;
    List<GameObject> outline = new List<GameObject>();

    List<GameObject> selecteds = new List<GameObject>();

    public GameObject OutlinePrefab;

    Vector3 mousePositionDown;
    Vector3 mousePosition;

    public Camera viewCam;

    public RectTransform Selector;

    [SerializeField] CanvasScaler canvasScaler = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePositionDown = Input.mousePosition;

            foreach (GameObject i in outline)
            {
                Destroy(i);
            }
            outline = new List<GameObject>();
            selecteds = new List<GameObject>();
        }

        if (Input.GetMouseButton(0) && mousePositionDown != Input.mousePosition)
        {
            if (!Selector.gameObject.activeInHierarchy) Selector.gameObject.SetActive(true);


            float width = Input.mousePosition.x - mousePositionDown.x;
            float height = Input.mousePosition.y - mousePositionDown.y;

            Selector.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
            Selector.anchoredPosition = (new Vector2(mousePositionDown.x, mousePositionDown.y) + new Vector2(width/2, height/2)) / canvasScaler.transform.localScale;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Selector.gameObject.SetActive(false);

            if (Input.mousePosition == mousePositionDown)
            {

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    selecteds.Add(hit.collider.gameObject);
                }
            }
            else
            {
                Vector2 min = Selector.anchoredPosition - (Selector.sizeDelta / 2);
                Vector2 max = Selector.anchoredPosition + (Selector.sizeDelta / 2);

                foreach (GameObject i in GameObject.FindGameObjectsWithTag("Unit"))
                {

                    Vector3 screenPos = viewCam.WorldToScreenPoint(i.transform.position);

                    if(screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y)
                    {
                        selecteds.Add(i);
                    }
                } 
            }

            foreach (GameObject i in selecteds)
            {
                outline.Add(Instantiate(OutlinePrefab, i.transform.position, Quaternion.Euler(90, 0, 0), i.transform));
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                foreach (GameObject i in selecteds)
                {
                    i.GetComponent<BuilderScript>().target = hit.collider.gameObject;
                    if (!i.GetComponent<BuilderScript>().arrived) i.GetComponent<NavMeshAgent>().isStopped = false;
                }
            }
        }
    }
}
