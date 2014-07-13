using UnityEngine;
using System.Collections;

public class PlayerHealthBehaviour : HealthBehaviour {

	/// <summary>
	/// Amount of time the player will be made invulnerable after hit
	/// </summary>
	public float invulnerabilityDelay = .25f;

	/// <summary>
	/// The particle effects of the smoke (life indicator)
	/// </summary>
	public ParticleSystem smokeParticles;

	/// <summary>
	/// The particle effects of the flame (critical life indicator)
	/// </summary>
	public ParticleSystem flameParticles; 

	/// <summary>
	/// The initial emission rate for the particle smoke
	/// </summary>
	public float smokeEmissionRate = 15f;

	private bool invulnerable;
	private SpriteRenderer _renderer;

	public override float CurrentHealth {
		get {
			return base.CurrentHealth;
		}
		protected set {
			base.CurrentHealth = value;
			smokeParticles.emissionRate = smokeEmissionRate * (1 - LifePercent);
			if(LifePercent < .3f){
				flameParticles.enableEmission = true;
				flameParticles.emissionRate = smokeEmissionRate * (1 - (LifePercent*3));
			}else
				flameParticles.enableEmission = false;
		}
	}

	protected override void Start ()
	{
		base.Start ();
		invulnerable = false;
		_renderer = GetComponent<SpriteRenderer>();
	}

	public override void Die(){
		Score.ResetScore();
		Application.LoadLevel(0);
	}

	public override void TakeDamage (float damage)
	{
		if(!invulnerable){
			base.TakeDamage (damage);
			StartCoroutine(TurnInvulnerable());
		}
	}

	IEnumerator TurnInvulnerable(){
		invulnerable = true;
		_renderer.color = new Color(1f, .5f, .5f, .5f);
		for(float delay = 0; delay < invulnerabilityDelay; delay += Time.deltaTime){
			yield return null;
		}
		invulnerable = false;
		_renderer.color = new Color(1f, 1f, 1f, 1f);
	}
}
