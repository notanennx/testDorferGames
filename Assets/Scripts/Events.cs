using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public static Events i;

    // Events
    public UnityEvent OnGemCollected;
    public UnityEvent OnDummyCollected;
    //public delegate void GemCollected();
    //public static event GemCollected OnGemCollected;

    //public delegate void DummyCollected();
    //public static event DummyCollected OnDummyCollected;

    //public event Action<int> OnGemCollected;
    //public event Action<int> OnDummyCollected;

    // Awake
    private void Awake()
    {
        i = this;
    }
}
