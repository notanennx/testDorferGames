using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSegment : MonoBehaviour
{
    private bool isTriggered = false;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject destroyParent;

    // OnTriggerEnter
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (!isTriggered)
            {
                isTriggered = true;

                SegmentsManager.i.CreateRandom(spawnPoint.transform.position);
                SegmentsManager.i.ToRemove = destroyParent;
            }
        }
    }
}
