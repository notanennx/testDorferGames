using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private bool canCollide = true;

    // On Trigger Enter
    private void OnTriggerEnter(Collider other)
    {
        if (!canCollide) return;

        // Obstacle
        IObstacle obstacle = other.gameObject.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            obstacle.OnBumped();
        }
    }
}
