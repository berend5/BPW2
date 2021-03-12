using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class LevelExit : MonoBehaviour
{
    public GameObject exit;
    public Button button;
    public Collider2D collider2D;

    public float doorPos = 0;
    float time;
    float posy;
    bool doorOpen2;
    public float doorOpenDistance;
    public float doorSpeed;

    void Start()
    {
        posy = transform.position.y + doorOpenDistance;
    }
    public void TriggerDoor(bool doorOpen)
    {
        if (doorOpen != doorOpen2) time = 0;
        
        if (doorOpen == true)
        {
            time = time + Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, posy, transform.position.z), time / doorSpeed);
            
            if (transform.position.y >= posy)
            {
                time = 0;
            }
        }
        doorOpen2 = doorOpen;
    }

    public void Update()
    {
        if (doorOpen2 == false)
        {
            time = time + Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, posy - doorOpenDistance, transform.position.z), time / doorSpeed);

            if (transform.position.y <= posy - doorOpenDistance)
            {
                time = 0;
            }
        }
    }
}