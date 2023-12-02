using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemyScript : MonoBehaviour
{
    public GameObject enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FIGHTME());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FIGHTME()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(3);
            SummonandGo(enemy);
        }
    }

    public void SummonandGo(GameObject prefab)
    {
        float randomAngle = Random.Range(1f, 2f * Mathf.PI);
        float xOffset = 1 * Mathf.Cos(randomAngle);
        float zOffset = 1 * Mathf.Sin(randomAngle);

        GameObject temp = Instantiate(prefab, new Vector3(transform.position.x + xOffset, 0f, transform.position.z + zOffset), transform.rotation);

        temp.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = GameObject.Find("Nucleus").transform.position;
        temp.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;

        
    }
}
