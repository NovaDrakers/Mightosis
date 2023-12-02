using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightTutorialManagerScript : MonoBehaviour
{

    public Camera mainCamera;


    public GameObject enemyNucleus;
    public GameObject enemyUnit;
    

    public GameObject nucleus;

    public FightTutorialManagerScript instance;
    public FightTutorialState state;

    public GameObject MainUi;

    public GameObject temp;


    public GameObject golgiInformation;
    public GameObject troopCreationInformation;
    public GameObject mitochondriaInformation;
    public GameObject upgradeUnitsInformation;
    public GameObject killingUnitsInformation;
    public GameObject killingBuildingsInformation;
    public GameObject winText;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance.UpdateFightTutorialState(FightTutorialState.CreateGolgi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFightTutorialState(FightTutorialState newState)
    {
        state = newState;

        switch (state)
        {
            case FightTutorialState.CreateGolgi:
                HandleCreateGolgi();
                break;
            case FightTutorialState.CreateEach:
                HandleCreateEach();
                break;
            case FightTutorialState.CreateMitochondria:
                HandleCreateMitochondria();
                break;
            case FightTutorialState.UpgradeUnits:
                HandleUpgradeUnits();
                break;
            case FightTutorialState.KillEUnit:
                HandleKillEUnits();
                break;
            case FightTutorialState.KillENucleus:
                HandleKillENucleus();
                break;
            case FightTutorialState.Win:
                HandleWin();
                break;
            case FightTutorialState.FightSceneMove:
                break;


        }

    }

    private void HandleCreateGolgi()
    {
        golgiInformation.SetActive(true);
    }

    private void HandleCreateEach()
    {
        troopCreationInformation.SetActive(true);
    }

    private void HandleCreateMitochondria()
    {
        mitochondriaInformation.SetActive(true);
    }

    private void HandleUpgradeUnits()
    {
        upgradeUnitsInformation.SetActive(true);
    }

    private void HandleKillEUnits()
    {

        killingUnitsInformation.SetActive(true);

        temp = Instantiate(enemyUnit, new Vector3(nucleus.transform.position.x + 10, 0f, nucleus.transform.position.z + 10), nucleus.transform.rotation);

        mainCamera.transform.position = new Vector3(temp.transform.position.x, mainCamera.transform.position.y, temp.transform.position.z);

        
    }

    private void HandleKillENucleus()
    {
        mainCamera.transform.position = new Vector3(enemyNucleus.transform.position.x, mainCamera.transform.position.y, enemyNucleus.transform.position.z);

        killingBuildingsInformation.SetActive(true);

        

        
    }

    private void HandleWin()
    {
        winText.SetActive(true);
    }

    private void SceneMove()
    {
        SceneManager.LoadScene("SampleScene");
    }

    

    

    public enum FightTutorialState
    {
        CreateGolgi,
        CreateEach,
        CreateMitochondria,
        UpgradeUnits,
        KillEUnit,
        KillENucleus,
        Win,
        FightSceneMove,
    }


}
