using UnityEngine;
using System.Collections;

public class HealthBehaviour : MonoBehaviour {

	public float maxHealth;
	private float currentHealth;

	// Use this for initialization
	protected virtual void Start () {
		CurrentHealth = maxHealth;
	}

	public virtual float CurrentHealth{
		get{ return currentHealth; }
		protected set { currentHealth = value; }
	}

	public virtual float LifePercent{
		get {return CurrentHealth / maxHealth; }
	}

	public virtual void TakeDamage(float damage){
		//Only positive damage shall be taken in account
		if(damage < 0)
			return;

		CurrentHealth -= damage;
		if(CurrentHealth < 0){
			this.Die ();
		}
	}

	//Standard death behaviour
	public virtual void Die(){
		this.Destroy(gameObject);
	}
}
