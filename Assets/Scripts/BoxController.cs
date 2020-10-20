using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Init,
    Playing,
}

public class BoxController : MonoBehaviour
{
    // Public references
    public SpriteRenderer sprite;

    // Public config
    private float gravity = 0.01F;
    private float impulse = 0.13F;

    // Private state
    private GameState state = GameState.Init;
    private Vector2 speed = Vector2.zero;

    void Start()
    {
        Debug.Log("Project running");
        Input.simulateMouseWithTouches = true;
    }

    void Update()
    {
        switch (this.state)
        {
            case GameState.Init:
                if (Input.GetMouseButtonDown(0))
                {
                    this.state = GameState.Playing;
                }
                break;
            case GameState.Playing:
                if (Input.GetMouseButtonDown(0))
                {
                    this.speed.y = Mathf.Max(0, this.speed.y) + this.impulse;
                }

                var something = (Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height))
                    - this.sprite.bounds.extents);

                // Debug.Log($"Something: {something}");
                // Debug.Log($"sprite: {this.sprite.transform.position}");
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
        this.state = GameState.Init;
    }

    void FixedUpdate()
    {
        switch (this.state)
        {
            case GameState.Init:
                break;
            case GameState.Playing:
                this.speed.y -= this.gravity;
                this.sprite.transform.position = this.sprite.transform.position + (Vector3)this.speed;
                break;
        }
    }
}
