using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DankyKang.Source {
    static class Globals {
        public const bool PLAYER_ACCELERATION = true; // If false, player will always travel at max speed (no acceleration)
        public const bool PLAYER_DESCELERATION = true; // If false, When player releases the forward button the ship will instantly stand still
        public const float PLAYER_ACC_AMOUNT = 0.5f;
        public const float PLAYER_DESC_AMOUNT = 1f;
        public const float PLAYER_MAX_SPEED = 10f;
        public const float ASTEROID_SPEED = 7f;
        public const float ASTEROID_BASE_SPAWN_INTERVAL = 2000f; // Miliseconds
        public const int ASTEROID_MAX_ANGLE_SWAY = 10;
        public const float PLAYER_HIT_COOLDOWN = 2000f; // Miliseconds

        public const float ASTEROID_LIFE_TIME = 10f; // Life time in seconds

        public const int RENDER_TARGET_HEIGHT = 1080;
        public const int RENDER_TARGET_WIDTH = 1920;

        // Modifiers are ASTEROID_BASE_SPAWN_INTERVAL * Modifier
        public const float SPAWN_INTERVAL_HARD_MOD = 0.2f;
        public const float SPAWN_INTERVAL_BABY_MOD = 1f;
        public const float SPAWN_INTERVAL_MED_MOD = 0.5f;
        public const float SPAWN_INTERVAL_TODDLER_MOD = 0.75f;
        public const float SPAWN_INTERVAL_IMPOSSIBLE_MOD = 0f;
        public const float SPAWN_INTERVAL_SPERMCELL_MOD = 2f;

        public enum Difficulty {
            Spermcell,
            Baby,
            Toddler,
            Medium,
            Hard,
            Impossible
        }

        public static Difficulty CURRENT_DIFFICULTY = Difficulty.Medium;

    }
}
