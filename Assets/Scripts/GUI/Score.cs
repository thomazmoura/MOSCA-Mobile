using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private static int score;

	public static int CurrentScore{
		get {
			return score;
		}
	}

	public static void AddScore(int scoreAmount){
		if(scoreAmount > 0)
			score += scoreAmount;
	}

	public static void ResetScore(){
		score = 0;
	}
}
