using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // OnTriggerEnter
    public bool CanCollide = true;
    private void OnTriggerEnter(Collider other)
    {
        if (!CanCollide) return;

        // Obstacle
        IObstacle obstacle = other.gameObject.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            obstacle.OnBumped(gameObject);
        }
    }
}
