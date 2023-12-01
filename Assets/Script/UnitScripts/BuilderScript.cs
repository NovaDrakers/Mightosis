using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class BuilderScript : MonoBehaviour
{
    float range;
    public int protein;
    public GameObject Nucleus;
    public GameObject Panel;

    private void Start()
    {
        protein = 0;
    }

    private void Update()
    {
        range = GetComponent<UnitScript>().range;
        Nucleus = GetComponent<UnitScript>().Nucleus;
    }

    public IEnumerator Farmprotein()
    {
        GameObject target = GetComponent<UnitScript>().target;

        float farmtime = 0.1f;

        GetComponent<NavMeshAgent>().destination = target.gameObject.transform.position;
        GetComponent<NavMeshAgent>().isStopped = false;

        if (protein < 100)
        {
            while (Mathf.Abs(Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination)) >= (1 + range))
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

    public IEnumerator DeliverProtein()
    {
        GameObject target = GetComponent<UnitScript>().target;

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

    private void OnMouseDown()
    {
        GetComponent<ClickHandler>().LeftClicked(Panel, gameObject);
    }
}
