using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton Music Player persisted among scenes
/// </summary>
public class MusicPlayer : MonoBehaviour {

	/// <summary>
	/// The instance (singleton)
	/// </summary>
	static MusicPlayer instance = null;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake() {

		// - If we already created a MusicPlayer, destroy the current one
		if (instance != null) {
			Destroy (gameObject);
		} else {
			// - The first time this script is created, save its instance
			instance = this;

			// - Avoid this object to be destroyed along the scenes
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
