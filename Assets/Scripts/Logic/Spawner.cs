using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	/// <summary>
	/// The prefab that will be instantiated.
	/// </summary>
	public Transform prefab;

	/// <summary>
	/// The spawn time (interval between instantiations).
	/// </summary>
	public float spawnTime;

	/// <summary>
	/// Max value that should be randomly added to the position
	/// </summary>
	public Vector2 randomOffset;

	/// <summary>
	/// The transform that will be the parent of the prefab wich will be instantiated.
	/// </summary>
	public Transform spawnParent;

	private float timeSpent;
	
	// Update is called once per frame
	void Update () {
		timeSpent += Time.deltaTime;
		if(timeSpent >= spawnTime){
			timeSpent = 0;
			Transform newObject = Instantiate(prefab,
			            new Vector3(transform.position.x + Randomizer.NextCenterFloat(randomOffset.x),
			            transform.position.y + Randomizer.NextCenterFloat(randomOffset.y), transform.position.z),
			            Quaternion.identity) as Transform;
			newObject.parent = spawnParent;
		}
	}
}
