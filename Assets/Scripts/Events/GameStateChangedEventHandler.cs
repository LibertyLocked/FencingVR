using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public delegate void GameStateChangedEventHandler(object sender, EventArgs e);

public class GameStateChangedEventArgs : EventArgs
{
    public GameState GameState
    {
        get;
        private set;
    }

    public GameStateChangedEventArgs(GameState state)
    {
        this.GameState = state;
    }
}
