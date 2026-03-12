using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant
{
    public class PlayerAnimation
    {
        private const string IDLE = "Player_Idle";
        private const string WALK = "Player_Walk";
        private const string RUN = "Player_Run";

        public static readonly int IDLE_HASH = Animator.StringToHash(IDLE);
        public static readonly int WALK_HASH = Animator.StringToHash(WALK);
        public static readonly int RUN_HASH = Animator.StringToHash(RUN);
    }
    public class AnimationSettings
    {
        public const float QUICK_TRANSITION = 0.1f;
        public const float SMOOTH_TRANSITION = 0.3f;
    }
}
