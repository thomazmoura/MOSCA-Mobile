using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	/// <summary>
	/// O prefab do tiro que sera disparado
	/// </summary>
	public Shot shot;

	/// <summary>
	/// Quanto tempo o gun devera esperar para poder disparar de novo
	/// </summary>
	public float coolDown = .5f;
	//Armazena o valor do timer
	private float currentCoolDown;
	
	// Update is called once per frame
	protected virtual void Update () {
		if(currentCoolDown < coolDown){
			currentCoolDown += Time.deltaTime;
			if(currentCoolDown >= coolDown){
				currentCoolDown = 0;
				Shoot();
			}
		}
	}

	/// <summary>
	/// Metodo para criar o tiro propriamente dito
	/// </summary>
	protected virtual void Shoot(){
		Shot newShot = Instantiate(shot, transform.position, Quaternion.identity) as Shot;
		newShot.transform.parent = this.transform.root;
	}
}
