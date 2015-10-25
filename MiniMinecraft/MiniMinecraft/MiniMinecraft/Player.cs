using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MiniMinecraft
{
    class Player : Microsoft.Xna.Framework.Game
    {
        Texture2D playerTexture;

        public Texture2D PlayerTexture
        {
            get { return playerTexture; }
            set { playerTexture = value; }
        }

        Rectangle playerHolder;
        public Rectangle PlayerHolder
        {
            get { return playerHolder; }
            set { playerHolder = value; }
        }
        SpriteBatch spriteBatch;

        public Player () {}

        public virtual void PlayerSetTexture(Texture2D texture) {
            this.playerTexture = texture;
        }

        public virtual Texture2D playerGetTexture()
        {
            return this.playerTexture;
        }

        public virtual void PlayerSetRectangle(Rectangle rectangle)
        {
            this.playerHolder = rectangle;
        }

        public virtual Rectangle playerGetRectangle()
        {
            return this.playerHolder;
        }

        //Move the player to the left position
        public virtual void MoveLeft()
        {
            if (this.playerHolder.X >= 0)
            {
                this.playerHolder.X -= 5;
            }
            else if(this.playerHolder.X < 0)
            {
                this.playerHolder.X = 0;
            }
        }

        //Move the player to the right position
        public virtual void MoveRight()
        {
            if ( this.playerHolder.X + 30 <= 800)
            {
                this.playerHolder.X += 5;
            } 
            else
            {
                this.playerHolder.X = (800 - 30);
            }
        }

        public virtual void PlayerJumpStraight()
        {
            Vector2 Velocity;
            Velocity.X = 5f;
            Velocity.Y = 5f;

            playerHolder.Y -= (int) Velocity.Y;
        }

    }
}
