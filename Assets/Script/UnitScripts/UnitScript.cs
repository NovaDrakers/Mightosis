using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.UI;

public class UnitScript : MonoBehaviour
{
    public GameObject target;
    GameObject healthBar;
    public GameObject healthBarPrefab;
    //public HealthScript healthScript;
    /********CHANGED LINE 37 BELOW TO FIND NUCLEUS OBJECT BY TAG BC INSTANTIATED NEW BUILDERS HAVE NO NUCLEUS TO TARGET**********/
    public GameObject Nucleus;

    public Animator animator;

    

    public float wait = 0.1f;

    

    public float range = 1f;

    public int maxHealth = 100;
    public int currentHealth;
    public int damage;

    void Start()
    {
        
        currentHealth = maxHealth;
        damage = 10;
        animator = GetComponentInChildren<Animator>();



        //              || || ||
        //#######       \/ \/ \/    #######
        Nucleus = GameObject.FindGameObjectWithTag("Nucleus");

        if (target == null) GetComponent<NavMeshAgent>().isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        //##### UNCOMMENT THIS TO TEST THE HEALTHBAR ##### //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth-=25;
        }

        if (currentHealth <= 0)
        {

            animator.Play("apoptosis");
            // Invoke a method to destroy the object after the animation is complete
            //Invoke("DestroyObject", animator.GetCurrentAnimatorStateInfo(0).length);
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

        if (hit.collider.gameObject.GetComponent<ProteinMoundScript>() != null)
        {
            target = hit.collider.gameObject;
            StartCoroutine(GetComponent<BuilderScript>().Farmprotein());
        } else if (hit.collider.gameObject.GetComponent<NucleusScript>() != null) {
            target = hit.collider.gameObject;
            StartCoroutine(GetComponent<BuilderScript>().DeliverProtein());
        } else if (hit.collider.gameObject.GetComponent<UnitScript>() != null) {
            target = hit.collider.gameObject;
            StartCoroutine(UnitCombat());
        }
        else
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    private IEnumerator UnitCombat()
    {
        while (1 == 1)
        {
            if (target == null)
            {
                break;
            }
            else
            {
                GetComponent<NavMeshAgent>().destination = target.gameObject.transform.position;
                GetComponent<NavMeshAgent>().isStopped = false;

                while (Mathf.Abs(Vector3.Distance(this.transform.position, GetComponent<NavMeshAgent>().destination)) >= (1 + range))
                {
                    yield return null;
                }

                GetComponent<NavMeshAgent>().isStopped = true;
                yield return new WaitForSeconds(1);

                Debug.Log("Attacked");
                target.GetComponent<UnitScript>().currentHealth -= damage;

                yield return null;
            }
        }
    }
}
