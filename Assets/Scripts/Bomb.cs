using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour, ICollectable
{
    // OnCollected
    void ICollectable.OnCollected()
    {
        print("BOOMB!");
        SceneManager.LoadScene("Game");
    }
}
