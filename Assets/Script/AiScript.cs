using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiScript : MonoBehaviour
{

    public aiState state;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAiState(aiState newState)
    {
        state = newState;

        switch(newState)
        {
            case aiState.attackPBuildings:
                HandleAiAttackPBuildings();
                break;
            case aiState.attackPUnits:
                HandleAiAttackPUnits();
                break;
            case aiState.rest:
                HandleAiRest();
                break;
        }

    }

    private void HandleAiAttackPBuildings()
    {
        Debug.Log("I dont do anything yet");
    }

    private void HandleAiAttackPUnits()
    {
        Debug.Log("I dont do anything yet");
    }

    private void HandleAiRest()
    {
        Debug.Log("I dont do anything yet");
    }
}



public enum aiState
{
    attackPUnits,
    attackPBuildings,
    rest,
}
