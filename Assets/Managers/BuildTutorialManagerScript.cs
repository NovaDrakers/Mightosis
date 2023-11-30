using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTutorialManagerScript : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject nucleus;
    public GameObject proteinMound;

    public TutorialState state;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static event Action<TutorialState> OnTutorialStateChange;

    public void TutorialStateChange(TutorialState newState)
    {
        state = newState;

        switch(state)
        {
            case TutorialState.TutorialStart:
                HandleTutorialStart();
                break;
            case TutorialState.NucluesInfo:
                HandleNucleusInfo();
                break;
            case TutorialState.ProteinInfo:
                HandleProteinInfo();
                break;
            case TutorialState.BuildBuilder:
                HandleBuildBuilder();
                break;
            case TutorialState.UnitMovementandSelection:
                HandleUnitMovementandSelection();
                break;
            case TutorialState.TutorialEnd:
                HandleTutorialEnd();
                break;
        }

        OnTutorialStateChange?.Invoke(newState);
    }


    private void HandleTutorialStart()
    {

    }

    private void HandleNucleusInfo()
    {

    }

    private void HandleProteinInfo()
    {

    }

    private void HandleBuildBuilder()
    {

    }
    
    private void HandleUnitMovementandSelection()
    {

    }

    private void HandleTutorialEnd()
    {

    }

}

public enum TutorialState
{
    //Telling you how to move around and selecting the nucleus
    TutorialStart,
    //Telling you what the nucleus does
    NucluesInfo,
    //Telling what protein is and what its used for
    ProteinInfo,
    //Telling you what a builder does and how to make one
    BuildBuilder,
    //Telling you how to make a builder move and how to get it to start collecting protein
    UnitMovementandSelection,
    //Ends the tutorial
    TutorialEnd,
}
