using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    public bool wantToPickUp;

    void Start()
    {
        wantToPickUp = false;
    }

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (Input.GetKeyDown(KeyCode.LeftShift) && wantToPickUp == false)
        {
            if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
            {
                wantToPickUp = true;
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift) && wantToPickUp == true)
        {
            wantToPickUp = false;
        }

        //RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (wantToPickUp)
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
