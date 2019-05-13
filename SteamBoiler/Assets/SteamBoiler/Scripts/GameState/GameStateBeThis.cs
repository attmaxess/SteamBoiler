using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteamBoiler.tPart.GameState
{
    public class GameStateBeThis : GameStateMethod
    {
        [ContextMenu("OnClick")]
        public override void OnClick()
        {
            GameState.Instance.BeThis(this.stateList);
        }
    }
}