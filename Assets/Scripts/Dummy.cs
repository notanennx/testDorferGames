using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dummy : MonoBehaviour, ICollectable
{
    // Start
    private Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // OnCollected
    void ICollectable.OnCollected()
    {
        MeshRenderer snakeMesh = PlayerController.i.Snake.GetComponent<MeshRenderer>();
        if (snakeMesh.material.name == material.name)
        {
            print("Good!");
            Score.i.Dummies += 1;

            Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
