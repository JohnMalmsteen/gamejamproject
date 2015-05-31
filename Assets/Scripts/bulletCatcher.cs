using UnityEngine;
using System.Collections;

public class bulletCatcher : MonoBehaviour {
	public Sprite [] bobSit = new Sprite[2];
	public Sprite [] bobRun = new Sprite[8];
	public Sprite [] bobDeath = new Sprite[8];
	public Sprite [] flash = new Sprite[7];
	public bool sitting = true;
	public bool running;
	public bool bobIsDead;
	public float animateSpeed;
	public GameObject gameOver;
	public GameObject player;
	public GameObject flasher;

	// Use this for initialization
	void Start () {
		StartCoroutine ("sitAnimation");
		bobIsDead = false;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.name.Equals("bullet(Clone)")){
			Destroy(collision.gameObject);
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			GetComponent<CircleCollider2D>().enabled = false;
			StopCoroutine("RunAwayBob");
			StopCoroutine("turningTime");
			StopCoroutine("sitAnimation");
			StartCoroutine("BobDeath");
			player.GetComponent<MoveThing>().movementEnabled = false;

			StartCoroutine("gameOverScreen");
			bobIsDead = true;
		}
	}

	public IEnumerator sitAnimation(){
		while (sitting) {
			foreach (Sprite frame in bobSit) {
				GetComponent<SpriteRenderer> ().sprite = frame;	
				yield return new WaitForSeconds (Random.Range (1f, 6f));
			}
		}
	}

	public IEnumerator RunAwayBob(){
		while (running) {
			foreach(Sprite frame in bobRun){
				GetComponent<SpriteRenderer>().sprite = frame;
				yield return new WaitForSeconds(animateSpeed);
			}
		}
	}

	public IEnumerator BobDeath(){
		foreach (Sprite frame in bobDeath) {
			GetComponent<SpriteRenderer>().sprite = frame;
			yield return new WaitForSeconds(1f);
		}
	}

	public IEnumerator turningTime(){
		yield return new WaitForSeconds (2f);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-18f + Random.Range(-3f, 3f), 18f + Random.Range(-3f, 3f));
		yield return new WaitForSeconds (1f);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-20f + Random.Range(-3f, 3f), -20f + Random.Range(-3f, 3f));
		yield return new WaitForSeconds (2f);
		if (!bobIsDead) {
			player.GetComponent<MoveThing>().movementEnabled = false;
			StartCoroutine("gameOverScreen");
		}

	}

	public IEnumerator gameOverScreen(){
		yield return new WaitForSeconds (3f);
		Instantiate(gameOver, transform.position, Quaternion.identity);
		yield return new WaitForSeconds (2f);
		Application.LoadLevel (0);

	}

	public void RunAway(){
		GameObject bobDia = GameObject.Find ("bobDialogue(Clone)");
		Destroy (bobDia);
		sitting = false;
		running = true;
		StopCoroutine ("sitAnimation");
		StartCoroutine ("RunAwayBob");

		GetComponent<Rigidbody2D> ().velocity = new Vector2(-15f + Random.Range(-3f, 3f), -15f + Random.Range(-3f, 3f));
		StartCoroutine ("turningTime");
	}

	public IEnumerator flashAnim(){
		StopCoroutine ("sitAnimation");
		GameObject flashSprite = (GameObject) Instantiate (flasher, transform.position, Quaternion.identity);
		foreach (Sprite frame in flash) {
			flashSprite.GetComponent<SpriteRenderer>().sprite = frame;
			yield return new WaitForSeconds(.1f);
		}
		Destroy (flashSprite);
		StartCoroutine("gameOverScreen");
	}
}
