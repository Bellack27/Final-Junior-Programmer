using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnDistance = 20f;

    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < spawnInterval) return;
        timer = 0f;

        Vector2 dir = Random.insideUnitCircle.normalized;
        Vector3 pos = player.position + new Vector3(dir.x, 0f, dir.y) * spawnDistance;
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
   

   
}
