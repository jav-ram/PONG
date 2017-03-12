using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	public GameObject ball;
	public float maxSpeed;
	public GameObject camera;

	public Text s1;
	public Text s2;
	private float m; 
	private Rigidbody2D rb;
	private Vector2 v;

	// Use this for initialization
	void Start () {
		s1 = GameObject.Find("S1").GetComponent<Text>();
		s2 = GameObject.Find("S2").GetComponent<Text>();
		rb = ball.GetComponent<Rigidbody2D> ();
		v = rb.velocity;

	}
	
	// Update is called once per frame
	void Update () {
		
		m = rb.velocity.magnitude;

		if (rb.velocity.x < 5f && rb.velocity.x > -5f) {
			if (rb.velocity.x > 0) {
				rb.velocity = new Vector2 (5f, rb.velocity.y);
			} else if(rb.velocity.x < 0) {
				rb.velocity = new Vector2 (-5f, rb.velocity.y);				
			}
		}

	}

	void OnCollisionEnter2D(Collision2D other){
		
		if (m > 0 && m < maxSpeed) {
			if (rb.velocity.x > 0) {
				rb.velocity += v * 0.1f;
			} else if (rb.velocity.x < 0){
				rb.velocity -= v * 0.1f;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		int score = 0;
		if (other.gameObject.tag.Equals ("Out")) {
			Destroy (this.gameObject);
			if (other.gameObject.name.Equals ("Right")) {
				score = (int.Parse(s1.text)) + 1;
				s1.text = "" + score;
			} else if (other.gameObject.name.Equals ("Left")){
				score = (int.Parse(s2.text)) + 1;
				s2.text = "" + score;
			}
			StartCoroutine (Example (0.2f));
			GameObject.Find ("Main Camera").GetComponent<Round> ().StartRound();


		}

	}

	IEnumerator Example(float time){
		Debug.Log ("Antes");
		yield return new WaitForSeconds(time);
		Debug.Log ("Despues");
	}

}
