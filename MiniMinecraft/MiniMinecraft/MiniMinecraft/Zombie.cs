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
    class Zombie
    {
        int _playerPostion;
        public Texture2D _zombieTexture;
        
        private enum ZombieMind
        {
            CRAZY = 0,
            SMART = 1
        }

        public struct ZombieX
        {
            public Texture2D _zombieTexture;

            public Texture2D ZombieTexture
            {
                get { return _zombieTexture; }
                set { _zombieTexture = value; }
            }

            private Rectangle _zombieHolder;

            public Rectangle ZombieHolder
            {
                get { return _zombieHolder; }
                set { _zombieHolder = value; }
            }

            public void UpdateZombiePosition(int num)
            {
                this._zombieHolder.X += num;
            }

            private Enum _ZMind;

            public Enum ZMind
            {
                get { return _ZMind; }
                set { _ZMind = value; }
            }
        }

        ZombieX[] crew = new ZombieX[10];

        public Zombie(Texture2D zombieTexture)
        {
            this._zombieTexture = zombieTexture;
        }

        public virtual void makeZombieCrew()
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                crew[i]._zombieTexture = this._zombieTexture;
                crew[i].ZombieHolder = new Rectangle((int)random.Next(0, 800), 338, 50, 50);
                if (random.Next(0, 2) == 1)
                {
                    crew[i].ZMind = ZombieMind.SMART;
                }
                else
                {
                    crew[i].ZMind = ZombieMind.CRAZY;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i< 10; i++){
                spriteBatch.Draw(this._zombieTexture, crew[i].ZombieHolder, Color.White);
            }
        }

        public virtual void GetPlayerPosition(int Xposition)
        {
            //update position for the zombie to come
            this._playerPostion = Xposition; 
        }

        public virtual void Update(GameTime gameTime)
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                if (crew[i].ZombieHolder.X < _playerPostion && crew[i].ZMind.Equals(ZombieMind.SMART))
                {
                    crew[i].UpdateZombiePosition(rand.Next(1,4));
                }
                else if (crew[i].ZombieHolder.X > _playerPostion && crew[i].ZMind.Equals(ZombieMind.SMART))
                {
                    crew[i].UpdateZombiePosition(rand.Next(-4, -1));
                }
                else if (crew[i].ZombieHolder.X == 0 || crew[i].ZombieHolder.X == 800 || crew[i].ZombieHolder.X == _playerPostion && crew[i].ZMind.Equals(ZombieMind.CRAZY))
                {
                    crew[i].UpdateZombiePosition((int)rand.Next(0,5));
                }
                else if (crew[i].ZMind.Equals(ZombieMind.CRAZY))
                {
                    int velocity = rand.Next(-4, 4);
                    if (crew[i].ZombieHolder.X > 0 && crew[i].ZombieHolder.X < 800)
                    {
                        crew[i].UpdateZombiePosition(velocity);
                    }
                    else if (crew[i].ZombieHolder.X < 0)
                    {
                        crew[i].UpdateZombiePosition((int)rand.Next(0, 5));
                    } 
                }
                else 
                {
                    crew[i].UpdateZombiePosition(0);
                }
            }
            
        }
    }
}
