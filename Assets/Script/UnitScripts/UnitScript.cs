using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;

public class UnitScript : MonoBehaviour
{
    public GameObject target;

    /********CHANGED LINE 37 BELOW TO FIND NUCLEUS OBJECT BY TAG BC INSTANTIATED NEW BUILDERS HAVE NO NUCLEUS TO TARGET**********/
    public GameObject Nucleus;

    public float wait = 0.1f;

    public int protein;

    float range = 1f;

    void Start()
    {
        protein = 0;

        //              || || ||
        //#######       \/ \/ \/    #######
        Nucleus = GameObject.FindGameObjectWithTag("Nucleus");

        if (target == null) GetComponent<NavMeshAgent>().isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Reset()
    {
        target = null;
        GetComponent<NavMeshAgent>().isStopped = true;
        StopAllCoroutines();
    }

    public void newTarget(RaycastHit hit)
    {
        Reset();

        if (hit.collider.gameObject.GetComponent<ProteinMoundScript>() != null)
        {
            target = hit.collider.gameObject;
            StartCoroutine(Farmprotein());
        } else if (hit.collider.gameObject.GetComponent<NucleusScript>() != null) {
            target = hit.collider.gameObject;
            StartCoroutine(DeliverProtein());
        }
        else
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    private IEnumerator Farmprotein()
    {
        float farmtime = 0.1f;

        GetComponent<NavMeshAgent>().destination = target.gameObject.transform.position;
        GetComponent<NavMeshAgent>().isStopped = false;

        if (protein < 100)
        {
            while (Mathf.Abs(Vector3.Distance(this.transform.position, GetComponent<NavMeshAgent>().destination)) >= (1 + range))
            {
                yield return null;
            }

            GetComponent<NavMeshAgent>().isStopped = true;

            while (protein < 100 && target != null)
            {
                yield return new WaitForSeconds(farmtime);
                for (int i = 0; i < 10; i++)
                {
                    if (target != null)
                    {
                        if (target.GetComponent<ProteinMoundScript>().protein > 0)
                        {
                            target.GetComponent<ProteinMoundScript>().protein--;
                            protein++;
                        }
                    }
                }
            }
        }
        StartCoroutine(DeliverProtein());
    }

    private IEnumerator DeliverProtein()
    {
        GetComponent<NavMeshAgent>().destination = Nucleus.gameObject.transform.position;
        GetComponent<NavMeshAgent>().isStopped = false;

        while (Mathf.Abs(Vector3.Distance(this.transform.position, GetComponent<NavMeshAgent>().destination)) >= (1 + range))
        {
            yield return null;
        }

        GetComponent<NavMeshAgent>().isStopped = true;

        yield return new WaitForSeconds(1);
        Nucleus.GetComponent<NucleusScript>().protein += protein;
        protein -= protein;

        StartCoroutine(Farmprotein());
    }
}
