using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float direction;
    public float speed;
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        if (playerMovement.freezeTime == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed * direction, transform.position.z);
        }
    }
}
