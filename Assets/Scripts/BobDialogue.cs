using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BobDialogue : MonoBehaviour {
	public int paranoia = 0;
	private string[] question1Answers = {"It was over there on the hillside!", "That's my business - and who do you think you are coming round here asking questions anyway?"};
	private string[] question2Answers = {"Damn things were blue like the sky! Never seen anything like it man!", "Man, what difference does it make? Stop hassling me!"};
	private string[] question3Answers = {"They were pretty small little things, like weird dogs or something!", "Say, why're you asking me this stuff anyway?"};
	private string[] question4Answers = {"Dang weird things looked like tripods!", "...What kind of question is that? Leave me alone!"};
	public string bobText;

	private Text bobsTextField;

	void Start(){
		bobsTextField = GameObject.Find ("bobText").GetComponent<Text>();
		bobText = "Yo man, did you see this shit round here?!";
	}

	void Update(){
		if (paranoia >= 100) {
			GameObject player = GameObject.Find ("Player");
			player.GetComponent<MoveThing> ().movementEnabled = true;
			GameObject bobSprite = GameObject.Find("Bob");
			bobSprite.GetComponent<bulletCatcher>().RunAway();
			Destroy (gameObject);
		}
		bobsTextField.text = bobText;
	}
	

	public void Button1Click(){
		if (Random.Range (0f, 1f) > (float)paranoia / 100f) {
			bobText = question1Answers [0];
		} else {
			bobText = question1Answers[1];
		}
		paranoia += (int)Random.Range (20f, 61f);
	}

	public void Button2Click(){
		if (Random.Range (0f, 1f) > (float)paranoia / 100f) {
			bobText = question2Answers [0];
		} else {
			bobText = question2Answers[1];
		}
		paranoia += (int)Random.Range (10f, 31f);
	}

	public void Button3Click(){
		if (Random.Range (0f, 1f) > (float)paranoia / 100f) {
			bobText = question3Answers [0];
		} else {
			bobText = question3Answers[1];
		}
		paranoia += (int)Random.Range (5f, 16f);
	}

	public void Button4Click(){
		if (Random.Range (0f, 1f) > (float)paranoia / 100f) {
			bobText = question4Answers [0];
		} else {
			bobText = question4Answers[1];
		}
		paranoia += (int)Random.Range (5f, 16f);
	}

	public void Neuralize(){
		GameObject player = GameObject.Find ("Player");
		player.GetComponent<MoveThing> ().movementEnabled = true;
		GameObject bobsSprite = GameObject.Find ("Bob");
		Destroy (bobsSprite);
		Destroy (gameObject);
	}
}
