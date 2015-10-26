using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{
	public GameObject SpawnObject;
	public float MaxSpawnInterval = 1;		//Maximum/Initial Spawn Time
	public float MinSpawnInterval = 0.1f;	//Minimum/Shortest Spawn Time
	public float CurrSpawnTime = 1;			//Current Spawn Time
	public float SpawnTimerDecayRate = 1;	//Rate at which Current Spawn Time shortens (* 1/second)
	public bool RandomSpawnTime = false;    //Whether the Spawn time is randomly chosen between Max and Min
    protected float SpawnTimer = 0;
	protected float RandTimer = 0;
	// Use this for initialization
	void Start ()
	{
		Random.seed = (int)System.DateTime.Today.Ticks;
		CurrSpawnTime = MaxSpawnInterval;
		if (RandomSpawnTime)
			RandTimer = Random.Range (MinSpawnInterval, MaxSpawnInterval);
	}
	
	// Update is called once per frame
	public virtual void Update () 
	{
		SpawnTimer += Time.deltaTime;

		if ((RandomSpawnTime && SpawnTimer > RandTimer) || SpawnTimer >  CurrSpawnTime) {
			Rect bounds = Camera.main.GetComponent<CameraBounds> ().bounds;
			Vector2 spawnPos = new Vector2 (bounds.x + bounds.width + 3,
				                               Random.Range ((bounds.y + bounds.height) * -1, bounds.y + bounds.height));
			GameObject tempObj = (GameObject)GameObject.Instantiate (SpawnObject, spawnPos, Quaternion.identity);
			tempObj.transform.parent = gameObject.transform;
			SpawnTimer = 0;
			RandTimer = Random.Range (MinSpawnInterval, CurrSpawnTime);
		}
		CurrSpawnTime -= Time.deltaTime * SpawnTimerDecayRate;
	}
}
