using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WorldManager : MonoBehaviour
{
    // Public references
    [NotNull]
    [SerializeField]
    private WorldObstacle obstaclePrefab;
    [NotNull]
    [SerializeField]
    private Camera gameCamera;

    // Private references
    [Inject]
    private GameStateManager gameStateManager;

    // Private state
    private List<WorldObstacle> obstacles;
    private float lastObstacleX;

    public void Start()
    {
        this.obstacles = new List<WorldObstacle>();
        ResetState();

        this.gameStateManager.OnStateChange += this.OnGameStateChange;
    }

    public void FixedUpdate()
    {
        UpdateObstacles();
    }

    private void ResetState()
    {
        this.lastObstacleX = 0;
        foreach (WorldObstacle obstacle in this.obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        this.obstacles.Clear();
        UpdateObstacles();
    }

    private void UpdateObstacles()
    {
        Vector2 cameraBoundsBottomLeft = this.gameCamera.ViewportToWorldPoint(Vector3.zero);
        Vector2 cameraBoundsTopRight = this.gameCamera.ViewportToWorldPoint(Vector3.one);

        float cameraLeft = cameraBoundsBottomLeft.x;
        float cameraRight = cameraBoundsTopRight.x;
        float cameraWidth = cameraRight - cameraLeft;

        // Check existing obstacles, whether they should be destroyed
        for (int i = this.obstacles.Count - 1; i >= 0; i--)
        // foreach (WorldObstacle obstacle in this.obstacles)
        {
            WorldObstacle obstacle = this.obstacles[i];
            if (ShouldDeleteObstacle(obstacle, cameraLeft, cameraRight, cameraWidth))
            {
                Destroy(obstacle.gameObject);
                this.obstacles.RemoveAt(i);
            }
        }

        // Create any new obstacles
        float nextObstacleX = lastObstacleX + Random.Range(4F, 6F);
        while (ShouldCreateObstacle(nextObstacleX, cameraLeft, cameraRight, cameraWidth))
        {
            WorldObstacle newObstacle = Instantiate<WorldObstacle>(this.obstaclePrefab, Vector3.zero.WithX(nextObstacleX), Quaternion.identity, this.transform);
            // Some manual injection
            newObstacle.gameCamera = this.gameCamera;
            // Configure height/size of obstacle
            newObstacle.ConfigureRandom(Random.Range(2F, 4.5F));

            this.obstacles.Add(newObstacle);

            this.lastObstacleX = nextObstacleX;
            nextObstacleX = lastObstacleX + Random.Range(4F, 6F);
        }
    }

    private bool ShouldDeleteObstacle(WorldObstacle obstacle, float cameraLeft, float cameraRight, float cameraWidth)
    {
        // True if obstacle is more than 1 camera width off the left of the camera
        return obstacle.transform.position.x < cameraLeft - cameraWidth;
    }

    private bool ShouldCreateObstacle(float proposedX, float cameraLeft, float cameraRight, float cameraWidth)
    {
        // True if proposed spawn location is less then 1 screen right of the camera
        return proposedX < cameraRight + cameraWidth;
    }

    private void OnGameStateChange(GameState newState, GameState oldState)
    {
        switch (newState)
        {
            case GameState.Init:
                ResetState();
                break;
        }
    }
}