using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public LevelExit levelExit;
    public PlayerMovement playerMovement;

    public bool buttonPressed = false;

    List<string> buttonPressable = new List<string>();

    void Start()
    {
        buttonPressable.Add("Player");
        buttonPressable.Add("FrozenPlayer");
        buttonPressable.Add("Box");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        foreach (string currentTag in buttonPressable)
        {
            if (other.gameObject.tag == currentTag)
            {
                levelExit.TriggerDoor(true);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (string currentTag in buttonPressable)
        {
            if (other.gameObject.tag == currentTag)
            {
                levelExit.TriggerDoor(false);
                buttonPressed = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void Update()
    {
        if(buttonPressed == true)
        {
            //sdafsdf
        }
    }
}