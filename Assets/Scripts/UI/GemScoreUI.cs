using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text gemScore;

    // Enabled
    private void OnEnable() => Score.i.OnGemsScoreUpdated += UpdateGems;

    // Disabled
    private void OnDisable() => Score.i.OnGemsScoreUpdated -= UpdateGems;

    // Updates score
    private void UpdateGems(int amount)
    {
        gemScore.text = amount.ToString();
    }
}
