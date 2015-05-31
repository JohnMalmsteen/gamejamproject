using UnityEngine;
using System.Collections;

public class TTL : MonoBehaviour {

	public float ttl;

	// Use this for initialization
	void Start () {
		StartCoroutine (startDeathClock ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator startDeathClock(){
		yield return new WaitForSeconds (ttl);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name != "Player") {
			Destroy(gameObject);
		}
	}
}
