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

	//---------------------------------------------------------------------------------------------------------------------------

	private List<Transform> spawnObjects;

	void Start()
	{
		this.spawnObjects = new List<Transform>();
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
		this.spawnObjects.RemoveAll(item => item == null);
		if(this.spawnObjects.Count < this.maxCount)
		{
			var spawnTransform = Instantiate (this.spawnPrefab) as Transform;
			spawnTransform.position = transform.position;
			this.spawnObjects.Add(spawnTransform);
		}
	}
}
