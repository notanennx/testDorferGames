using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Suckable : MonoBehaviour
{
    public bool IsSucked;

    // On Sucked
    public abstract void OnSucked();
}