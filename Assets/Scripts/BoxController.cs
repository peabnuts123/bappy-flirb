using TMPro;
using UnityEngine;
using Zenject;

public class BoxController : MonoBehaviour
{
    // Public references
    [NotNull]
    [SerializeField]
    private new Collider2D collider;
    [NotNull]
    [SerializeField]
    private TMP_Text scoreText;

    // Public config
    public bool cheatMode = false;


    // Private config
    private float gravity = 0.01F;
    private float movementSpeed = 0.05F;
    private float impulse = 0.015F;

    // Private references
    [Inject]
    private GameStateManager gameStateManager;

    // Private state
    private Vector2 speed = Vector2.zero;
    private int _score = 0;

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
                    OnLose();
                }
                break;
        }
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

                if (!this.cheatMode)
                {
                    this.speed.y -= this.gravity;
                }
                else
                {
                    this.speed.y -= this.gravity * Mathf.Sign(this.transform.position.y);
                }

                this.collider.transform.position += (Vector3)this.speed;
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == WorldObstacle.ObstacleTag && !this.cheatMode)
        {
            OnLose();
        }
        else if (other.tag == WorldObstacle.ObstacleTriggerTag)
        {
            ScorePoint();
        }
    }

    private void OnLose()
    {
        ResetState();
    }

    private void ScorePoint()
    {
        this.Score++;
    }

    private void ResetState()
    {
        this.collider.transform.position = Vector3.zero;
        this.speed = Vector2.zero.WithX(this.movementSpeed);
        this.gameStateManager.ResetState();
        this.Score = 0;
    }

    // Properties
    public GameState currentGameState
    {
        get { return this.gameStateManager.CurrentState; }
        set { this.gameStateManager.CurrentState = value; }
    }
    public int Score
    {
        get { return this._score; }
        private set
        {
            this._score = value;
            this.scoreText.text = $"{value}";
        }
    }
}
