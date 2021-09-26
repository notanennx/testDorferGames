using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Awake
    public static PlayerController i;
    private void Awake() => i = this;

    // Update
    [HideInInspector] public bool IsActive = true;
    private void Update()
    {
        // Do nothing!
        if (!IsActive) return;

        // LMB or touch pressed!
        if (Input.GetMouseButton(0))
        {
            // Get
            Vector3 mousePos = Input.mousePosition;
            Vector3 snakePos = Camera.main.WorldToScreenPoint(Snake.i.transform.position);

            // Moving
            float posDiff = (mousePos.x - snakePos.x);
            Vector3 curPos = Snake.i.transform.localPosition;
            Vector3 newPos = (curPos + new Vector3(0f, 0f, posDiff));

            // Sidemoving
            Snake.i.SetDestination(newPos, 0.16f);
        }
    }
}
