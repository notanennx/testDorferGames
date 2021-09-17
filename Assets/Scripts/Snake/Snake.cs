using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private bool canCollide = true;
    [SerializeField] private float forwardSpeed = 16f;
    [SerializeField] [Range(0.01f, 1f)] private float sideLerp = 0.16f;

    // Snake
    public int Length = 3;
    public int CollideLength = 2;

    // Awake
    public static Snake i;
    private void Awake() => i = this;

    // Start
    private Tail tail;
    private void Start()
    {
        tail = GetComponent<Tail>();
        for (int i = 0; i < Length; i++) tail.AddPart();
    }

    // On Trigger Enter
    private void OnTriggerEnter(Collider other)
    {
        if (!canCollide) return;

        // Obstacle
        IObstacle obstacle = other.gameObject.GetComponent<IObstacle>();
        if (obstacle != null)
        {
            obstacle.OnBumped();
        }
    }

    // MoveToSide
    private float roadWidth = 4f;
    public void MoveToSide(Vector3 position)
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, position, (sideLerp * Time.deltaTime));
        transform.localPosition = new Vector3(0f, 0.5f, Mathf.Clamp(transform.localPosition.z, -roadWidth, roadWidth));
    }

    // Update
    [SerializeField] private Transform snakeHolder;
    private void Update()
    {
        // Forward
        snakeHolder.Translate((-Vector3.right * (forwardSpeed * Time.deltaTime)));
    }
}