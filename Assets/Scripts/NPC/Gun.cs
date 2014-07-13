using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	/// <summary>
	/// The prefab of the shot this gun will be firing
	/// </summary>
	public Shot shot;
	/// <summary>
	/// The parent of the new instantiated shots
	/// </summary>

	/// <summary>
	/// How much does the gun have to wait so it can shoot again
	/// </summary>
	public float coolDown = .5f;
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

	protected virtual void Shoot(){
		Shot newShot = Instantiate(shot, transform.position, Quaternion.identity) as Shot;
		newShot.transform.parent = this.transform.root;
	}
}
