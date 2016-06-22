using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health;

	void OnTriggerEnter2D(Collider2D collider) {

		// - Check if a Projectile has hit the enemy
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile != null) {
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
}
