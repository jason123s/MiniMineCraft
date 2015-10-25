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

    class Dust : Microsoft.Xna.Framework.Game
    {
        private enum Normal
        {
            NORMAL,
            WEAPON
        }

        private struct StructDust
        {
            private Enum _DustEnum;
            
            public Enum DustEnum
            {
                get { return _DustEnum; }
                set { _DustEnum = value; }
            }
            private Texture2D _dustTexture;

            public Texture2D DustTexture
            {
              get { return _dustTexture; }
              set { _dustTexture = value; }
            }

            private Rectangle _dustHolder;
            public Rectangle DustHolder
            {
                get { return _dustHolder; }
                set { _dustHolder = value; }
            }

            public void InitDust(Texture2D dustTexture, Rectangle dustRectangle, Enum myEnum)
            {
                this._dustTexture = dustTexture;
                this._dustHolder = dustRectangle;
                this._DustEnum = myEnum;
            }
        }

        StructDust[] dustList;

        public Dust(){}

        public void setSize(int size)
        {
            dustList = new StructDust[size];
        }
        public void InitDustStruct(int i, Texture2D dustTexture, Rectangle dustHolder)
        {
             dustList[i].DustTexture = dustTexture;
             dustList[i].DustHolder = dustHolder;
             dustList[i].DustEnum = Normal.NORMAL;
        }

        public Texture2D getDustTexture(int position)
        {
            return dustList[position].DustTexture;
        }

        public Rectangle getDustHolder(int position)
        {
            return dustList[position].DustHolder;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 81; i++)
            {
                spriteBatch.Draw(getDustTexture(i), getDustHolder(i), Color.White);
            }
        }


    }
}
