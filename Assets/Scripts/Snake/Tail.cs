using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private float partSize = 1f;
    [SerializeField] private Transform connector;
    [SerializeField] private Transform partsHolder;
    [SerializeField] private GameObject partObject;

    private List<Vector3> positions = new List<Vector3>();
    private List<Transform> parts = new List<Transform>();
    void Awake() => positions.Add(connector.position);

    // Update
    void Update()
    {
        float distance = (connector.position - positions[0]).magnitude;

        // Change positions
        if (distance > partSize)
        {
            Vector3 direction = (connector.position - positions[0]).normalized;
            //debugDirection = direction; // DEBUG

            positions.Insert(0, positions[0] + direction * partSize);
            positions.RemoveAt(positions.Count - 1);

            distance -= partSize;
        }

        // Move our snake parts
        for (int i = 0; i < parts.Count; i++)
        {
            parts[i].position = Vector3.Lerp(positions[i + 1], positions[i], (distance / partSize));

            // Angles
            float angSpeed = Time.deltaTime * (1f + (2f * (parts.Count - i)));
            parts[i].localRotation = Quaternion.Lerp(parts[i].localRotation, Snake.i.transform.localRotation, angSpeed);
        }
    }

    // Adds part
    public void AddPart()
    {
        GameObject newPart = Instantiate(partObject, positions[positions.Count - 1], connector.rotation, transform);
            Transform newTransform = newPart.GetComponent<Transform>();
                newTransform.SetParent(partsHolder);

            parts.Add(newTransform);
            positions.Add(newTransform.position);
    }

    // Removes part
    public void RemoveCircle()
    {
        Destroy(parts[0].gameObject);

        parts.RemoveAt(0);
        positions.RemoveAt(1);
    }
}
