using System;
using UnityEngine;

public class WorldObstacle : MonoBehaviour
{
    // Public static config
    public static readonly string TAG = "Obstacle";

    // Public references
    [NotNull]
    [SerializeField]
    private GameObject topObstacle;
    [NotNull]
    [SerializeField]
    private GameObject bottomObstacle;
    public Camera gameCamera;

    // Private state
    private float viewportY = 0.5F;
    private float size = 2F;

    public void SetPosition(float positionX)
    {
        this.topObstacle.transform.position = this.topObstacle.transform.position.WithX(positionX);
        this.bottomObstacle.transform.position = this.bottomObstacle.transform.position.WithX(positionX);
    }

    /// <summary>
    /// @TODO
    /// </summary>
    /// <param name="viewportY">A number between 0 and 1</param>
    /// <param name="worldSize">Gap size in world units</param>
    public void Configure(float viewportY, float worldSize)
    {
        float viewportSize = worldSize / (this.gameCamera.orthographicSize * 2);

        // Ensure position/size will not cause an overflow
        if (Mathf.Approximately(viewportY, 1 - (viewportSize / 2F)) || viewportY >= 1 - (viewportSize / 2F))
        {
            throw new ArgumentException($"Cannot set position: '{viewportY}' with size '{size}' (viewPort size: {viewportSize}). It is off the top of the screen");
        }
        else if (Mathf.Approximately(viewportY, viewportSize / 2F) || viewportY <= (viewportSize / 2F))
        {
            throw new ArgumentException($"Cannot set position: '{viewportY}' with size '{size}' (viewPort size: {viewportSize}). It is off the bottom of the screen");
        }

        this.viewportY = viewportY;
        this.size = worldSize;
        UpdateShapes();
    }

    public void ConfigureRandom(float worldSize)
    {
        float bufferViewportSize = 0.05F;
        float viewportSize = worldSize / (this.gameCamera.orthographicSize * 2);

        if (Mathf.Approximately(viewportSize, 1 - bufferViewportSize) || viewportSize >= 1 - bufferViewportSize)
        {
            throw new ArgumentException($"Can't configure obstacle size to '{worldSize}' - it is greater than the size of the screen");
        }

        float positionMin = bufferViewportSize + (viewportSize / 2F);
        float positionMax = 1 - bufferViewportSize - (viewportSize / 2F);

        Configure(UnityEngine.Random.Range(positionMin, positionMax), worldSize);
    }

    public void FixedUpdate()
    {
        UpdateShapes();
    }

    private void UpdateShapes()
    {
        // World-space positions of:
        //  Top of camera viewport
        Vector2 coordinateCameraTop = this.gameCamera.ViewportToWorldPoint(new Vector2(0, 1));
        //  Bottom of camera viewport
        Vector2 coordinateCameraBottom = this.gameCamera.ViewportToWorldPoint(new Vector2(0, 0));
        //  `positionY` value
        Vector2 coordinatePosition = this.gameCamera.ViewportToWorldPoint(new Vector2(0, this.viewportY));

        // Calculate gap extents
        float topShapeBottom = coordinatePosition.y + (this.size / 2F);
        float bottomShapeTop = coordinatePosition.y - (this.size / 2F);

        // Dimensions of top/bottom shapes
        float topShapeHeight = coordinateCameraTop.y - topShapeBottom;
        float bottomShapeHeight = bottomShapeTop - coordinateCameraBottom.y;

        // transform positions of top/bottom shapes
        float topShapePosition = coordinateCameraTop.y - (topShapeHeight / 2F);
        float bottomShapePosition = coordinateCameraBottom.y + (bottomShapeHeight / 2F);

        // Set top/bottom obstacle gameobject definitions
        this.topObstacle.transform.position = this.topObstacle.transform.position.WithY(topShapePosition);
        this.topObstacle.transform.localScale = this.topObstacle.transform.localScale.WithY(topShapeHeight);
        this.bottomObstacle.transform.position = this.bottomObstacle.transform.position.WithY(bottomShapePosition);
        this.bottomObstacle.transform.localScale = this.bottomObstacle.transform.localScale.WithY(bottomShapeHeight);
    }
}