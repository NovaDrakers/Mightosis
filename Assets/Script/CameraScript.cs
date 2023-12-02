using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    Rigidbody RB;
    Vector3 velocity;
    public int speed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        RB  = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //RB.velocity = velocity;
        RB.AddForce(velocity * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 CameraPosition;

            CameraPosition = new Vector3(GameObject.Find("Nucleus").transform.position.x ,9, GameObject.Find("Nucleus").transform.position.z);

            gameObject.transform.position = CameraPosition;
        }

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainGame"))
        {
            if (transform.position.x < -28) transform.position = new Vector3(-28, transform.position.y, transform.position.z);
            if (transform.position.z < -55.5) transform.position = new Vector3(transform.position.x, transform.position.y, -55.5f);
            if (transform.position.z > -26) transform.position = new Vector3(transform.position.x, transform.position.y, -26);
            if (transform.position.x > 24) transform.position = new Vector3(24, transform.position.y, transform.position.z);
        }
        /*
        if (Input.mousePosition.x >= Screen.width *0.95 && Input.mousePosition.x <= Screen.width)
        {
            transform.Translate(new Vector3(1,0,0) * Time.deltaTime * speed, Space.World);
        }

        if (Input.mousePosition.x <= Screen.width *0.05 && Input.mousePosition.x >= 0)
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed, Space.World);
        }

        if (Input.mousePosition.y >= Screen.height * 0.95  && Input.mousePosition.y <= Screen.height)
        {
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed, Space.World);
        }

        if (Input.mousePosition.y <= Screen.height * 0.05  && Input.mousePosition.y >= 0)
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed, Space.World);
        }
        */
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.action.phase == InputActionPhase.Performed)
        {
            velocity.x = context.action.ReadValue<Vector2>().x;
            velocity.z = context.action.ReadValue<Vector2>().y;

            
        }

        if (context.action.phase == InputActionPhase.Canceled)
        {
            velocity = Vector3.zero;
        }
    }
}
