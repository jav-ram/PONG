using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public GameObject player;
	public float speed;

	private Rigidbody2D rb;
	private bool actualP;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		if (player.tag.Equals ("P1")) {
			actualP = true;
		} else if (player.tag.Equals ("P2")) {
			actualP = false;
		}
		rb = player.GetComponent<Rigidbody2D>();
		speed = speed * 20;
	}
	
	// Update is called once per frame
	void Update () {
		if (actualP) {
			moveP1 ();
		} else {
			moveP2 ();
		}
	}

	public void moveP2(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb.velocity = new Vector2 (0, speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			rb.velocity = new Vector2 (0, -speed * Time.deltaTime);
		} else {
			rb.velocity = new Vector2 (0,0);
		}
	}

	public void moveP1(){
		if (Input.GetKey (KeyCode.W)) {
			rb.velocity = new Vector2 (0,speed*Time.deltaTime);
		} else if (Input.GetKey (KeyCode.S)) {
			rb.velocity = new Vector2 (0,-speed*Time.deltaTime);
		} else {
			rb.velocity = new Vector2 (0,0);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag.Equals ("Ball")) {
			audio.Play ();
		}
			

	}


}
