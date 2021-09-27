using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Suckable, IObstacle
{
    // OnCollected
    void IObstacle.OnBumped(GameObject bumpedObject)
    {
        if (!Snake.i.IsInvincible())
        {
            Snake.i.IsAlive = false;

            Cursor.visible = true;
            UI.i.RestartButton.SetActive(true);

            MeshRenderer bumpedRenderer = bumpedObject.GetComponent<MeshRenderer>();
                bumpedRenderer.material = gameObject.GetComponent<MeshRenderer>().material;
        }
    }
}
