﻿using FarseerPhysics;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dauntlet.Entities
{
    public abstract class Entity
    {
        public static Texture2D DebugCircleTexture;
        public static Texture2D Shadow;

        // ============================================

        protected AnimatedTexture2D SpriteTexture;
        protected Body CollisionBody;
        protected bool IsBobbing;

        protected float LayerDepth { get { return SimPosition.Y/100f; } }
        protected float OffGroundHeight { get; set; }
        protected Vector2 CenterOrigin(Texture2D texture) { return new Vector2(texture.Width/2f, texture.Height/2f); }
        protected Vector2 ShadowOrigin { get { return new Vector2(Shadow.Width / 2f, Shadow.Height / 2f); } }
        protected Vector2 SpriteOrigin { get { return new Vector2(SpriteTexture.Width / 2f, 3 * SpriteTexture.Height / 4f); } }

        protected Vector2 SpritePosition() { return new Vector2(DisplayPosition.X, DisplayPosition.Y - OffGroundHeight); }
        protected Vector2 SpritePosition(float bobFactor) { return new Vector2(DisplayPosition.X, DisplayPosition.Y - OffGroundHeight + bobFactor);}

        // =============================================

        public float Speed;
        public float Radius;
        public float Height;
        public float Width;

        public Vector2 SimPosition { get { return CollisionBody.Position; } }
        public Vector2 DisplayPosition { get { return ConvertUnits.ToDisplayUnits(CollisionBody.Position); } }
        public Body GetBody
        {
            get { return CollisionBody; }
            set { CollisionBody = value; }
        }

        // ==============================================

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
