using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentsManager : MonoBehaviour
{
    public static SegmentsManager i;

    // Awake
    private void Awake()
    {
        i = this;
    }

    // Start
    [HideInInspector] public GameObject ToRemove;
    [HideInInspector] public GameObject[] SegmentsPool;
    private void Start()
    {
        SegmentsPool = Resources.LoadAll<GameObject>("Prefabs/Segments");
    }

    // Create
    private int segmentsPassed;
    [SerializeField] private int segmentsToCheckpoint;
    public void CreateSegment(Vector3 position)
    {
        segmentsPassed += 1;

        // Checking
        if (segmentsPassed == segmentsToCheckpoint)
        {
            segmentsPassed = 0;

            // Checkpoint
            GameObject newCheckpoint = Instantiate(Resources.Load<GameObject>("Prefabs/Checkpoint Segment"), position, Quaternion.identity);
                newCheckpoint.transform.parent = GameObject.Find("Levels").transform;
        }
        else
        {
            // Common Segment
            GameObject newSegment = Instantiate(SegmentsPool[Random.Range(0, SegmentsPool.Length)], position, Quaternion.identity);
                newSegment.transform.parent = GameObject.Find("Levels").transform;
        }

        // Destroy
        if (ToRemove) Destroy(ToRemove);
    }
}
