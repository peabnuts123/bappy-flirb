using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public delegate void StateChangeHandler(GameState newState, GameState oldState);
    public event StateChangeHandler OnStateChange;

    // Private state
    private GameState _currentState;

    public GameStateManager()
    {
        this.CurrentState = GameState.Init;
    }

    public void ResetState()
    {
        this.CurrentState = GameState.Init;
    }

    public GameState CurrentState
    {
        get { return this._currentState; }
        set
        {
            GameState oldState = this._currentState;
            GameState newState = value;
            this._currentState = value;

            this.OnStateChange?.Invoke(newState, oldState);
        }
    }
}