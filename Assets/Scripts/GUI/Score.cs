using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	/// <summary>
	/// Campo privado para armazenar o placar real
	/// </summary>
	private static int score;

	/// <summary>
	/// Metodo acessador que retorna o placar atual
	/// </summary>
	/// <value>O placar atual.</value>
	public static int CurrentScore{
		get {
			return score;
		}
	}

	/// <summary>
	/// Metodo para acrescentar pontos ao placar
	/// </summary>
	/// <param name="scoreAmount">Quantidade de pontos a ser acrescentada.</param>
	public static void AddScore(int scoreAmount){
		if(scoreAmount > 0)
			score += scoreAmount;
	}

	/// <summary>
	/// Reseta o placar
	/// </summary>
	public static void ResetScore(){
		score = 0;
	}
}
