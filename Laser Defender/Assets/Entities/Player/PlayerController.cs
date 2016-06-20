using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 1.0f;

	float xmin;
	float xmax;

	void Start() {

		// - Calculate the end of the game space
		float distance = transform.position.z - Camera.main.transform.position.z;
		xmin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x + padding;
		xmax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x - padding;
	}

	void Update () {
	
		Vector3 currentPosition = gameObject.transform.position;

		if (Input.GetKey(KeyCode.LeftArrow)) {
			// - Move left
			transform.position += Vector3.left * speed * Time.deltaTime;

		} else if (Input.GetKey(KeyCode.RightArrow)) {
			// - Move right
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
			
		// - Restrict the player to the game space
		float finalXPosition = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (finalXPosition, transform.position.y, transform.position.z);
	}
}
