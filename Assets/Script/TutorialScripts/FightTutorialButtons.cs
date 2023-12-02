using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTutorialButtons : MonoBehaviour
{
    public bool golgiCreated = false;
    public bool troopsCreated = false;
    public bool mitochondriaCreated = false;


    public bool enemyNucleusKilled = false;
    public bool enemyKilled = false;

    public GameObject golgiReminder;
    public GameObject troopCreationReminder;
    public GameObject mitochondriaReminder;

    public GameObject FightTutorialManager;


    private void Start()
    {
        StartCoroutine(checkForGolgi());
        StartCoroutine(checkForTroops());
        StartCoroutine(checkForMitochondria());
        
    }

    public void closeGolgiInformation()
    {
        if(golgiCreated == true)
        {
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().golgiInformation.SetActive(false);
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.CreateEach);
        }
        else if (golgiCreated == false)
        { 
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().golgiInformation.SetActive(false);
            golgiReminder.SetActive(true);
        }
         
    }

    public void closeGolgiReminder()
    {
        golgiReminder.SetActive(false);
        FightTutorialManager.GetComponent<FightTutorialManagerScript>().golgiInformation.SetActive(true);
    }

    IEnumerator checkForGolgi()
    {

        while (golgiCreated == false)
        {

            if (GameObject.Find("Golgi-apparatus(Clone)") != null)
            {
                golgiCreated = true;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void closeTroopCreationInformation()
    {
        if (troopsCreated == true)
        {
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().troopCreationInformation.SetActive(false);
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.CreateMitochondria);
        }
        else if(troopsCreated == false)
        {
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().troopCreationInformation.SetActive(false);
            troopCreationReminder.SetActive(true);
        }
    }

    public void closeTroopCreationReminder()
    {
        troopCreationReminder.SetActive(false);
        FightTutorialManager.GetComponent<FightTutorialManagerScript>().troopCreationInformation.SetActive(true);
    }

    IEnumerator checkForTroops()
    {

        while (troopsCreated == false)
        {

            if (GameObject.Find("Ranged(Clone)") != null && GameObject.Find("Melee(Clone)") != null && GameObject.Find("Tank(Clone)") != null)
            {
                troopsCreated = true;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void closeMitochondriaInformation()
    {
        if(mitochondriaCreated == true)
        {
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().mitochondriaInformation.SetActive(false);
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.UpgradeUnits);
        }
        else if (mitochondriaCreated == false)
        {
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().mitochondriaInformation.SetActive(false);
            mitochondriaReminder.SetActive(true);
        }
    }

    public void closeMitochondriaReminder()
    {
        mitochondriaReminder.SetActive(false);
        FightTutorialManager.GetComponent<FightTutorialManagerScript>().mitochondriaInformation.SetActive(true);
    }

    IEnumerator checkForMitochondria()
    {

        while (mitochondriaCreated == false)
        {

            if (GameObject.Find("Mitochondria(Clone)") != null)
            {
                mitochondriaCreated = true;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }


    public void closeUpgradeUnitsInformation()
    {
        FightTutorialManager.GetComponent<FightTutorialManagerScript>().upgradeUnitsInformation.SetActive(false);
        FightTutorialManager.GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.KillEUnit);
        StartCoroutine(checkForEnemy());
    }

    public void closeKillingUnitsInformation()
    {

        FightTutorialManager.GetComponent<FightTutorialManagerScript>().killingUnitsInformation.SetActive(false);
        FightTutorialManager.GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.KillENucleus);
        StartCoroutine(checkForEnemyNucleus());
    }

    IEnumerator checkForEnemy()
    {
        while (enemyKilled == false)
        {
            if (GameObject.Find("Enemy(Clone)") == null)
            {
                enemyKilled = true;
                this.closeKillingUnitsInformation();
            }


            yield return new WaitForSeconds(0.5f);
        }
    }

    public void closeKillingBuildingsInformation()
    {
        
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().killingBuildingsInformation.SetActive(false);
            FightTutorialManager.GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.Win);
        
    }

    IEnumerator checkForEnemyNucleus()
    {
        while (enemyNucleusKilled == false)
        {
            if (GameObject.Find("Spawner") == null)
            {
                enemyNucleusKilled = true;
                this.closeKillingBuildingsInformation();
            }


            yield return new WaitForSeconds(0.5f);
        }
    }


    public void closeWinText()
    {
        FightTutorialManager.GetComponent<FightTutorialManagerScript>().winText.SetActive(false);
        FightTutorialManager.GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.FightSceneMove);
        Debug.Log("Trying to move to new scene");
    }


}
