using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UnitScript : MonoBehaviour
{
    public GameObject target;
    GameObject healthBar;
    public GameObject healthBarPrefab;
    //public HealthScript healthScript;
    /********CHANGED LINE 37 BELOW TO FIND NUCLEUS OBJECT BY TAG BC INSTANTIATED NEW BUILDERS HAVE NO NUCLEUS TO TARGET**********/

    public Animator animator;

    public int team;

    public float wait = 0.1f;

    public string state;

    public float range = 1f;

    public int maxHealth = 100;
    public int damage;

    public int detectionRange;

    void Start()
    {
        GetComponent<GlobalScript>().isAlive = true;
        GetComponent<GlobalScript>().team = team;

        GetComponent<GlobalScript>().maxHealth = maxHealth;
        GetComponent<GlobalScript>().type = "unit";
        damage = 10;
        animator = GetComponentInChildren<Animator>();

        detectionRange = 5;

        if (target == null) GetComponent<NavMeshAgent>().isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //##### UNCOMMENT THIS TO TEST THE HEALTHBAR ##### //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<GlobalScript>().health -= 25;
        }

        if (GetComponent<GlobalScript>().health <= 0)
        {
            animator.Play("apoptosis");
            // Invoke a method to destroy the object after the animation is complete
            //Invoke("DestroyObject", animator.GetCurrentAnimatorStateInfo(0).length);
        }
        if (target == null && GetComponent<NavMeshAgent>().isStopped == true)
        {
            Alert();
        }
    }

    private void Reset()
    {
        target = null;
        GetComponent<NavMeshAgent>().isStopped = true;
        StopAllCoroutines();
        if (GetComponent<BuilderScript>() != null)
        {
            GetComponent<BuilderScript>().StopAllCoroutines();
        }
    }

    public void newTarget(RaycastHit hit)
    {
        Reset();
        
        if (hit.collider.gameObject.name != "Map")
        {
            target = hit.collider.gameObject;

            if (target.GetComponent<GlobalScript>().team == team)
            {
                if (hit.collider.gameObject.GetComponent<ProteinMoundScript>() != null)
                {
                    state = "Farmign Protein";
                    StartCoroutine(GetComponent<BuilderScript>().Farmprotein());
                }
                else if (hit.collider.gameObject.GetComponent<NucleusScript>() != null)
                {
                    state = "Delivering Protein";
                    StartCoroutine(GetComponent<BuilderScript>().DeliverProtein());
                }
            }
            else
            {
                StartCoroutine(UnitCombat());
            }
        } 
        else
        {
            StartCoroutine(walk(hit));
        }
    }

    public IEnumerator walk(RaycastHit hit)
    {
        GetComponent<NavMeshAgent>().destination = hit.point;
        GetComponent<NavMeshAgent>().isStopped = false;

        while (Mathf.Abs(Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination)) >= (1.6))
        {
            //Debug.Log(NavMeshPathStatus.PathPartial + " should be equal 1?");
            yield return null;
        }
        Alert();
    }

    public void newTarget(GameObject hit)
    {
        Reset();
        target = hit;

        if (target.GetComponent<GlobalScript>().team == team)
        {
            if (hit.GetComponent<ProteinMoundScript>() != null)
            {
                target = hit;
                state = "Farmign Protein";
                StartCoroutine(GetComponent<BuilderScript>().Farmprotein());
            }
            else if (hit.GetComponent<NucleusScript>() != null)
            {
                target = hit;
                state = "Delivering Protein";
                StartCoroutine(GetComponent<BuilderScript>().DeliverProtein());
            }
        }
        else
        {
            target = hit;
            StartCoroutine(UnitCombat());
        }
    }

    private IEnumerator UnitCombat()
    {
        state = "Fighting!";
        while (target.GetComponent<GlobalScript>().isAlive)
        {
            if (GetComponent<GlobalScript>().team != target.GetComponent<GlobalScript>().team)
            {
                GetComponent<NavMeshAgent>().destination = target.gameObject.transform.position;
                GetComponent<NavMeshAgent>().isStopped = false;

                if (Mathf.Abs(Vector3.Distance(this.transform.position, GetComponent<NavMeshAgent>().destination)) <= (1 + range))
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    //Debug.Log(name + " Attacked " + target.name);
                    transform.LookAt(target.transform);
                    target.GetComponent<GlobalScript>().health -= damage;

                    yield return new WaitForSeconds(1);
                }
                if (target == null || !target.GetComponent<GlobalScript>().isAlive)
                {
                    Reset();
                }
            }
            yield return null;
        } 
    }

    private void Alert()
    {
        state = "Hunting";
        Reset();

        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            if (unit.GetComponent<UnitScript>().team != team)
            {
                if (Vector3.Distance(transform.position, unit.transform.position) <= detectionRange)
                {
                    target = unit;
                }
            }
            if (target != null)
            {
                if (target.GetComponent<GlobalScript>().team != team)
                {
                    newTarget(target);
                    break;
                }  
                else target = null;
            }    
        }

        if (target == null)
        {
            foreach (GameObject structure in GameObject.FindGameObjectsWithTag("Structure"))
            {
                if (structure.GetComponent<GlobalScript>().team != team)
                {
                    if (Vector3.Distance(transform.position, structure.transform.position) <= detectionRange)
                    {
                        newTarget(structure);
                        break;
                    }
                }
            }
        }
    }
}
