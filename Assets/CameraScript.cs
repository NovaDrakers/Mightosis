using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    Rigidbody RB;
    Vector3 velocity;
    public int speed = 5;
    
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
