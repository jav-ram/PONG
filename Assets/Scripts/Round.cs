using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour {
	public GameObject PrefabBall;

	private GameObject ball;
	// Use this for initialization
	void Start () {
		StartRound ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartRound(){
		GameObject ball = Instantiate(PrefabBall);
		ball.transform.Translate (0, 0, 0);
		float y = Random.Range (-2f, 2f);
		float x = Random.Range (-1f, 1f);
		while (x == 0) {
			x = Random.Range (-1f, 1f);
		}
		ball.GetComponent<Rigidbody2D> ().velocity = new Vector3 (5f*x, y, 0);
	}
}
