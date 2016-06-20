using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] GameObject enemyPrefab;

	[SerializeField] float width = 10f;
	[SerializeField] float height = 5f;
	[SerializeField] float speed = 5f;

	float xmax;
	float xmin;

	bool movingRight = false;

	void Start () {

		// - Calculate the end of the game space
		float distance = transform.position.z - Camera.main.transform.position.z;
		xmin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x;
		xmax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x;

		// - Instantiate enemies and attach them under the EnemyFormation positions
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = gameObject.transform.position;

		if (movingRight) {
			// - Move formation right
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			// - Move formation left
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		// - Detect direciton change
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		if (leftEdgeOfFormation < xmin || rightEdgeOfFormation > xmax) {
			movingRight = !movingRight;
		}
	
	}

	public void OnDrawGizmos() {
		// - Draw the limits of the formation
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
}
