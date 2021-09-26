using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if ((Snake.i.IsInvincible) || (snakeMesh.material.name == material.name))
        {
            Score.i.AddDummies(1);
            Events.OnDummyCollected?.Invoke();
        }
        else
        {
            Snake.i.IsAlive = false;

            Cursor.visible = true;
            UI.i.RestartButton.SetActive(true);

            MeshRenderer snakeRenderer = Snake.i.GetComponent<MeshRenderer>();
                snakeRenderer.material = Resources.Load<Material>("Materials/Bomb Material");


        }
    }
}
