using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpBack : MonoBehaviour
{
    public GameObject box;
    public GameObject player;
    public Transform tpBackPos;

    void Start()
    {

    }


    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            player.transform.position = tpBackPos.transform.position;
            Debug.Log("tp player back");
        }

        if (other.transform.CompareTag("Box"))
        {
            box.transform.position = tpBackPos.transform.position;
        }
    }
}
