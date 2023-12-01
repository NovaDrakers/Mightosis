using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTutorialButtons : MonoBehaviour
{
    public bool golgiCreated = false;
    public bool troopsCreated = false;
    public bool mitochondriaCreated = false;

    public GameObject golgiReminder;
    public GameObject troopCreationReminder;
    public GameObject mitochondriaReminder;


    private void Start()
    {
        StartCoroutine(checkForGolgi());
        StartCoroutine(checkForTroops());
    }

    public void closeGolgiInformation()
    {
        if(golgiCreated == true)
        {
            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().golgiInformation.SetActive(false);
            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.CreateEach);
        }
        else if (golgiCreated == false)
        {

            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().golgiInformation.SetActive(false);
            golgiReminder.SetActive(true);
        }
         
    }

    public void closeGolgiReminder()
    {
        golgiReminder.SetActive(false);
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().golgiInformation.SetActive(true);
    }

    IEnumerator checkForGolgi()
    {

        while (golgiCreated == false)
        {

            if (GameObject.Find("Golgi-apparatus") != null)
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
            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().troopCreationInformation.SetActive(false);
            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.CreateMitochondria);
        }
        else if(troopsCreated == false)
        {
            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().troopCreationInformation.SetActive(false);
            troopCreationReminder.SetActive(true);
        }
    }

    public void closeTroopCreationReminder()
    {
        troopCreationReminder.SetActive(false);
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().troopCreationInformation.SetActive(true);
    }

    IEnumerator checkForTroops()
    {

        while (troopsCreated == false)
        {

            if (GameObject.Find("Ranged") != null && GameObject.Find("Melee") != null && GameObject.Find("Tank") != null)
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
            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().mitochondriaInformation.SetActive(false);
            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.UpgradeUnits);
        }
        else if (mitochondriaCreated == false)
        {
            GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().mitochondriaInformation.SetActive(false);
            mitochondriaReminder.SetActive(true);
        }
    }

    public void closeMitochondriaReminder()
    {
        mitochondriaReminder.SetActive(false);
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().mitochondriaInformation.SetActive(true);
    }

    IEnumerator checkForMitochondria()
    {

        while (mitochondriaCreated == false)
        {

            if (GameObject.Find("Mitochondria") != null)
            {
                mitochondriaCreated = true;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }


    public void closeUpgradeUnitsInformation()
    {
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().upgradeUnitsInformation.SetActive(false);
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.KillEUnit);
    }

    public void closeKillingUnitsInformation()
    {
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().killingUnitsInformation.SetActive(false);
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.KillENucleus);
    }

    public void closeKillingBuildingsInformation()
    {
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().killingBuildingsInformation.SetActive(false);
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.Win);
    }

   
    public void closeWinText()
    {
        GameObject.Find("FightTutorialManager").GetComponent<FightTutorialManagerScript>().winText.SetActive(false);
        GameObject.Find("BuildTutorialManager").GetComponent<FightTutorialManagerScript>().UpdateFightTutorialState(FightTutorialManagerScript.FightTutorialState.FightSceneMove);
    }


}
