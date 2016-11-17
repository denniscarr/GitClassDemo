using UnityEngine;
using System.Collections;

public class NPCScript : MonoBehaviour {

	PlayerMovementScript playerMovementScript;


	void start() {
		playerMovementScript = GetComponent<PlayerMovementScript>();
	}

	void update()
	{
		playerMovementScript = GetComponent<PlayerMovementScript>();

		print (gameObject.name);

		if (playerMovementScript.myInteractionObject.name == gameObject.name)
						print ("it's me");

		if (playerMovementScript.myInteractionObject == this && playerMovementScript.interacting) {
			print ("hi?");
			interact ();
		}
	}


	public void interact() {
		print ("Hi.");
	}
}
