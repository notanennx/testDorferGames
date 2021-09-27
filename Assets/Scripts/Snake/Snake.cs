using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    // Snake
    public int Length = 3;
    public int CollideLength = 2;
    public float SpeedScale = 1f;

    [SerializeField] private float forwardSpeed = 16f;
    [SerializeField] private Transform snakeHolder;
    [SerializeField] private Transform moveTransform;

    [HideInInspector] public bool IsAlive = true;
    [HideInInspector] public float IFrames = 0f;

    // Awake
    public static Snake i;
    private void Awake() => i = this;

    // Start
    private Tail tail;
    private void Start()
    {
        //IFrames = Time.time + 10000000000f;

        // Head
        AddBodypart(transform);

        // Tail
        tail = GetComponent<Tail>();
        for (int i = 0; i < Length; i++)
        {
            GameObject tailObject = null;
            if (i < CollideLength)
            {
                tailObject = tail.AddPart(true);
            }
            else
            {
                tailObject = tail.AddPart(false);
            }

            // Add to bodyparts
            AddBodypart(tailObject.GetComponent<Transform>());
        }
    }

    // Bodyparts
    private List<Transform> bodyParts = new List<Transform>();
    private void AddBodypart(Transform newTransform)
    {
        bodyParts.Add(newTransform);
    }

    // Resizing
    private void ResizeBodyparts()
    {
        float resizeSpeed = (1f * Time.deltaTime);
        if (IsInvincible())
        {
            foreach (Transform bodyPart in bodyParts)
                snakeHolder.localScale = Vector3.Lerp(snakeHolder.localScale, new Vector3(2.4f, 2.4f, 2.4f), resizeSpeed);
        }
        else
        {
            foreach (Transform bodyPart in bodyParts)
                snakeHolder.localScale = Vector3.Lerp(snakeHolder.localScale, new Vector3(1f, 1f, 1f), resizeSpeed);
        }
    }

    // Invincible?
    public bool IsInvincible()
    {
        return (IFrames > Time.time);
    }

    // MoveToSide
    private float roadWidth = 4f;
    public void SetDestination(Vector3 position, float sideLerp)
    {
        if (!IsAlive) return;

        transform.localPosition = Vector3.Lerp(transform.localPosition, position, (sideLerp * SpeedScale * Time.deltaTime));
        transform.localPosition = new Vector3(0f, 0.5f, Mathf.Clamp(transform.localPosition.z, -roadWidth, roadWidth));

        // Rotation
        angDifference = -Mathf.Clamp((transform.localPosition - position).z * angSensivity, -90f, 90f);
    }

    // Update
    private void Update()
    {
        if (!IsAlive) return;

        // Forward
        moveTransform.Translate((-Vector3.right * (forwardSpeed * SpeedScale * Time.deltaTime)));

        // Resizing
        ResizeBodyparts();

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
