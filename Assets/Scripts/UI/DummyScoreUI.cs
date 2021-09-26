using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DummyScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text dummyScore;

    // Enabled
    private void OnEnable() => Score.i.OnDummiesScoreUpdated += UpdateDummies;

    // Disabled
    private void OnDisable() => Score.i.OnDummiesScoreUpdated -= UpdateDummies;

    // Updates score
    private void UpdateDummies(int amount)
    {
        dummyScore.text = amount.ToString();
    }
}
