using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public Sprite[] balloonSprites;

    private float spawnDuration = 30f;
    private int totalBalloons = 20;
    private float spawnInterval;
    private int spawnedCount = 0;

    void Start()
    {
        spawnInterval = spawnDuration / totalBalloons;
        InvokeRepeating(nameof(SpawnBalloon), 1f, spawnInterval);
    }

    void SpawnBalloon()
    {
        if (spawnedCount >= totalBalloons)
        {
            CancelInvoke(nameof(SpawnBalloon));
            return;
        }

        Vector3 spawnPos = new Vector3(Random.Range(-2.5f, 2.5f), -5f, 0);
        GameObject balloonGO = Instantiate(balloonPrefab, spawnPos, Quaternion.identity);

        int index = Random.Range(0, balloonSprites.Length);
        Sprite sprite = balloonSprites[index];

        balloonGO.GetComponent<Balloon>().SetData(sprite, index);

        spawnedCount++;
    }
}
