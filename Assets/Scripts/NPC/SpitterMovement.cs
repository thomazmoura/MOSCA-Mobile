using UnityEngine;
using System.Collections;

public class SpitterMovement : EnemyMovement {

	public int edgeBouncingLimit = 3;
	public int edgeBounces;

	void Start(){
		edgeBounces = 0;
	}
	
	// Update is called once per frame
	protected override void FlipX () {
		if(edgeBounces <= edgeBouncingLimit){
			base.FlipX();
			edgeBounces++;
		}
	}
}
