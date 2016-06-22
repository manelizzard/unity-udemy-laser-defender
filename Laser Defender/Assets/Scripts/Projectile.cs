using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float damage;

	/// <summary>
	/// Gets the damage this projectile does when hit.
	/// </summary>
	/// <returns>The damage.</returns>
	public float GetDamage() {
		return damage;
	}

	/// <summary>
	/// Notify Projectile has hit something. Destroy itself.
	/// </summary>
	public void Hit() {
		Destroy (gameObject);
	}
}
