using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {

    [SerializeField]
    public float speed = 4f;
    Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        move();
	}
    void move()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            speed *= -1;
        }
    }
}
