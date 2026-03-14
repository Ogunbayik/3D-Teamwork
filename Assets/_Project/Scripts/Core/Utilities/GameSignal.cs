using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class GameSignal
{
    public class OnPlayerSwapSignal
    {
        public PlayerIdentity NewPlayerIdentity;
        public OnPlayerSwapSignal(PlayerIdentity newPlayerIdentity) => NewPlayerIdentity = newPlayerIdentity;
    }
}
