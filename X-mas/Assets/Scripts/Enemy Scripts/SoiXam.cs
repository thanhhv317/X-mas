using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoiXam : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;
    Animator anim;
    Rigidbody2D myBody;
    bool facingRight;
    [SerializeField]
    private float maxHp = 20;
    private float currentHp;
    [SerializeField]
    private float dame = 5;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
        currentHp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        if (currentHp <= 0)
        {
            speed = 0;
            anim.SetBool("dead", true);
            Destroy(gameObject, 1f);
        }
	}


    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        speed *= -1;
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "Ground" &&currentHp>0)
        {
            flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            currentHp -= 10;
        }
        if (target.tag == "Player")
        {
            PlayerMovement.instance.currentHp -= dame;
            anim.SetBool("attack", true);
            StartCoroutine(delay());
        }

    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("attack", false);
    }
}
