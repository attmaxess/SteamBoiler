using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.GameState
{
    public class GameStateMethod : MonoBehaviour, GameStateIMethod
    {
        public List<eGameState> stateList = new List<eGameState>();

        public virtual void OnClick()
        {
        }
    }
}