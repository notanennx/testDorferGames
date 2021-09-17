using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private bool canCollide = true;
    [SerializeField] private float forwardSpeed = 16f;
    [SerializeField] [Range(0.01f, 1f)] private float sideLerp = 0.16f;

    // Awake
    public static Snake i;
    private void Awake() => i = this;

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

    /*
    // Update
    private void Update()
    {
        // Get
        //Vector3 mousePos = Input.mousePosition;
        //Vector3 snakePos = Camera.main.WorldToScreenPoint(Snake.transform.position);

        // Moving
        float posDiff = (mousePos.x - snakePos.x);
        Vector3 curPos = Snake.transform.localPosition;
        Vector3 newPos = (curPos + new Vector3(0f, 0f, posDiff));
        Snake.transform.localPosition = Vector3.Lerp(curPos, newPos, (sideLerp * Time.deltaTime));

        // Forward
        transform.Translate((-Vector3.right * (forwardSpeed * Time.deltaTime)));

        // Clamping
    //Snake.transform.localPosition = new Vector3(0f, 0.5f, Mathf.Clamp(Snake.transform.localPosition.z, -roadWidth, roadWidth));
    }
    */
}
