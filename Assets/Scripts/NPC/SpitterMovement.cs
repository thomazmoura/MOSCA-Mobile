using UnityEngine;
using System.Collections;

/// <summary>
/// Especializacao do EnemyMovement para o cuspidor (acrescenta a contagem de "trocas"
/// </summary>
public class SpitterMovement : EnemyMovement {
	/// <summary>
	/// Quantas vezes o cuspidor pode trocar
	/// </summary>
	public int edgeBouncingLimit = 3;
	//Quantidade de trocas ja feitas
	private int edgeBounces;

	void Start(){
		edgeBounces = 0;
	}
	
	/// <summary>
	/// Metodo especializado para inverter a posicao (e contar a troca)
	/// </summary>
	protected override void FlipX () {
		if(edgeBounces <= edgeBouncingLimit){
			base.FlipX();
			edgeBounces++;
		}
	}
}
