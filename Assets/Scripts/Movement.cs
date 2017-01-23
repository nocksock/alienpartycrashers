using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Player))]

public class Movement : MonoBehaviour {
	[SerializeField] float speed = 5f;

	Rigidbody rb;
	string horizontalAxisIdentifier;
	string verticalAxisIdentifier;

	public float force = 10.0f;
	private float eps = 1e-4f;
	Vector3 movement;
	RandomMovement rndMovement;

	LastActivity lastActivity;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		int playerID = GetComponent<Player>().id;
		horizontalAxisIdentifier = "Player" + playerID + "_Horizontal";
		verticalAxisIdentifier = "Player" + playerID + "_Vertical";
		lastActivity = GetComponent<LastActivity> ();
		rndMovement = GetComponent<RandomMovement> ();
	}

	void Move(float h, float v) {
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		if(movement.sqrMagnitude > 0.2) {
			rndMovement.enabled = false	;
		} else {
			rndMovement.enabled = true;
		}

		rb.MovePosition(transform.position + movement);
	}

	void FixedUpdate () {
		float horizontal = Input.GetAxis (horizontalAxisIdentifier);
		float vertical = Input.GetAxis (verticalAxisIdentifier);
	
		Move(horizontal, vertical);

		if (lastActivity != null) {
			if (Mathf.Abs (horizontal) > eps || Mathf.Abs (vertical) > eps) {
				lastActivity.updateLastActivity ();
			}
		}
	}
}