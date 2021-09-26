using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Score : MonoBehaviour
{
    // Awake
    public static Score i;
    private void Awake() => i = this;

    // Events
    public Action<int> OnGemsScoreUpdated;
    public Action<int> OnDummiesScoreUpdated;

    // Adding
    public void AddGems(int amount) => SetGems(gems + amount);
    public void AddDummies(int amount) => SetDummies(dummies + amount);

    // SetGems
    private int gems = 0;
    public void SetGems(int amount)
    {
        gems = amount;
        OnGemsScoreUpdated?.Invoke(gems);
    }

    // SetDummies
    private int dummies = 0;
    public void SetDummies(int amount)
    {
        dummies = amount;
        OnDummiesScoreUpdated?.Invoke(dummies);
    }
}
