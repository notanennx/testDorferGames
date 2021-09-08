using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentsManager : MonoBehaviour
{
    public GameObject[] SegmentsPool;
    public static SegmentsManager i;
    public GameObject ToRemove;

    // Awake
    private void Awake()
    {
        i = this;
    }

    // Start
    private void Start()
    {
        SegmentsPool = Resources.LoadAll<GameObject>("Prefabs/Segments");
    }

    // Create
    public void CreateRandom(Vector3 position)
    {
        // Create
        GameObject newSegment = Instantiate(SegmentsPool[Random.Range(0, SegmentsPool.Length)], position, Quaternion.identity);
            newSegment.transform.parent = GameObject.Find("Levels").transform;

        // Destroy
        if (ToRemove) Destroy(ToRemove);
    }
}
