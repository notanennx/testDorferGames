using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    // Awake
    public static Fever i;
    void Awake() => i = this;

    // Values
    public int Gems = 0; // Sequental gems collected.
    public int MaxGems = 3; // Gems you have to collect to get fever.
    public bool IsActive = true; // Is our fever active?
    public float Duration = 5f; // How long fever lasts?
    public float SpeedScale = 3f; // How fast we'll be moving?

    // Start
    void Start()
    {
        
    }

    // Update
    void Update()
    {
        
    }
}
