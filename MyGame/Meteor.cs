using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class Meteor : GameObject
    {
        private const float Speed = 0.25f;

        private readonly Sprite _sprite = new Sprite();

        public Meteor(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/meteor.png");
            _sprite.Position = pos;
            AssignTag("meteor");
            SetCollisionCheckEnabled(true);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.X < _sprite.GetGlobalBounds().Width * -1)
            {
                GameScene scene = (GameScene)Game.CurrentScene;
                scene.DecreaseLives();
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("laser")) otherGameObject.MakeDead();

            MakeDead();

            // This part is also missing: described, but not shown.
            GameScene scene = (GameScene)Game.CurrentScene;
            scene.IncreaseScore();

            // This is the part that is left out of the tutorial. It's similar to creating a laser in Ship.cpp
            Vector2f pos = _sprite.Position;
            FloatRect bounds = _sprite.GetGlobalBounds();
            float laserX = pos.X + bounds.Width / 2.0f;
            float laserY = pos.Y + bounds.Height / 2.0f;
            Explosion ex = new Explosion(new Vector2f(laserX, laserY));
            Game.CurrentScene.AddGameObject(ex);
        }
    }
}