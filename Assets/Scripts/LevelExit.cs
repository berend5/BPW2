using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public GameObject exit;
    public Button button;

    public void TriggerDoor(bool doorOpen)
    {
        if (doorOpen == true)
        {
            exit.SetActive(false);
            Debug.Log("open exit");
        }

        if (doorOpen == false)
        {
            exit.SetActive(true);
            Debug.Log("closed exit");
        }
    }
}