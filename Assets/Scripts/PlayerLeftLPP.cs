using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeftLPP : MonoBehaviour
{
    public PlayerCheck playerCheck;
    public PlayerMovement playerMovement;

    public bool playerLeft;

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCheck.ChangeCollider(true);
            ChangeLayer(8);
            Debug.Log("hey");
        }
    }

    public void ChangeLayer(int newLayer)
    {
        gameObject.layer = newLayer;
    }
    /*public void AfterCountDown()
    {
        playerCheck.ChangeCollider(true);
                ChangeLayer(8);
                Debug.Log("hey"); ;
    }*/
}