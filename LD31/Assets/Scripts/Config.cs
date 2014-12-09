using System.Collections;

using UnityEngine;
using UnityEngine.UI;

namespace LD31 {
    public class Config {
        public const bool DEBUG_MODE = false;

        /* Player Movement */
        public readonly static float THRUST_SPEED = 10f;
        public readonly static float MOVE_FORWARD_SPEED = 50f;
        public readonly static float ROTATION_SPEED = 150f;
        public readonly static float CORRECTION_SPEED = 5f;
        public readonly static float CORRECTION_PENALTY_FORCE = -2f;
        public readonly static float COLLISION_PENALTY_FORCE = -20f;
        public readonly static float COLLISION_SHAKE_CAMERA_AMOUNT = 1.5f;
        public readonly static float BASE_FALL_SHAKE_AMOUNT = 0.03f;

        public readonly static float MAX_FORWARD_SPEED = 20f;
        public readonly static float MAX_ROTATION_SPEED = 2f;

        public readonly static float TO_TV_Z_THRESHOLD = 30f;
        public readonly static float TWEEN_TO_TV_PERIOD = 1f;

        public readonly static Vector3 TV_LOCK_POSITION = new Vector3(0f, 0.9f, -2.31f);

        public readonly static float WORD_INTERVAL = 0.4f;
        public readonly static float MAX_WORD_LIFESPAN = 120f;

        public readonly static float TV_OBSTACLE_INTVERAL = 1.0f;
        public readonly static float OBSTACLE_GENERATION_MIN_RADIUS = 5f;
        public readonly static float OBSTACLE_GENERATION_MAX_RADIUS = 10f;
        public readonly static float OBSTACLE_MIN_SPEED = 100f;
        public readonly static float OBSTACLE_MAX_SPEED = 400f;
        public readonly static float OBSTACLE_ROTATION_MIN_SPEED = 0f;
        public readonly static float OBSTACLE_ROTATION_MAX_SPEED = 20f;

        public readonly static float MIN_THEME_VOLUME = 0.01f;

        public readonly static int LEVEL_NUMBER = 7;

        /* Events */
        public readonly static string EVENT_USER_INPUT = "EVENT_USER_INPUT";
        public readonly static string EVENT_TV_GAME_CHUCK_PLAYER = "EVENT_TV_GAME_CHUCK_PLAYER";

        /* consts */
        public enum Direction {UP=0,DOWN,LEFT,RIGHT}
        public const string UP = "UP";
        public const string DOWN = "DOWN";
        public const string LEFT = "LEFT";
        public const string RIGHT = "RIGHT";

        public const string EYES_LINE = "line";
        public const string EYES_DOTS = "dots";
        public const string EYES_SLANT = "slant";
        public const string EYES_DOWN = "down";
        public const string EYES_SUCCESS = "success";
        public const string EYES_FAIL = "fail";

        public const string MOUTH_LINE = "line";
        public const string MOUTH_LINE_UP = "line_up";
        public const string MOUTH_LINE_DOWN = "line_down";
        public const string MOUTH_D_UP = "d_up";
        public const string MOUTH_D_DOWN = "d_down";
        public const string MOUTH_SUCCESS = "success";
        public const string MOUTH_FAIL = "fail";

        /* TV timings */
        public static readonly float RESULT_REVEAL_DELAY = 1f;
        public static readonly float RESULT_RAMIFICATION_DELAY = 2f;
        public static readonly float RESET_WAIT_TIME = 3f;
    }
}

