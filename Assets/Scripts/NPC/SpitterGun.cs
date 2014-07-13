using UnityEngine;
using System.Collections;

public class SpitterGun : Gun {
	/// <summary>
	/// O cuspidor ao qual esse spitter esta associado
	/// </summary>
	public Animator cuspidor;

	// Update is called once per frame
	protected override void Shoot(){
		cuspidor.SetTrigger("Spit");
		StartCoroutine(DelayedShoot(.2f));
	}

	IEnumerator DelayedShoot(float waitTime){
		for(float wait = 0; wait < waitTime; wait += Time.deltaTime)
			yield return null;
		base.Shoot();
	}
}
