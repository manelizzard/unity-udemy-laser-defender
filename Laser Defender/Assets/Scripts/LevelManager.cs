using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Level manager class used to handle scene changes.
/// </summary>
public class LevelManager : MonoBehaviour {

	/// <summary>
	/// Loads the desired scene.
	/// </summary>
	/// <param name="name">The name of the scene as string.</param>
	public void LoadLevel(string name) {
		SceneManager.LoadScene (name);
	}

	/// <summary>
	/// Quits the application (if application can be quitted).
	/// </summary>
	public void QuitRequest() {
		Application.Quit ();
	}

	/// <summary>
	/// Loads the next level set in the BuildSettings
	/// </summary>
	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
