using UnityEngine;
using Zenject;

public class BoxController : MonoBehaviour
{
    // Public references
    [NotNull]
    public SpriteRenderer sprite;

    // Public config
    private float gravity = 0.01F;
    private float impulse = 0.13F;

    // Private references
    [Inject]
    private GameStateManager gameStateManager;

    // Private state
    private Vector2 speed = Vector2.zero;

    void Start()
    {
        Input.simulateMouseWithTouches = true;
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
                if (Input.GetMouseButtonDown(0))
                {
                    this.speed.y = Mathf.Max(0, this.speed.y) + this.impulse;
                }

                var something = (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height))
                    - this.sprite.bounds.extents);

                if (Mathf.Abs(this.sprite.transform.position.y) > something.y + 0.4F)
                {
                    this.ResetState();
                }

                break;
        }
    }

    private void ResetState()
    {
        this.sprite.transform.position = Vector3.zero;
        this.speed = Vector2.zero;
        this.gameStateManager.ResetState();
    }

    void FixedUpdate()
    {
        switch (this.currentGameState)
        {
            case GameState.Init:
                break;
            case GameState.Playing:
                this.speed.y -= this.gravity;
                this.sprite.transform.position = this.sprite.transform.position + (Vector3)this.speed;
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
