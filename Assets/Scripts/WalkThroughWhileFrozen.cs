using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkThroughWhileFrozen : MonoBehaviour
{
    public GameObject wall;
    public PlayerMovement playerMovement;

    void Update()
    {
        if (playerMovement.freezeTime == true)
        {
            wall.SetActive(false);
        }
        else
        {
            wall.SetActive(true);
        }
    }
}
