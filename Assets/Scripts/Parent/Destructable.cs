using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "DestroyerBound"){
			this.Destroy(gameObject);
		}
	}
}
