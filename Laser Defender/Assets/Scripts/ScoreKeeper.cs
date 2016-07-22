using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	private Text scoreText;
	private int score;

	void Start () {
		scoreText = GetComponent<Text> ();
		score = 0;
	}
	
	public void Score(int points) {
		this.score += points;
		scoreText.text = score.ToString ();
	}

	public void Reset() {
		this.score = 0;
		scoreText.text = score.ToString ();
	}
}
