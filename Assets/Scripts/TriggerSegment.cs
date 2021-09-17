using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSegment : MonoBehaviour
{
    private bool isTriggered = false;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private GameObject destroyParent;

    // OnTriggerEnter
    private void OnTriggerEnter(Collider collider)
    {
        Snake snakeScript = collider.gameObject.GetComponent<Snake>();
        if ((snakeScript) && (!isTriggered))
        {
            isTriggered = true;

            // Segment
            SegmentsManager.i.CreateSegment(spawnPos.position);
            SegmentsManager.i.ToRemove = destroyParent;
        }
    }
}
