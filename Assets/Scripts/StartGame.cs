using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public void ClickStart(){
		Debug.Log ("Button Pressed");
		GameObject dialogue = GameObject.Find ("introDialogue(Clone)");
		GameObject player = GameObject.Find ("Player");
		player.GetComponent<MoveThing> ().movementEnabled = true;
		Destroy (dialogue);
	}
}
