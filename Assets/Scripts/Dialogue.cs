using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public bool inDialogue;
    public GameObject dialogue;

    void Start()
    {
        Time.timeScale = 0;
        inDialogue = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 1;
            inDialogue = true;
            dialogue.SetActive(false);
        }
    }
}
