using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant
{
    public class PlayerAnimation
    {
        private const string IDLE = "Player_Idle";
        private const string WALK = "Player_Walk";
        private const string SPRINT = "Player_Sprint";
        private const string JUMP = "Player_Jump";

        public static readonly int IDLE_HASH = Animator.StringToHash(IDLE);
        public static readonly int WALK_HASH = Animator.StringToHash(WALK);
        public static readonly int SPRINT_HASH = Animator.StringToHash(SPRINT);
        public static readonly int JUMP_HASH = Animator.StringToHash(JUMP);
    }
    public class AnimationSettings
    {
        public const float QUICK_TRANSITION = 0.05f;
        public const float SMOOTH_TRANSITION = 0.2f;
    }
}
