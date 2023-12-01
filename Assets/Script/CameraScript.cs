using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
