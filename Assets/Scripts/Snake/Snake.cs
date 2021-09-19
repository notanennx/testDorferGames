using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 16f;
    [SerializeField] [Range(0.01f, 1f)] private float sideLerp = 0.16f;

    // Snake
    public int Length = 3;
    public int CollideLength = 2;
    [HideInInspector] public bool IsAlive = true;

    // Awake
    public static Snake i;
    private void Awake() => i = this;

    // Start
    private Tail tail;
    private void Start()
    {
        tail = GetComponent<Tail>();
        for (int i = 0; i < Length; i++)
        {
            if (i < CollideLength)
            {
                tail.AddPart(true);
            }
            else
            {
                tail.AddPart(false);
            }   
        }
    }

    // MoveToSide
    private float roadWidth = 4f;
    public void MoveToSide(Vector3 position)
    {
        if (!IsAlive) return;

        transform.localPosition = Vector3.Lerp(transform.localPosition, position, (sideLerp * Time.deltaTime));
        transform.localPosition = new Vector3(0f, 0.5f, Mathf.Clamp(transform.localPosition.z, -roadWidth, roadWidth));

        // Rotation
        angDifference = -Mathf.Clamp((transform.localPosition - position).z * angSensivity, -90f, 90f);
    }

    // Update
    [SerializeField] private Transform snakeHolder;
    private void Update()
    {
        if (!IsAlive) return;

        // Forward
        snakeHolder.Translate((-Vector3.right * (forwardSpeed * Time.deltaTime)));

        // Rotation
        AngleRotation();
    }

    // Rotation
    private float angDifference;
    [SerializeField] private float angSensivity = 0.66f;
    [SerializeField] private float angChangeSpeed = 16f;
    [SerializeField] private float angReturnSpeed = 16f;
    private void AngleRotation()
    {
        if (!IsAlive) return;
        
        angDifference = Mathf.Lerp(angDifference, 0, (angReturnSpeed * Time.deltaTime));
        if (Mathf.Abs(transform.localPosition.z) >= roadWidth)
        {
           angDifference = Mathf.Lerp(angDifference, 0, (64f * angReturnSpeed * Time.deltaTime)); 
        }

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, angDifference, 90f), (angChangeSpeed * Time.deltaTime));  
    }
}
