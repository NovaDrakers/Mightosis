using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightTutorialManagerScript : MonoBehaviour
{

    public Camera mainCamera;


    public GameObject enemyNucleus;
    public bool enemyNucleusKilled;
    public GameObject enemyUnit;
    public bool enemyKilled;

    public GameObject nucleus;

    public FightTutorialManagerScript instance;
    public FightTutorialState state;


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

        GameObject temp = Instantiate(enemyUnit, new Vector3(nucleus.transform.position.x + 10, 0f, nucleus.transform.position.z + 10), nucleus.transform.rotation);

        mainCamera.transform.position = new Vector3(temp.transform.position.x, mainCamera.transform.position.y, temp.transform.position.z);

        StartCoroutine(checkForEnemy(temp));

        if(enemyKilled == true)
        {
            instance.UpdateFightTutorialState(FightTutorialState.KillENucleus);
        }
    }

    private void HandleKillENucleus()
    {
        mainCamera.transform.position = new Vector3(enemyNucleus.transform.position.x, mainCamera.transform.position.y, enemyNucleus.transform.position.z);

        killingBuildingsInformation.SetActive(true);

        StartCoroutine(checkForEnemyNucleus(enemyNucleus));

        if(enemyNucleusKilled == true)
        {
            instance.UpdateFightTutorialState(FightTutorialState.Win);
        }
    }

    private void HandleWin()
    {
        winText.SetActive(true);
    }

    private void SceneMove()
    {
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator checkForEnemy(GameObject temp)
    {
        while (enemyKilled == false)
        {
            if(temp == null)
            {
                enemyKilled = true;
            }


            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator checkForEnemyNucleus(GameObject enemyNucleus)
    {
        while (enemyNucleusKilled == false)
        {
            if (enemyNucleus == null)
            {
                enemyNucleusKilled = true;
            }


            yield return new WaitForSeconds(0.5f);
        }
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
