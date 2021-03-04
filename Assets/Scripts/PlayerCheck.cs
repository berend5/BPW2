using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    private Collider2D myCollider;
    public PlayerMovement playerMovement;

    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (playerMovement.freezeCounter <= 0.2)
        {
            ChangeCollider(false);
        }
    }
    
    public void ChangeCollider(bool colliderOn)
    {
        myCollider.enabled = colliderOn;
    }
}
