using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalScript : MonoBehaviour
{
    public int team;
    public float defense, attack, maxHealth, health, range;
    public bool isAlive;

    public string type;

    public GameObject HealthBarPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp;

        if (HealthBarPrefab != null)
        {
            switch (type)
            {
                case "building":
                    temp = Instantiate(HealthBarPrefab, transform.position, Quaternion.Euler(0, 0, 0), transform);
                    temp.transform.localPosition = new Vector3(-.05f, -0.6f, -0.001f);
                    break;
                case "unit":
                    temp = Instantiate(HealthBarPrefab, transform.position + new Vector3(-.06f, -0.035f, -0.35f), Quaternion.Euler(90, 0, 0), transform);
                    temp.transform.localPosition = new Vector3(-.06f, -0.035f, -0.35f);
                    break;
                default:
                    break;
            }
        }

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            isAlive = false;

            
            if (gameObject.name == "Nucleus")
            {
                GameManager.Instance.UpdateGameState(GameState.SceneLose);
            } else if (gameObject.name == "Mysterious Mass")
            {
                GameManager.Instance.UpdateGameState(GameState.SceneWin);
            }
            
            switch (type)
            {
                case "building":
                    Destroy(gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
