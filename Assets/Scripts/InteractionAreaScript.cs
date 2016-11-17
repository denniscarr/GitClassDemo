using UnityEngine;
using System.Collections;

public class InteractionAreaScript : MonoBehaviour {
    bool triggered;
    public GameObject interactionObject;
	
	void Start () {
		triggered = false;
	}

	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		triggered = true;
		interactionObject = other.gameObject;
	}

	void OnTriggerExit2D() {
		triggered = false;
		interactionObject = null;
	}
}
