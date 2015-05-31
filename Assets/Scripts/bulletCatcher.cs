using UnityEngine;
using System.Collections;

public class bulletCatcher : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.name.Equals("bullet(Clone)")){
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
