using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour, IObstacle
{
    // OnCollected
    void IObstacle.OnBumped()
    {
        print("BOOMB!");
        SceneManager.LoadScene("Game");
    }
}
