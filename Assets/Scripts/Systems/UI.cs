using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Awake
    public static UI i;
    void Awake() => i = this;

    // Restart
    public GameObject RestartButton;
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
