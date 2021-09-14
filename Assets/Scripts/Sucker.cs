using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucker : MonoBehaviour
{
    [SerializeField] private float suckSpeed = 8f;
    [SerializeField] private float destroyDistance = 0.16f;
    [SerializeField] private Transform snakeHead;
    [SerializeField] private List<Transform> suckPool;

    // Update
    void Update()
    {
        if (suckPool.Count > 0)
        {
            // Backwards search allows us to remove stuff from list without copying it!
            for (int i = (suckPool.Count - 1); i >= 0; i--)
            {
                Transform suckObject = suckPool[i];
                if (suckObject)
                {
                    // Move
                    suckObject.position = Vector3.MoveTowards(suckObject.position, transform.position, (Time.deltaTime * suckSpeed));
                    Vector3 posDiff = (suckObject.position - transform.position);
                    
                    // Scale
                    Rescale(suckObject, 0.0075f);

                    // Rotate
                    Vector3 suckDirection = Vector3.RotateTowards(suckObject.forward, posDiff, (Time.deltaTime * suckSpeed * 2f), 0f);
                    suckObject.localRotation = Quaternion.LookRotation(suckDirection);

                    // Remove
                    float sqrDistance = posDiff.sqrMagnitude;
                    if (sqrDistance < (destroyDistance * destroyDistance))
                    {
                        suckPool.Remove(suckObject);
                        Destroy(suckObject.gameObject);
                    }
                }
            }
        }
    }

    // Rescale
    private void Rescale(Transform target, float speed)
    {
        Vector3 newScale = new Vector3();
            newScale.x = Mathf.Max(0f, target.localScale.x - speed);
            newScale.y = Mathf.Max(0f, target.localScale.y - speed);
            newScale.z = Mathf.Max(0f, target.localScale.z - speed);

        // Apply
        target.localScale = newScale;
    }

    // OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        Suckable suckable = other.gameObject.GetComponent<Suckable>();
        if ((suckable != null) && (!suckable.IsSucked))
        {
            suckPool.Add(other.gameObject.transform);
            suckable.OnSucked();

            suckable.IsSucked = true;
        }
    }
}
