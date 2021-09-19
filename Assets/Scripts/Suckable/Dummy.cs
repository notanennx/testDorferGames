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
    public override void OnSucked(Transform suckerTransform)
    {
        base.OnSucked(suckerTransform);

        MeshRenderer snakeMesh = Snake.i.GetComponent<MeshRenderer>();
        if ((Fever.i.IsActive) || (snakeMesh.material.name == material.name))
        {
            Score.i.Dummies += 1;
            Events.i.OnDummyCollected?.Invoke();
        }
        else
        {
            Snake.i.IsAlive = false;

            MeshRenderer snakeRenderer = Snake.i.GetComponent<MeshRenderer>();
                snakeRenderer.material = Resources.Load<Material>("Materials/Bomb Material");

            //Snake.i.
            //SceneManager.LoadScene("Game");
        }
    }
}
