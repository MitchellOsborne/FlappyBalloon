using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	public GameObject EnemyPrefab;
	public GameObject DebreePrefab;

	public GameObject GameCamera;
	
	public float EnemySpawnRate = 0;
	public float DebreeSpawnRate = 0;
	private float EnemySpawnCounter = 0;
	private float DebreeSpawnCounter = 0;
	// Use this for initialization
	void Start () {
		Random.seed = (int)System.DateTime.Today.Ticks;
	}
	
	// Update is called once per frame
	void Update () {
		DebreeSpawnCounter += Time.deltaTime;
		EnemySpawnCounter += Time.deltaTime;


		if (DebreeSpawnCounter > DebreeSpawnRate) {
			GameObject tempObj = (GameObject)GameObject.Instantiate(DebreePrefab, new Vector2(GameCamera.transform.position.x + 12, GameCamera.transform.position.y + Random.Range (-3, 6)),Quaternion.identity);
			tempObj.transform.parent = gameObject.transform;
			DebreeSpawnCounter = 0;
		}

		if (EnemySpawnCounter > EnemySpawnRate) {
			GameObject tempObj = (GameObject)GameObject.Instantiate(EnemyPrefab, new Vector2(GameCamera.transform.position.x + 12, GameCamera.transform.position.y + Random.Range (-3, 6)),Quaternion.identity);
			tempObj.transform.parent = gameObject.transform;
			EnemySpawnCounter = 0;
		}
	}
}
