using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 1.0f;
	public GameObject laserPrefab;
	public float projectileSpeed;
	public float fireRate;

	float xmin;
	float xmax;

	void Start() {

		// - Calculate the end of the game space
		float distance = transform.position.z - Camera.main.transform.position.z;
		xmin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x + padding;
		xmax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x - padding;
	}
	
	void Fire() {
		GameObject bullet = Instantiate(laserPrefab, this.transform.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
	}

	void Update () {
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

		// - Start/stop firing 
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("Fire", 0.000001f, fireRate);
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("Fire");
		}
	}
}
