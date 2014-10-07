using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SpawnController : MonoBehaviour
{
	/// <summary>
	/// The prefab to spawn.
	/// </summary>
	public Transform spawnPrefab;

	/// <summary>
	/// The spawn rate in seconds.
	/// </summary>
	public int spawnRate = 3;

	/// <summary>
	/// Max amount of alive objects.
	/// </summary>
	public int maxCount = 1;

	//----------------------------------------------------------------------------

	private List<Transform> spawnedObjects;

	void Start()
	{
		this.spawnedObjects = new List<Transform>();
		StartCoroutine(this.Spawner());
	}

	private IEnumerator Spawner()
	{
		while(true)
		{
			if(this.enabled)
			{
				this.Spawn();
				yield return new WaitForSeconds(this.spawnRate);
			}
			else
			{
				yield break;
			}
		}
	}
	
	private void Spawn()
	{
		this.spawnedObjects.RemoveAll(item => item == null);
		if(this.spawnedObjects.Count < this.maxCount)
		{
			var spawnedTransform = Instantiate(this.spawnPrefab) as Transform;
			spawnedTransform.position = this.transform.position;

			this.spawnedObjects.Add(spawnedTransform);
		}
	}
}
