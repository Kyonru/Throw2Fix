using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSpawner : MonoBehaviour
{
	public float spawnTime = 5f;
	public Transform[] spawnPositions;
	public GameObject[] objectives;
    public bool reflectObjectives;

	private GameObject localObjective;
	private float localRespawnTime = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
		this.SpawnObjective();
   	}

    // Update is called once per frame
    void Update()
    {
        if (localRespawnTime >= spawnTime)
		{
            localRespawnTime = 0f;
            this.SpawnObjective();
		} else
        {
            localRespawnTime += 1 * Time.deltaTime;
        }
    }


    public void SpawnObjective()
	{

		if (objectives == null || spawnPositions == null) return;
		int obj = Random.Range(0, objectives.Length);
		int spawn = Random.Range(0, spawnPositions.Length);

        Destroy(localObjective);
        localObjective = Instantiate(objectives[obj], spawnPositions[spawn].position, reflectObjectives? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity);
        BrokenTruck bt = localObjective.GetComponent<BrokenTruck>();
        if (bt != null)
        {
            bt.isOnEnemySide = this.reflectObjectives;
        }
        
	}
}
