using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Suckable
{
    // Start
    private float speed;
    
    [SerializeField] private Transform model;
    private void Start()
    {
        speed = Random.Range(16f, 24f);
    }

    // Update
    private void Update()
    {
        model.localPosition = new Vector3(0f, 0.25f * Mathf.Sin(4 * Time.time), 0f);
        transform.Rotate(0, (speed * Time.deltaTime), 0, Space.Self);
    }

    // On Sucked
    public override void OnSucked()
    {
        Score.i.Gems += 1;
        //Destroy(gameObject);
    }
}