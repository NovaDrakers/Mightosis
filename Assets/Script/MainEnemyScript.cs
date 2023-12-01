using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemyScript : MonoBehaviour
{
    public GameObject Melee, Ranged, Tank;
    
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
            int random = Random.Range(1, 3);

            switch (random)
            {
                case 1:
                    SummonandGo(Melee);
                    break;
                case 2:
                    SummonandGo(Ranged);
                    break;
                case 3:
                    SummonandGo(Tank);
                    break;
            };


            yield return new WaitForSeconds(3);
        }
    }

    public void SummonandGo(GameObject prefab)
    {
        float randomAngle = Random.Range(1f, 2f * Mathf.PI);
        float xOffset = 1 * Mathf.Cos(randomAngle);
        float zOffset = 1 * Mathf.Sin(randomAngle);

        GameObject temp = Instantiate(prefab, new Vector3(transform.position.x + xOffset, 0f, transform.position.z + zOffset), transform.rotation);
    }
}
