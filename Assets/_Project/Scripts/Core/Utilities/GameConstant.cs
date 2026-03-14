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
        private const string FALL = "Player_Fall";
        private const string PASSIVE = "Player_Passive";
        private const string STAND_UP = "Player_StandUp";

        public static readonly int IDLE_HASH = Animator.StringToHash(IDLE);
        public static readonly int WALK_HASH = Animator.StringToHash(WALK);
        public static readonly int SPRINT_HASH = Animator.StringToHash(SPRINT);
        public static readonly int JUMP_HASH = Animator.StringToHash(JUMP);
        public static readonly int FALL_HASH = Animator.StringToHash(FALL);
        public static readonly int PASSIVE_HASH = Animator.StringToHash(PASSIVE);
        public static readonly int STAND_UP_HASH = Animator.StringToHash(STAND_UP);
    }
    public class AnimationSettings
    {
        public const float SNAPPY_TRANSITION = 0.05f;
        public const float QUICK_TRANSITION = 0.1f;
        public const float SMOOTH_TRANSITION = 0.25f;
        public const float HEAVT_TRANSITION = 0.4f;
    }
}
