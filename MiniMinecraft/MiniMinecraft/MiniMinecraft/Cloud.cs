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
    class Cloud
    {
        Texture2D _cloudTexture;

        private struct CloudX
        {
            Texture2D cloudTexture;

            public Texture2D CloudTexture
            {
                get { return cloudTexture; }
                set { cloudTexture = value; }
            }

            Rectangle cloudHolder;

            public Rectangle CloudHolder
            {
                get { return cloudHolder; }
                set { cloudHolder = value; }
            }
        }

        CloudX[] clouds;

        public Cloud(Texture2D cloudTexture)
        {
            this._cloudTexture = cloudTexture;
        }

        public virtual void setCloudPosition()
        {
            clouds = new CloudX[3];
            for (int i = 0; i < 3; i++)
            {
                clouds[i].CloudTexture = this._cloudTexture;
                if (i == 0)
                {
                    clouds[i].CloudHolder = new Rectangle(200, 35, 100, 100);
                }
                else if (i == 1)
                {
                    clouds[i].CloudHolder = new Rectangle(635, 135, 100, 100);
                }
                else
                {
                    clouds[i].CloudHolder = new Rectangle(300, 75, 100, 100);
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 3; i++)
            {
                spriteBatch.Draw(clouds[i].CloudTexture, clouds[i].CloudHolder, Color.White);
            }
        }
    }
}
