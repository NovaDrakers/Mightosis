using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManagerScript : MonoBehaviour
{
    GameObject selected;
    List<GameObject> outline = new List<GameObject>();

    List<GameObject> selecteds = new List<GameObject>();

    List<GameObject> healthBars = new List<GameObject>();

    public GameObject OutlinePrefab;
    public GameObject HealthBarPrefab;

    Vector3 mousePositionDown;
    Vector3 mousePosition;

    public Camera viewCam;

    public RectTransform Selector;

    //for player ui --------------------------------
    public int atp;
    public int protein;
    public float population = 0f;
    public int timer;
    public float maxPopulation = 5f;

    public TextMeshProUGUI atpText;
    public TextMeshProUGUI proteinText;
    public TextMeshProUGUI populationText;
    public TextMeshProUGUI timerText;
    // --------------------------------------------------

    public float[] upgradeValues = new float[9];

    public GameObject ErrorMessage;

    public void Error(string message)
    {
        GameObject temp = Instantiate(ErrorMessage, GameObject.Find("MainUICanvas").transform);
        temp.GetComponent<TextMeshProUGUI>().text = message;

        Destroy(temp,1.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            upgradeValues[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePositionDown = Input.mousePosition;

            foreach (GameObject i in outline)
            {
                Destroy(i);
            }
            foreach (GameObject i in healthBars)
            {
                Destroy(i);
            }
            outline = new List<GameObject>();
            selecteds = new List<GameObject>();
            healthBars = new List<GameObject>();
        }

        if (Input.GetMouseButton(0) && mousePositionDown != Input.mousePosition)
        {
            if (!Selector.gameObject.activeInHierarchy) Selector.gameObject.SetActive(true);


            float width = Input.mousePosition.x - mousePositionDown.x;
            float height = Input.mousePosition.y - mousePositionDown.y;

            Selector.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
            Selector.anchoredPosition = new Vector2(mousePositionDown.x, mousePositionDown.y) + new Vector2(width/2, height/2);
                //+ 0(new Vector2(width/2, height/2)) / canvasScaler.transform.localScale);
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
                    if(hit.collider.gameObject.GetComponent<GlobalScript>()!=null && hit.collider.gameObject.GetComponent<GlobalScript>().team == 0) selecteds.Add(hit.collider.gameObject);
                }
            }
            else
            {
                Vector2 min = Selector.anchoredPosition - (Selector.sizeDelta / 2);
                Vector2 max = Selector.anchoredPosition + (Selector.sizeDelta / 2);

                foreach (GameObject i in GameObject.FindGameObjectsWithTag("Unit"))
                {

                    Vector3 screenPos = viewCam.WorldToScreenPoint(i.transform.position);

                    if(screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y && i.GetComponent<UnitScript>().team == 0)
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
                    i.GetComponent<UnitScript>().newTarget(hit);
                }
            }
        }

        //Player UI --------------------------------------------------------------------------------------------
        atpText.text = "ATP: " + atp.ToString();

        GameObject nucleus = GameObject.Find("Nucleus");

        proteinText.text = "Protein: " + nucleus.GetComponent<NucleusScript>().protein.ToString();
        populationText.text = "Population: " + population.ToString() + "/" + maxPopulation.ToString();
        timerText.text = Time.timeSinceLevelLoad.ToString();
        //-------------------------------------------------------------------------------------------------------
    }
}

