using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentsManager : MonoBehaviour
{
    // Awake
    public static SegmentsManager i;
    private void Awake() => i = this;

    // Start
    [HideInInspector] public GameObject ToRemove;
    [HideInInspector] public GameObject[] SegmentsPool;
    private void Start()
    {
        SegmentsPool = Resources.LoadAll<GameObject>("Prefabs/Segments/Pool");
    }

    // Create
    private int segmentsPassed;
    private float[] mirrorModifiers = new float[] {-1, 1};
    [SerializeField] private int segmentsToCheckpoint;
    public void CreateSegment(Vector3 position)
    {
        // Passed
        segmentsPassed += 1;

        // Mirroring
        position = new Vector3(position.x, position.y, position.z * mirrorModifiers[Random.Range(0, mirrorModifiers.Length)]);

        // Checking
        if (segmentsPassed == segmentsToCheckpoint)
        {
            segmentsPassed = 0;

            // Checkpoint
            GameObject newCheckpoint = Instantiate(Resources.Load<GameObject>("Prefabs/Segments/Checkpoint Segment"), position, Quaternion.identity);
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
