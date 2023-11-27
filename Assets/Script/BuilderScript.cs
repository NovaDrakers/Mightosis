using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class BuilderScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 destination;

    public GameObject target;

    /********CHANGED LINE 37 BELOW TO FIND NUCLEUS OBJECT BY TAG BC INSTANTIATED NEW BUILDERS HAVE NO NUCLEUS TO TARGET**********/
    public GameObject Nucleus;

    public float wait = 0.1f;

    public bool ToTarget;
    public bool arrived;

    public int protein;

    float range = 1f;

    private IEnumerator coroutine;
    void Start()
    {
        protein = 0;

        ToTarget = true;

        arrived = false;

        //              || || ||
        //#######       \/ \/ \/    #######
        Nucleus = GameObject.FindGameObjectWithTag("Nucleus");

        if (target == null) GetComponent<NavMeshAgent>().isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ToTarget && target != null) destination = target.transform.position;
        if (!ToTarget) destination = Nucleus.transform.position;
        GetComponent<NavMeshAgent>().destination = destination;

        if (Mathf.Abs(Vector3.Distance(this.transform.position, GetComponent<NavMeshAgent>().destination)) <= (1 + range) && arrived == false)
        {
            arrived = true;
            StartCoroutine(Arrived(wait));
        }
    }

    private IEnumerator Arrived(float seconds)
    {
        if (ToTarget)
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            //GetComponent<NavMeshAgent>().destination = Nucleus.transform.position;
            ToTarget = false;

            while (protein < 100 && target != null)
            {
                yield return new WaitForSeconds(seconds);
                for (int i = 0; i < 10; i++)
                {
                    //*** ADDED THIS IF STATEMENT TO CHECK  IF OBJECT HAS THE SCRIPT
                    if (target.GetComponent<ProteinMoundScript>() == null)
                    {
                        break;
                    }
                    else
                    {
                        if (target.GetComponent<ProteinMoundScript>().protein > 0)
                        {
                            target.GetComponent<ProteinMoundScript>().protein--;
                            protein++;
                        }
                    }
                    
                }
            }

            arrived = false;

            GetComponent<NavMeshAgent>().isStopped = false;
        }
        else
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            
            ToTarget = true;

            yield return new WaitForSeconds(seconds*10);
            Nucleus.GetComponent<NucleusScript>().protein += protein;
            protein -= protein;

            arrived = false;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}
