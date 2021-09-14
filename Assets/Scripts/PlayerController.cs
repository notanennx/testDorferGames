using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject Snake;
    [SerializeField] private float forwardSpeed = 16f;
    [SerializeField] [Range(0.01f, 1f)] private float sideLerp = 0.16f;
    private float roadWidth = 4f;

    // Awake
    public static PlayerController i;
    private void Awake()
    {
        i = this;
    }

    // Update
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Get
            Vector3 mousePos = Input.mousePosition;
            Vector3 snakePos = Camera.main.WorldToScreenPoint(Snake.transform.position);

            // Moving
            float posDiff = (mousePos.x - snakePos.x);
            Vector3 curPos = Snake.transform.localPosition;
            Vector3 newPos = (curPos + new Vector3(0f, 0f, posDiff));
            Snake.transform.localPosition = Vector3.Lerp(curPos, newPos, (sideLerp * Time.deltaTime));

            //print(0.5 * (mousePos.x - snakePos.x));

            // Forward
            transform.Translate((-Vector3.right * (forwardSpeed * Time.deltaTime)));

            // Clamping
            Snake.transform.localPosition = new Vector3(0f, 0.5f, Mathf.Clamp(Snake.transform.localPosition.z, -roadWidth, roadWidth));
        }
    }

    /*
    // On Trigger Enter
    private void OnTriggerEnter(Collider other)
    {
        ISuckable collectable = other.gameObject.GetComponent<ISuckable>();
        if (collectable != null)
        {
            collectable.OnSucked();
        }
    }
    */
}
