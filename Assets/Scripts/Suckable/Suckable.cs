using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Suckable : MonoBehaviour
{
    public bool IsSuckable;
    [HideInInspector] public bool IsSucked;

    // On Sucked
    public virtual void OnSucked(Transform suckerTransform)
    {
        transform.SetParent(suckerTransform);
        //Destroy(gameObject, 0.2f); // Destroying again just in case!
    }
}