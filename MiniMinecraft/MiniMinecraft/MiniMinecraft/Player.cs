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
        bool alreadyJumped;

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

        public Player() { alreadyJumped = false; }

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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerGetTexture(), playerGetRectangle(), Color.White);
        }

        public virtual void PlayerJump()
        {
            int velocityUp = -9;
            int velocityDown = 3;
            alreadyJumped = true;

            this.playerHolder.Y += velocityUp;
            
                while (this.playerHolder.Y < 338)
                {
                    this.playerHolder.Y += velocityDown;
                }
        }

        public void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                MoveLeft();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                MoveRight();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if(this.playerHolder.Y == 338)
                    PlayerJump();
                alreadyJumped = false;
            }
        }

    }
}
