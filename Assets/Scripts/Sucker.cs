using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucker : MonoBehaviour
{
    // Start
    void Start()
    {
        
    }

    // Update
    void Update()
    {
        
    }

    // OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.gameObject.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.OnCollected();
        }
    }
}
