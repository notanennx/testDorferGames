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
        if (collider.tag == "Player")
        {
            if (!isTriggered)
            {
                isTriggered = true;

                // Segment
                SegmentsManager.i.CreateSegment(spawnPos.position);
                SegmentsManager.i.ToRemove = destroyParent;
            }
        }
    }
}
