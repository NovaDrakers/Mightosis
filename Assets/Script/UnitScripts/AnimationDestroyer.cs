using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDestroyer : MonoBehaviour
{
    public void DestroyParent()
    {
        // Get the parent GameObject
        GameObject parentObject = transform.parent.gameObject;

        // Destroy the parent GameObject
        Destroy(parentObject);
    }
}
