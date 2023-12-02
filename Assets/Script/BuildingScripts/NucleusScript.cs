using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NucleusScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int protein;
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
    }

    private void OnDestroy()
    {
        //GameManager.Instance.UpdateGameState(GameState.SceneLose);
        

        
    }

    private void OnMouseDown()
    {
        GetComponent<ClickHandler>().LeftClicked(Panel, gameObject);
    }


    
}
