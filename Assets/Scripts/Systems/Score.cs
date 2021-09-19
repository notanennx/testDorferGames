using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Init
    public int Gems = 0;
    public int Dummies = 0;

    // Awake
    public static Score i;
    private void Awake() => i = this;
}
