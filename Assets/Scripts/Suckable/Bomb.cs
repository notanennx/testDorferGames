using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : Suckable, IObstacle
{
    // OnCollected
    void IObstacle.OnBumped(GameObject bumpedObject)
    {
        if (!Fever.i.IsActive)
        {
            Snake.i.IsAlive = false;

            MeshRenderer bumpedRenderer = bumpedObject.GetComponent<MeshRenderer>();
                bumpedRenderer.material = gameObject.GetComponent<MeshRenderer>().material;

            //print("BOOMB!");
            //SceneManager.LoadScene("Game");
        }
    }
}
