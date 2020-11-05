using UnityEngine;
using Zenject;

public class TextManager : MonoBehaviour
{
    // Public references
    [NotNull]
    [SerializeField]
    private GameObject TapToBeginText;
    [NotNull]
    [SerializeField]
    private GameObject PlayingGameText;
    [NotNull]
    [SerializeField]
    private GameObject ScoreText;

    // Private references
    [Inject]
    private GameStateManager gameStateManager;

    public void Start()
    {
        // Subscribe to OnStateChange
        this.gameStateManager.OnStateChange += OnGameStateChange;

        // React to initial setup
        UpdateTextVisibility(this.gameStateManager.CurrentState);
    }

    public void OnGameStateChange(GameState newState, GameState oldState)
    {
        UpdateTextVisibility(newState);
    }

    private void UpdateTextVisibility(GameState newState)
    {
        switch (newState)
        {
            case GameState.Init:
                this.TapToBeginText.SetActive(true);
                this.PlayingGameText.SetActive(false);
                this.ScoreText.SetActive(false);
                break;
            case GameState.Playing:
                this.TapToBeginText.SetActive(false);
                this.PlayingGameText.SetActive(true);
                this.ScoreText.SetActive(true);
                break;
        }
    }
}
