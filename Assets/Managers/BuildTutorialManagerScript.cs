using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildTutorialManagerScript : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject nucleus;
    public GameObject proteinMound;

    public GameObject initialStartInformation;
    public GameObject nucleusInformation;
    public GameObject proteinMoundInformation;
    public GameObject builderInformation;
    public GameObject unitSelectionInformation;
    public GameObject buildBuildingInformation;
    public GameObject tutorialEndInformation;

    public BuildTutorialManagerScript instance;
    public TutorialState state;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance.UpdateTutorialState(TutorialState.TutorialStart);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static event Action<TutorialState> OnTutorialStateChange;

    public void UpdateTutorialState(TutorialState newState)
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
            case TutorialState.BuildBuilding:
                HandleBuildBuilding();
                break;
            case TutorialState.TutorialEnd:
                HandleTutorialEnd();
                break;
            case TutorialState.SceneMove:
                SceneMove();
                break;
        }

        OnTutorialStateChange?.Invoke(newState);
    }


    private void HandleTutorialStart()
    {
        initialStartInformation.SetActive(true);
    }


    private void HandleNucleusInfo()
    {

        mainCamera.GetComponent<Rigidbody>().position = new Vector3(3f, 6f, -11.5f);
        nucleusInformation.SetActive(true);
    }

    private void HandleProteinInfo()
    {
        mainCamera.GetComponent<Rigidbody>().position = new Vector3(proteinMound.transform.position.x + 2f, 6f, proteinMound.transform.position.z);
        proteinMoundInformation.SetActive(true);
    }

    private void HandleBuildBuilder()
    {
        mainCamera.GetComponent<Rigidbody>().position = new Vector3(-4,10,-11);
        builderInformation.SetActive(true);
        GameObject.Find("PlayerManager").GetComponent<PlayerManagerScript>().protein += 100;
    }
    
    private void HandleUnitMovementandSelection()
    {
        unitSelectionInformation.SetActive(true);
    }

    private void HandleBuildBuilding()
    {
        buildBuildingInformation.SetActive(true);
    }

    private void HandleTutorialEnd()
    {
        tutorialEndInformation.SetActive(true);
    }

    private void SceneMove()
    {
        SceneManager.LoadScene("FightingTutorial");
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
    //Telling you to build a vacuole
    BuildBuilding,
    //prompts to end the tutorial
    TutorialEnd,
    //moves to the nexts scene
    SceneMove,
}
