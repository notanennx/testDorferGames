using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text gemScore;

    // Updates score
    public void UpdateScore()
    {
        gemScore.text = Score.i.Gems.ToString();
    }
}
