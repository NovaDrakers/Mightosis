using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState state;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public static event Action<GameState> OnGameStateChanged;

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch(state)
        {
            case GameState.SceneWin:
                HandleSceneWin();
                break;
            case GameState.SceneLose:
                HandleSceneLose();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleSceneWin()
    {

    }

    private void HandleSceneLose()
    {

    }


}

public enum GameState
{
    SceneWin,
    SceneLose,
    BuildTutorialStart,
    BattleTutorialStart,
    MainGameStart,

}
