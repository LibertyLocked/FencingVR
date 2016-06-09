using UnityEngine;
using System;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject opponentPrefab;
    public event GameStateChangedEventHandler GameStateChanged;

    GameState gameState;

    public GameState GameState
    {
        get { return gameState; }
        private set
        {
            gameState = value;
            if (GameStateChanged != null)
            {
                GameStateChanged(this, new GameStateChangedEventArgs(value));
            }
        }
    }

    public int NumWins
    {
        get;
        private set;
    }

    public int NumLoses
    {
        get;
        private set;
    }
       
    void Start()
    {
        GameState = GameState.Playing;
    }

    void Update()
    {

    }

    void ClearScene()
    {
        GameObject[] opponents = GameObject.FindGameObjectsWithTag("Opponent");
        foreach (var op in opponents)
        {
            Destroy(op);
        }
        GameState = GameState.PushStart;
    }

    public void Play()
    {
        if (GameState == GameState.PushStart)
        {
            Instantiate(opponentPrefab);
            GameState = GameState.Playing;
        }
    }

    public void Win()
    {
        if (GameState == GameState.Playing)
        {
            Invoke("ClearScene", 5f);
            NumWins++;
            GameState = GameState.Won;
        }
    }

    public void Lose()
    {
        if (GameState == GameState.Playing)
        {
            Invoke("ClearScene", 5f);
            NumLoses++;
            GameState = GameState.Lost;
        }
    }
}

public enum GameState
{
    PushStart,
    Playing,
    Won,
    Lost,
}