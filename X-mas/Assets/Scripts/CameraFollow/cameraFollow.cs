using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing;

    Vector3 offset;
    float lowY;



    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;

        lowY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (PlayerMovement.instance.facingRight)
        //{
        //    offset = transform.position - target.position;
        //}
        //if (PlayerMovement.instance.facingRight == false)
        //{
        //    offset = target.position - transform.position;
        //}
        Vector3 targetCamPos = target.position + offset;
   
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        if (transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
        // khoa camera ko cho di chuyen theo truc y
        if (transform.position.y > lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
