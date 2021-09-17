using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : Suckable, IObstacle
{
    // OnCollected
    void IObstacle.OnBumped()
    {
        if (!Fever.i.IsActive)
        {
            print("BOOMB!");
            SceneManager.LoadScene("Game");
        }
    }
}
