using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DankyKang.Source.Game_States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DankyKang.Source.Objects {
    class AsteroidSpawner : GameObject {

        public double _spawnTimer = double.MaxValue;
        public Action<Asteroid> spawnedAsteroid;

        public override void Start() {
            _spawnTimer = GetSpawnRate();
        }

        private float GetSpawnRate() {
            switch (Globals.CURRENT_DIFFICULTY) {
                case Globals.Difficulty.Spermcell:
                return Globals.ASTEROID_BASE_SPAWN_INTERVAL * Globals.SPAWN_INTERVAL_SPERMCELL_MOD;
                break;
                case Globals.Difficulty.Baby:
                return Globals.ASTEROID_BASE_SPAWN_INTERVAL * Globals.SPAWN_INTERVAL_BABY_MOD;
                break;
                case Globals.Difficulty.Toddler:
                return Globals.ASTEROID_BASE_SPAWN_INTERVAL * Globals.SPAWN_INTERVAL_TODDLER_MOD;
                break;
                case Globals.Difficulty.Medium:
                return Globals.ASTEROID_BASE_SPAWN_INTERVAL * Globals.SPAWN_INTERVAL_MED_MOD;
                break;
                case Globals.Difficulty.Hard:
                return Globals.ASTEROID_BASE_SPAWN_INTERVAL * Globals.SPAWN_INTERVAL_HARD_MOD;
                break;
                case Globals.Difficulty.Impossible:
                return Globals.ASTEROID_BASE_SPAWN_INTERVAL * Globals.SPAWN_INTERVAL_IMPOSSIBLE_MOD;
                break;
            }

            return Globals.ASTEROID_BASE_SPAWN_INTERVAL;
        }

        public override void Update(GameTime gameTime) {

            if (_spawnTimer <= 0) {
                _spawnTimer = GetSpawnRate();
                SpawnAsteroid();
            } else {
                _spawnTimer -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        private void SpawnAsteroid() {
            Random rnd = new Random();
            int side = rnd.Next(4); // Generates a number between 0 and 3
            // Side indexes go from left side clockwise (e.g. 0 = left, 1 = top)

            Vector2 spawnPos = GetSpawnPos(side);
            double direction = GetAngle(spawnPos,
                new Vector2(Globals.RENDER_TARGET_WIDTH / 2, Globals.RENDER_TARGET_HEIGHT / 2));

            direction += (float)(Math.PI * rnd.Next(-Globals.ASTEROID_MAX_ANGLE_SWAY, Globals.ASTEROID_MAX_ANGLE_SWAY) / 180.0);

            Asteroid newAsteroid = new Asteroid(spawnPos, direction);
            spawnedAsteroid?.Invoke(newAsteroid);
        }

        private double GetAngle(Vector2 a, Vector2 b) {
            return Math.Atan2(b.Y - a.Y, b.X - a.X);
        }

        private Vector2 GetSpawnPos(int side) {
            Random rnd = new Random();
            Vector2 spawnPos = Vector2.Zero;

            switch (side) {
                case 0: // Left side
                spawnPos.X = -100;
                spawnPos.Y = rnd.Next(Globals.RENDER_TARGET_HEIGHT);
                break;
                case 1: // Top Side
                spawnPos.Y = -100;
                spawnPos.X = rnd.Next(Globals.RENDER_TARGET_WIDTH);
                break;
                case 2: // Right Side
                spawnPos.X = Globals.RENDER_TARGET_WIDTH + 100;
                spawnPos.Y = rnd.Next(Globals.RENDER_TARGET_HEIGHT);
                break;
                case 3: // Bottom Side
                spawnPos.Y = Globals.RENDER_TARGET_HEIGHT + 100;
                spawnPos.X = rnd.Next(Globals.RENDER_TARGET_WIDTH);
                break;
            }

            return spawnPos;
        }

        public override void Destroy() {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            throw new NotImplementedException();
        }
    }
}
