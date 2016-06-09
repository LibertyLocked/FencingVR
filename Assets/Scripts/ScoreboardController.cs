using UnityEngine;
using System;
using System.Collections;

public class ScoreboardController : MonoBehaviour
{
    TextMesh textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        GameController gameCtrl = GameObject.Find("Game Controller").GetComponent<GameController>();
        if (gameCtrl != null) gameCtrl.GameStateChanged += 
                (sender, e) => UpdateText(gameCtrl.NumWins, gameCtrl.NumLoses, gameCtrl.GameState);
    }

    void Update()
    {
        
    }

    public void UpdateText(int wins, int loses, GameState state)
    {
        textMesh.text = "Wins " + wins + "\nLoses " + loses +
            "\n" + state.ToString();
    }
}
