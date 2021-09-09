using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0.01f, 1f)] private float sideLerp = 0.16f;
    [SerializeField] private float forwardSpeed = 16f;
    [SerializeField] private GameObject snake;
    private float roadWidth = 4f;

    // Update
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Get
            Vector3 mousePos = Input.mousePosition;
            Vector3 snakePos = Camera.main.WorldToScreenPoint(snake.transform.position);

            // Moving
            float posDiff = (mousePos.x - snakePos.x);
            Vector3 curPos = snake.transform.localPosition;
            Vector3 newPos = (curPos + new Vector3(0f, 0f, posDiff));
            snake.transform.localPosition = Vector3.Lerp(curPos, newPos, (sideLerp * Time.deltaTime));

            //print(0.5 * (mousePos.x - snakePos.x));

            // Forward
            transform.Translate((-Vector3.right * (forwardSpeed * Time.deltaTime)));

            // Clamping
            snake.transform.localPosition = new Vector3(0f, 0.5f, Mathf.Clamp(snake.transform.localPosition.z, -roadWidth, roadWidth));
        }
    }
}
