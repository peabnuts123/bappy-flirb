using UnityEngine;

public class WorldManager : MonoBehaviour
{
    // Public references
    [NotNull]
    [SerializeField]
    private WorldObstacle obstaclePrefab;
    [NotNull]
    [SerializeField]
    private Camera gameCamera;

    // Private state
    private WorldObstacle[] obstacles;

    public void Start()
    {
        // this.obstaclePrefab.Configure(0.5F, 2);
        int numObstacles = 10;
        this.obstacles = new WorldObstacle[numObstacles];
        // Random random = new Random();


        for (int i = 0; i < numObstacles; i++)
        {
            this.obstacles[i] = Instantiate<WorldObstacle>(this.obstaclePrefab, Vector3.zero.WithX((i + 1) * 5), Quaternion.identity, this.transform);
            // Some manual injection
            this.obstacles[i].gameCamera = this.gameCamera;
            // this.obstacles[i].Configure(Random.Range(0.15F, 0.85F), Random.Range(2F, 3.5F));
            this.obstacles[i].ConfigureRandom(Random.Range(2F, 4.5F));
        }
    }
}