using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DummyScoreUI : MonoBehaviour
{
    [SerializeField] TMP_Text dummyScore;

    // Updates score
    public void UpdateScore()
    {
        dummyScore.text = Score.i.Dummies.ToString();
    }
}
