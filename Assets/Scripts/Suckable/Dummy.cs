using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dummy : Suckable
{
    // Start
    private Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    // On Sucked
    public override void OnSucked()
    {
        MeshRenderer snakeMesh = PlayerController.i.Snake.GetComponent<MeshRenderer>();
        if (snakeMesh.material.name == material.name)
        {
            Score.i.Dummies += 1;

            //Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
