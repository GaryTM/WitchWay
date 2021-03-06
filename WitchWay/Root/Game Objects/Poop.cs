﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitchWay
{
    class Poop : AnimatedMoveableSprite // inherits from MoveableSprite class
    {

        Vector2 m_velocity;
        private bool v;
        public Poop(bool v, List<ICollideable> collideableSprites, List<IMoveable> moveableSprites, Vector2 InitialVelocity)
        {
            m_velocity = InitialVelocity;
            this.v = v;
        }

        public override void Load(ContentManager content, Vector2 pos)
        {
            m_animation = new Animation(content.Load<Texture2D>("poopSpriteSheet"), (1 / 5f), 10, 1, 0, 9);
            base.Load(content, pos);
        }

        public override Vector2 PerformMove(GameTime gameTime)
        {
            throw new NotImplementedException();
        }


        public void MoveUp()
        {
            if (m_position.Y > Game1.screenHeight - m_animation.FrameHeight - 1)
            {
                m_velocity.Y = -Math.Abs(m_velocity.Y);
            }
        }
        public void MoveDown()
        {
            if (m_position.Y < 0 - m_animation.FrameHeight + 50)
            {
                m_velocity.Y = Math.Abs(m_velocity.Y);
            }
        }
        public void MoveLeft()
        {
            if (m_position.X > 1280 - m_animation.FrameHeight - 1)
                m_velocity.X = -Math.Abs(m_velocity.X);
        }
        public void MoveRight()
        {
            if (m_position.X <= 1)
                m_velocity.X = Math.Abs(m_velocity.X);
        }

        public override void Update(GameTime gameTime)
        {
            m_position += m_velocity * gameTime.ElapsedGameTime.Milliseconds;
            MoveUp();
            MoveDown();
            MoveLeft();
            MoveRight();
            base.Update(gameTime);
        }

    }
}

