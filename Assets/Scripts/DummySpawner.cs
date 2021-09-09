using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySpawner : MonoBehaviour
{
    // Init
    [SerializeField] private int minAmount = 3;
    [SerializeField] private int maxAmount = 5;
    [SerializeField] private GameObject dummyObject;

    // Start
    void Start()
    {
        SpawnCluster(ColorsManager.i.currentPool[Random.Range(0, ColorsManager.i.currentPool.Count)]);
    }

    // Spawn Dummy
    void SpawnDummy(Material dummyMaterial)
    {
        int attempts = 16;
        while (attempts > 0)
        {
            Vector3 newPos = transform.position + (new Vector3(Random.Range(-1f, 1f), 0.50f, Random.Range(-1f, 1f)));
            if (!Physics.CheckCapsule(newPos, newPos, 0.25f))
            { 
                GameObject newDummy = Instantiate(dummyObject, newPos, transform.rotation, transform);
                    newDummy.GetComponent<MeshRenderer>().material = dummyMaterial;

                break;
            }
            else
            {
                attempts -= 1;
            }
        }
    }

    // Spawn Cluster
    void SpawnCluster(Material dummyMaterial)
    {
        int amount = Random.Range(minAmount, maxAmount);
        for (int i = 0;  i < amount; i++) SpawnDummy(dummyMaterial);
    }
}
