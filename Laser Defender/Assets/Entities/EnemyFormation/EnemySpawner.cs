using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	/// <summary>
	/// Prefab for the enemies to be spanwed
	/// </summary>
	[SerializeField] GameObject enemyPrefab;

	[SerializeField] float width = 10f;
	[SerializeField] float height = 5f;

	/// <summary>
	/// Speed of the formation movement
	/// </summary>
	[SerializeField] float speed = 5f;

	/// <summary>
	/// The max value of the x axis the formation can take
	/// </summary>
	float xmax;

	/// <summary>
	/// The min value of the x axis the formation can take
	/// </summary>
	float xmin;

	/// <summary>
	/// Boolean to switch movement from right to left and viceversa
	/// </summary>
	bool movingRight = false;

	void Start () {

		// - Calculate the end of the game space
		float distance = transform.position.z - Camera.main.transform.position.z;
		xmin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance)).x;
		xmax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance)).x;

		SpawnEnemies ();
	}

	/// <summary>
	/// Spawns the enemies inside each 'Position' GameObject
	/// </summary>
	private void SpawnEnemies() {
		// - Instantiate enemies and attach them under the EnemyFormation positions
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	// Update is called once per frame
	void Update () {

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
		if (leftEdgeOfFormation < xmin) {
			movingRight = true;
		} else if(rightEdgeOfFormation > xmax) {
			movingRight = false;
		}
	
		if (AllMembersDeath ()) {
			SpawnEnemies ();
		}
	}

	/// <summary>
	/// Checks if all the enemies are dead
	/// </summary>
	/// <returns><c>true</c>, if members death was alled, <c>false</c> otherwise.</returns>
	private bool AllMembersDeath() {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}

		return true;
	}

	/// <summary>
	/// Gizmos drawing for easier game development
	/// </summary>
	public void OnDrawGizmos() {
		// - Draw the limits of the formation
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
}
