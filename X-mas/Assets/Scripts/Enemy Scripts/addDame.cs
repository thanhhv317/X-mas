using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addDame : MonoBehaviour {
    [SerializeField]
    private float dame = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            PlayerMovement.instance.currentHp -= dame;
        }
    }
}
