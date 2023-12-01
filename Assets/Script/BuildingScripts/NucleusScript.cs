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
    

    public GameObject Builder;

    

    public float spawnDistance = 1f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //handling of game lose
        if(health == 0)
        {
          
            //GameManager.Instance.UpdateGameState(GameState.SceneLose);
        }

    }

    

    private void OnMouseDown()
    {
        GetComponent<ClickHandler>().LeftClicked(Panel, gameObject);
    }


    
}
