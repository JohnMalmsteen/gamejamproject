using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MoveThing : MonoBehaviour {
	public float runspeed = 500f;
	public GameObject bullet;
	public bool firstMove = true;
	public bool movementEnabled = false;
	public Sprite[] walk = new Sprite[8];
	public Sprite[] walkLeft = new Sprite[8];
	public Sprite[] walkUp =new Sprite[8];
	public Sprite staticFrame;
	public float animateSpeed;
	public bool walking;

	public GameObject dialogue;
	public GameObject bobDialogue;
	private float movex = 0f;
	private float movey = 0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		movex = 0f;
		movey = 0f;
		if (firstMove) {
			if(Input.anyKey){
				Instantiate(dialogue, transform.position, Quaternion.identity);
				firstMove = false;
			}
		} else if(movementEnabled){

			if (Input.GetKey (KeyCode.W)) {

				movey = 1f;
			}

			if (Input.GetKey (KeyCode.S)) {
				movey = -1f;
			}

			if (Input.GetKey (KeyCode.A)) {

				movex = -1f;
			}

			if (Input.GetKey (KeyCode.D)) {
				if(!walking){
					walking = true;

					StartCoroutine("Animate");
				}
				movex = 1f;
			}

			if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W)){
				StopCoroutine("Animate");
				walking=false;
				GetComponent<SpriteRenderer>().sprite = staticFrame;

			}

			if (!EventSystem.current.IsPointerOverGameObject ()){
				if (Input.GetMouseButtonDown (0)) {
					FireBullet ();
				}
			}

		}

	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.name == "Bob") {
			Instantiate(bobDialogue, transform.position, Quaternion.identity);
			movementEnabled = false;
		}
	}

	void FixedUpdate(){
		transform.GetComponent<Rigidbody2D> ().position = new Vector2(transform.position.x + (runspeed*movex), transform.position.y + (runspeed*movey));
	}

	void FireBullet(){
		GameObject newBullet = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
		Vector2 direction = ((Vector2)Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20)) - (Vector2)transform.position).normalized;
		if (movex != 0 || movey != 0f) {
			direction.x += Random.Range (-.1f, .1f);
			direction.y += Random.Range (-.1f, .1f);
		} 
		newBullet.GetComponent<Rigidbody2D> ().AddForce (direction * 1800f);
	}

	private IEnumerator Animate()
	{
		while (walking) {
			foreach (Sprite frame in walk) {
				GetComponent<SpriteRenderer> ().sprite = frame;	
				yield return new WaitForSeconds (animateSpeed);
			}
		}
	}
}
