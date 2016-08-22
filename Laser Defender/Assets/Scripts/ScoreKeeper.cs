using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text scoreText;
	public static int score;

	void Start () {
		Reset ();
		scoreText = GetComponent<Text> ();
		scoreText.text = score.ToString ();
	}
	
	public void Score(int points) {
		ScoreKeeper.score += points;
		scoreText.text = score.ToString ();
	}

	public static void Reset() {
		ScoreKeeper.score = 0;
	}
}
