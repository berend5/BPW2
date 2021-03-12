using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class InstantiateMovingPlatform : MonoBehaviour
{
    public GameObject spawnPlatform;
    public PlayerMovement playerMovement;
    public float timer;
    public float reset;

    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            //Instantiate(spawnPlatform, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
            Destroy(other.gameObject);
        }
    }

    public void Update()
    {
        if(playerMovement.freezeTime == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Instantiate(spawnPlatform, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
                timer = reset;
            }
        }
    }
}
