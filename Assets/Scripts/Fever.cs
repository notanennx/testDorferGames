using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using TMPro;

public class Fever : MonoBehaviour
{
    // Awake
    public static Fever i;
    void Awake() => i = this;

    // Values
    public int Gems = 0; // Sequental gems collected.
    public int MaxGems = 3; // Gems you have to collect to get fever.
    public float Duration = 5f; // How long fever lasts?
    public float SpeedScale = 3f; // How fast we'll be moving?

    // Enable
    private void OnEnable()
    {
        Events.OnGemCollected += GemCollected;
        Events.OnDummyCollected += DummyCollected;
    }

    // Disable
    private void OnDisable()
    {
        Events.OnGemCollected -= GemCollected;
        Events.OnDummyCollected -= DummyCollected; 
    }

    // Update
    private float activeTime;
    private void Update()
    {
        // Move snake
        if (isActive)
        {
            Snake.i.IFrames = Time.time + 2f;
            Snake.i.SetDestination(new Vector3(0f, 0f, 0f), 1.28f);
        }

        // Disable fever
        if ((activeTime < Time.time) && (isActive))
            SetEnabled(false);
    }

    // Collected gemstone!
    private void GemCollected()
    {
        // Do nothing if fever is on!
        if (isActive) return;

        // Color
        SetTextColor(gemsColor);

        // Sequental gems collected!
        Gems += 1;
        if (Gems >= MaxGems)
        {
            Gems = 0;
            SetEnabled(true);
        }
    }

    // When a random dummy was eaten!
    private void DummyCollected()
    {
        // Do nothing if fever is on!
        if (isActive) return;

        // Reset gems
        Gems = 0;
        SetTextColor(new Color(1f, 1f, 1f, 1f));
    }

    // Setup score UI color
    [SerializeField] private Color gemsColor;
    [SerializeField] private TMP_Text gemsText;
    private void SetTextColor(Color newColor) => gemsText.color = newColor;

    // For enabling or disabling fever!
    private bool isActive = false;
    public void SetEnabled(bool isEnabled)
    {
        // Setup
        isActive = isEnabled;

        // Enabling
        if (isActive)
        {
            // Snake changes
            Snake.i.SpeedScale = SpeedScale;

            // Controller changes and time
            activeTime = Time.time + Duration;
            PlayerController.i.IsActive = false;
        }
        // Disabling
        else
        {
            // Snake changes
            Snake.i.SpeedScale = 1f;
            
            // Resetting gems and controller
            Score.i.SetGems(0);
            PlayerController.i.IsActive = true;
        }
    }
}
