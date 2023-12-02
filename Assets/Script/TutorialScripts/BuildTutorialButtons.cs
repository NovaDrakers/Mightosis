using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildTutorialButtons : MonoBehaviour
{

    public bool builderCreated = false;
    public bool vacuoleCreated = false;
    public GameObject createBuilderReminder;
    public GameObject BuilderInformation;
    public GameObject unitSelectionInfromation;
    public GameObject gatherProteinReminder;
    public GameObject buildBuildingInformation;
    public GameObject buildVacuoleReminder; 

    private void Start()
    {
        StartCoroutine(checkForBuilder());
        StartCoroutine(checkForVacuole());
    }

    public void closeInitialStart()
    {
       GameObject.Find("InitialStart").SetActive(false);
       GameObject.Find("BuildTutorialManager").GetComponent<BuildTutorialManagerScript>().UpdateTutorialState(TutorialState.NucluesInfo);

    }

    public void closeNucleusInformation()
    {
        GameObject.Find("NucleusInformation").SetActive(false);
        GameObject.Find("BuildTutorialManager").GetComponent<BuildTutorialManagerScript>().UpdateTutorialState(TutorialState.ProteinInfo);
    }

    public void closeProteinInformation()
    {
        GameObject.Find("ProteinMoundInformation").SetActive(false);
        GameObject.Find("BuildTutorialManager").GetComponent<BuildTutorialManagerScript>().UpdateTutorialState(TutorialState.BuildBuilder);
    }

    public void closeBuilderInformation()
    {

        if (builderCreated == true)
        {
            BuilderInformation.SetActive(false);
            GameObject.Find("BuildTutorialManager").GetComponent<BuildTutorialManagerScript>().UpdateTutorialState(TutorialState.UnitMovementandSelection);
        }
        else if (builderCreated == false)
        {
            BuilderInformation.SetActive(false);
            createBuilderReminder.SetActive(true);
        }
    }

    public void closeBuilderReminder()
    {
        createBuilderReminder.SetActive(false);
        BuilderInformation.SetActive(true);
    }

    //For closeBuilderInformation---------------------------------------------------
    IEnumerator checkForBuilder()
    {

        while(builderCreated == false)
        {

            if(GameObject.Find("Builder(Clone)") != null)
            {
                builderCreated = true;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    //------------------------------------------------------------------------------

    public void closeUnitSelectionInformation()
    {
        if(GameObject.Find("Nucleus").GetComponent<NucleusScript>().protein < 300)
        {
            unitSelectionInfromation.SetActive(false);
            unitSelectionInfromation.SetActive(true);
        }
        else if(GameObject.Find("Nucleus").GetComponent<NucleusScript>().protein >= 300)
        {
            unitSelectionInfromation.SetActive(false);
            GameObject.Find("BuildTutorialManager").GetComponent<BuildTutorialManagerScript>().UpdateTutorialState(TutorialState.BuildBuilding);
        }
    }

    public void closeGatherProteinReminder()
    {
        gatherProteinReminder.SetActive(false);
        unitSelectionInfromation.SetActive(true);
    }

    public void closeBuildBuildingInformation()
    {
        if (vacuoleCreated == true)
        {
            buildBuildingInformation.SetActive(false);
            GameObject.Find("BuildTutorialManager").GetComponent<BuildTutorialManagerScript>().UpdateTutorialState(TutorialState.TutorialEnd);
        }
        else if (vacuoleCreated == false)
        {
            buildBuildingInformation.SetActive(false);
            buildVacuoleReminder.SetActive(true);
        }
    }

    public void closeBuildVacuoleReminder()
    {
        buildVacuoleReminder.SetActive(false);
        buildBuildingInformation.SetActive(true);
    }

    //------------------------------------------------------------
    IEnumerator checkForVacuole()
    {
        while (vacuoleCreated == false)
        {

            if (GameObject.Find("Endoplasmic-Reticulum(Clone)") != null)
            {
                vacuoleCreated = true;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    //----------------------------------------------------------------

    public void closeTutorialEndInformation()
    {
        SceneManager.LoadScene("FightingTutorial");
    }


}
