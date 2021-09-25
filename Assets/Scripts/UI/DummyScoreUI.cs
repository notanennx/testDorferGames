using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DummyScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text dummyScore;

    // Enabled
    private void OnEnable() => Events.OnDummyCollected += UpdateDummies;

    // Disabled
    private void OnDisable() => Events.OnDummyCollected -= UpdateDummies;

    //private void OnEnable() => Events.OnDummyCollected += UpdateDummies;

    // Updates score
    private void UpdateDummies()
    {
        dummyScore.text = Score.i.Dummies.ToString();
    }
}
