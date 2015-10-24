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
    class Player : Game1
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

    }
}
