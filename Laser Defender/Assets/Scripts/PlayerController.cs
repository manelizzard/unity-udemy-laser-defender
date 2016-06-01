using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;

	void Update () {
	
		Vector3 currentPosition = gameObject.transform.position;

		if (Input.GetKey(KeyCode.LeftArrow)) {
			// - Move left
			transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			// - Move right
			transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
		}
	}
}
