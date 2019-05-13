using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.GameState
{
    public class GameStateMethod : MonoBehaviour, GameStateIMethod
    {
        public List<GameState.eGameState> stateList = new List<GameState.eGameState>();

        public virtual void OnClick()
        {
        }
    }
}