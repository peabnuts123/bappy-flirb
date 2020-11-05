using UnityEngine;
using Zenject;

public class BoxController : MonoBehaviour
{
    // Public references
    [NotNull]
    public new Collider2D collider;

    // Public config
    private float gravity = 0.01F;
    private float movementSpeed = 0.05F;
    private float impulse = 0.015F;

    // Private references
    [Inject]
    private GameStateManager gameStateManager;

    // Private state
    private Vector2 speed = Vector2.zero;

    void Start()
    {
        Input.simulateMouseWithTouches = true;
        ResetState();
    }

    void Update()
    {
        switch (this.currentGameState)
        {
            case GameState.Init:
                if (Input.GetMouseButtonDown(0))
                {
                    this.currentGameState = GameState.Playing;
                }
                break;
            case GameState.Playing:
                Vector2 screenWorldSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

                // Test if player is colliding the the edge of the screen
                if (Mathf.Abs(this.collider.transform.position.y) + this.collider.bounds.extents.y > screenWorldSize.y)
                {
                    this.ResetState();
                }

                break;
        }
    }

    private void ResetState()
    {
        this.collider.transform.position = Vector3.zero;
        this.speed = Vector2.zero.WithX(this.movementSpeed);
        this.gameStateManager.ResetState();
    }

    void FixedUpdate()
    {
        switch (this.currentGameState)
        {
            case GameState.Init:
                break;
            case GameState.Playing:
                if (Input.GetMouseButton(0))
                {
                    this.speed.y = Mathf.Max(this.impulse * 5, this.speed.y) + this.impulse;
                }

                this.speed.y -= this.gravity;
                this.collider.transform.position += (Vector3)this.speed;
                break;
        }
    }

    // Properties
    public GameState currentGameState
    {
        get { return this.gameStateManager.CurrentState; }
        set { this.gameStateManager.CurrentState = value; }
    }
}
