using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text gemScore;

    // Enabled
    private void OnEnable() => Events.OnGemCollected += UpdateGems;

    // Disabled
    private void OnDisable() => Events.OnGemCollected -= UpdateGems;

    // Updates score
    private void UpdateGems()
    {
        gemScore.text = Score.i.Gems.ToString();
    }
}
