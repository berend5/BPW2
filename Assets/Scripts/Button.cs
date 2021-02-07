using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public LevelExit levelExit;
    public PlayerMovement playerMovement;

    public bool buttonPressed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("FrozenPlayer"))
        {
            buttonPressed = true;
            levelExit.TriggerDoor(buttonPressed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playerMovement.freezeTime == false || other.gameObject.CompareTag("FrozenPlayer"))
        {
            buttonPressed = false;
            levelExit.TriggerDoor(buttonPressed);
        }
    }
}
