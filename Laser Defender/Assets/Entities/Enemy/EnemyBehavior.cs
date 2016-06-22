using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health;

	public GameObject laserPrefab;
	public float projectileSpeed;
	public float shotsPerSecond = 0.5f;

	void OnTriggerEnter2D(Collider2D collider) {

		// - Check if a Projectile has hit the enemy
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile != null && collider.gameObject.tag == "Player") {
			// - Make the enemy get the damage
			float damage = missile.damage;
			TakeDamage (damage);

			// - Notify projectile to destroy itself
			missile.Hit();
		}
	}

	/// <summary>
	/// Takes the damage from the projectile.
	/// </summary>
	/// <param name="damage">Damage.</param>
	void TakeDamage(float damage) {
		health -= damage;

		// - If health reaches 0, destroy itself
		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	void Update() {
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) {
			Fire ();
		}
	}

	/// <summary>
	/// Shot projectile towards the user
	/// </summary>
	void Fire() {
		GameObject bullet = Instantiate(laserPrefab, this.transform.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
	}
}
