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

    public float wait = 0.1f;

    bool ToTarget;
    bool arrived;

    public int protein;

    float range = 1f;

    private IEnumerator coroutine;
    void Start()
    {
        protein = 0;

        destination = target.transform.position;
        GetComponent<NavMeshAgent>().destination = destination;
        ToTarget = true;

        arrived = false;

    }

    // Update is called once per frame
    void Update()
    {
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
            GetComponent<NavMeshAgent>().destination = Nucleus.transform.position;
            ToTarget = false;

            while (protein < 100 && target.GetComponent<ProteinMoundScript>().protein > 0)
            {
                yield return new WaitForSeconds(seconds);
                for (int i = 0; i < 10; i++)
                {
                    target.GetComponent<ProteinMoundScript>().protein--;
                    protein++;
                }
            }

            arrived = false;

            GetComponent<NavMeshAgent>().isStopped = false;
        }
        else
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            if (target!=null)
            {
                GetComponent<NavMeshAgent>().destination = destination;
            }
            
            ToTarget = true;

            yield return new WaitForSeconds(seconds*10);
            Nucleus.GetComponent<NucleusScript>().protein += protein;
            protein = 0;

            arrived = false;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}
