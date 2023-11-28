using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class NucleusScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int protein;
    public int health;
    public GameObject Panel;

    public TextMeshProUGUI[] ProteinText;

    public GameObject Builder;

    public float spawnDistance = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var p in ProteinText)
        {
            p.text = "Protein = " + protein.ToString();
        }
        
    
        
        //handling of game lose
        if(health == 0)
        {
            //GameManager.Instance.UpdateGameState(GameState.SceneLose);
        }

    }

    public void CreateWorker()
    {
        if (Builder == null)
        {
            Debug.Log("builder prefab not found");
        }
        else if (protein >= 100)
        {
            float randomAngle = Random.Range(1f, 2f * Mathf.PI);
            float xOffset = spawnDistance * Mathf.Cos(randomAngle);
            float zOffset = spawnDistance * Mathf.Sin(randomAngle);
            Debug.Log(transform.position);
            Instantiate(Builder, new Vector3(transform.position.x + xOffset, 0f, transform.position.z + zOffset), transform.rotation);
            
            
            protein -=  100;
            Debug.Log("builder instantiated");
        }

    }

    private void OnMouseDown()
    {
        GetComponent<ClickHandler>().LeftClicked(Panel);
    }


    public void GiveProtein()
    {
        protein += 100;
    }
}
