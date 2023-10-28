using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class BuilderScript : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 destination;

    public GameObject target;
    public GameObject Nucleus;

    public int wait = 1;

    bool ToTarget;
    bool arrived;

    public int protein;

    private IEnumerator coroutine;
    void Start()
    {
        protein = 0;

        destination = target.transform.position;
        GetComponent<NavMeshAgent>().destination = destination;
        ToTarget= true;

        arrived= false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(this.transform.position, GetComponent<NavMeshAgent>().destination)) <= 2 && arrived == false)
        {
            arrived= true;
            StartCoroutine(Arrived(wait));
        }
    }

    private IEnumerator Arrived(int seconds)
    {
        Debug.Log("Ran 0");
        if (ToTarget)
        {
            Debug.Log("Ran 1");
            GetComponent<NavMeshAgent>().isStopped = true;
            GetComponent<NavMeshAgent>().destination = Nucleus.transform.position;
            ToTarget = false;

            yield return new WaitForSeconds(seconds);
            target.GetComponent<ProteinMoundScript>().protein -= 100;
            protein += 100;


            arrived = false;

            GetComponent<NavMeshAgent>().isStopped = false;
        }
        else
        {
            Debug.Log("Ran 2");
            GetComponent<NavMeshAgent>().isStopped = true;
            if (target!=null)
            {
                GetComponent<NavMeshAgent>().destination = destination;
            }
            
            ToTarget = true;

            yield return new WaitForSeconds(seconds);
            Nucleus.GetComponent<NucleusScript>().protein += protein;
            protein = 0;

            arrived = false;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}
