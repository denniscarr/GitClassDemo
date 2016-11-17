using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	public float speed;

	Animator anim;

	public GameObject interactionArea;
	float interactionArea_x;
	float interactionArea_y;
	float interactionOffset = 0.65f;
	public bool interacting = false;
	public GameObject myInteractionObject;


	void Start(){
		anim = GetComponent<Animator> ();
	}


	void Update ()
	{
		/* Interaction */

		InteractionAreaScript interactionAreaScript = GetComponentInChildren<InteractionAreaScript>();
		myInteractionObject = interactionAreaScript.interactionObject;

		interacting = false;
		if ( Input.GetKeyDown(KeyCode.Space) ) {
			interacting = true;
			print ("interacting:" + interacting);
		}


		/* Movement */

		// Get input
		float movement_x = Input.GetAxisRaw ("Horizontal");
		float movement_y = Input.GetAxisRaw ("Vertical");

		// Figure out where the interaction area should be
		if (movement_x != 0) {
			interactionArea_x = interactionOffset * movement_x;
			interactionArea_y = 0;
		} else if (movement_y != 0) {
			interactionArea_y = interactionOffset * movement_y;
			interactionArea_x = 0;
		}

		// Make sure that diagonal movement isn't doubled
		float modified_speed = speed;
		if (movement_x != 0 && movement_y != 0) 
						modified_speed = speed * 0.75f;

		// Modify movement by speed
		movement_x *= modified_speed;
		movement_y *= modified_speed;

		// Move Player
		transform.Translate (movement_x, movement_y, 0);

		// Move Interaction Area
		Vector3 newInteractionAreaPosition = new Vector3(interactionArea_x, interactionArea_y, 1);
		interactionArea.transform.localPosition = newInteractionAreaPosition;

		// Play walking animation
		if (movement_x == 0 && movement_y == 0)
			anim.Play ("Idle", 0);
		else
			anim.Play ("Walking", 0);
	}
}
