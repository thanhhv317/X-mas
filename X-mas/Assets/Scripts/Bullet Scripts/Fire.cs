using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public float speed = 3f;
    Rigidbody2D mybody;

	// Use this for initialization
	void Start () {
        mybody = GetComponent<Rigidbody2D>();
        if (PlayerMovement.instance.facingRight)
        {
            mybody.velocity = new Vector2(speed, mybody.velocity.y);
        }
        if (PlayerMovement.instance.facingRight == false)
        {
            mybody.velocity = new Vector2(-speed, mybody.velocity.y);
            transform.localScale *= -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
