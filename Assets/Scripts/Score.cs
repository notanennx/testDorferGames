using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score i;

    // Init
    public int Gems = 0;
    public int Dummies = 0;

    // Awake
    private void Awake()
    {
        i = this;
    }

    // Start
    void Start()
    {
        
    }

    // Update
    void Update()
    {
        
    }
}
