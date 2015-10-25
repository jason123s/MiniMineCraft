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
        Rectangle playerHolder;
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

        public virtual void MoveRight(int screenWidth)
        {
            if ( (this.playerHolder.X + this.playerTexture.Width) >= screenWidth /2 )
            {
                this.playerHolder.X += 5;
            } 
            else if ( (this.playerHolder.X + this.playerTexture.Width) <= screenWidth)
            {
                this.playerHolder.X = ( screenWidth /2 - this.playerTexture.Width);
            }
        }

    }
}
