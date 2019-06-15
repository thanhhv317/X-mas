using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    Animator anim;
    Rigidbody2D myBody;

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float jumpHigh = 5f;
    public bool facingRight;
    private bool grounded;

    //shoot bullet
    [SerializeField]
    private float coolDown = 2f;
    private float timeRate = 1f;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform pos;

    //health point
    [SerializeField]
    private float maxHp = 20;
    public float currentHp;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }
    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("run", Mathf.Abs(move));
        myBody.velocity = new Vector2(move * speed, myBody.velocity.y);
        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump();
        }
        if ( Input.GetKey(KeyCode.Q))
        {
            shoot();
            
        }
        if (currentHp <= 0)
        {
            dead();
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void jump()
    {
        anim.SetBool("jump", true);
        if (grounded)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpHigh);
            grounded = false;
        }
    }
    void shoot()
    {
        
        if (Time.time > timeRate)
        {
            anim.SetTrigger("attack");
            timeRate = Time.time + coolDown;
            Instantiate(bullet, pos.position, Quaternion.identity);
            
        }
    }
    void dead()
    {
        speed = 0;
        anim.SetBool("dead", true);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            grounded = true;
            anim.SetBool("jump", false);
        }
        if (target.gameObject.tag == "Thorns")
        {
            dead();
        }
    }
}
