using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.GameState
{
    public class GameStateRemove : GameStateMethod
    {
        [ContextMenu("OnClick")]
        public override void OnClick()
        {
            GameState.Instance.Remove(this.stateList);
        }
    }
}