using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Awake
    public static PlayerController i;
    private void Awake() => i = this;

    // Update
    private bool isPressing;
    private Vector3 inputPosition;
    [HideInInspector] public bool IsActive = true;
    private void Update()
    {
        // Do nothing!
        if (!IsActive) return;

        // LMB or touch pressed!
        if (Input.GetMouseButton(0))
        {
            isPressing = true;
            inputPosition = MousePosition();
        }
        else if (Input.touchCount > 0)
        {
            isPressing = true;
            inputPosition = TouchPosition();
        }
        else
        {
            isPressing = false;
        }

        // Pressing
        if (isPressing)
        {
            Vector3 snakePos = Camera.main.WorldToScreenPoint(Snake.i.transform.position);

            // Moving
            float posDiff = (inputPosition.x - snakePos.x);
            Vector3 curPos = Snake.i.transform.localPosition;
            Vector3 newPos = (curPos + new Vector3(0f, 0f, posDiff));

            // Sidemoving
            Snake.i.SetDestination(newPos, 0.16f);
        }
    }

    // Mouse position
    private Vector3 MousePosition()
    {
        return Input.mousePosition;
    }

    // Touch position
    private Vector3 TouchPosition()
    {
        return Input.GetTouch(0).position;
    }
}
