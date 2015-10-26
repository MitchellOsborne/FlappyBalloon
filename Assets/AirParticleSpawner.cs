using UnityEngine;
using System.Collections;

public class AirParticleSpawner : spawner
{
    private const int maxParticles = 200;
    GameObject[] particleArray = new GameObject[maxParticles];
    GameObject particleContainer;

    void Start()
    {
        particleContainer = new GameObject("ParticleContainer");
        particleContainer.transform.parent = gameObject.transform;

        int starterParticle = (int)Random.Range(0, particleArray.Length);

        for (int i = 0; i < particleArray.Length; ++i)
        {
            particleArray[i] = GameObject.Instantiate(SpawnObject, Vector2.zero, Quaternion.identity) as GameObject;
            particleArray[i].transform.parent = particleContainer.transform;
            particleArray[i].gameObject.SetActive(false);
        }

        StartCoroutine(ParticleHandler());
    }

    public override void Update()
    {
        SpawnTimer += Time.deltaTime;

        if ((RandomSpawnTime && SpawnTimer > RandTimer) || SpawnTimer > CurrSpawnTime)
        {
            Rect bounds = Camera.main.GetComponent<CameraBounds>().bounds;
            Vector2 spawnPos = new Vector2(bounds.x + bounds.width + 3,
                                               Random.Range((bounds.y + bounds.height) * -1, bounds.y + bounds.height));
            int randPart = (int)Random.Range(0, particleArray.Length);

            particleArray[randPart].transform.position = spawnPos;
            particleArray[randPart].SetActive(true);

            SpawnTimer = 0;
            RandTimer = Random.Range(MinSpawnInterval, CurrSpawnTime);
        }
        CurrSpawnTime -= Time.deltaTime * SpawnTimerDecayRate;
    }

    // Handles the resetting of air particles that have left the screen
    IEnumerator ParticleHandler()
    {
        while(true)
        {
            Rect bounds = Camera.main.GetComponent<CameraBounds>().bounds;
            // TODO: May be an issue here with resseting particles before they hgit edge
            for (int i = 0; i < particleArray.Length; ++i)
            {
                if (particleArray[i].transform.position.x < bounds.xMin)
                {
                    particleArray[i].SetActive(false);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
