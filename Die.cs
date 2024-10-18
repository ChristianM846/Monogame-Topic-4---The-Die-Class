using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Topic_4___The_Die_Class
{
    public class Die
    {
        private int _roll;
        private Random _generator;
        private List<Texture2D> _faces;
        private Rectangle _location;


        public Die(List<Texture2D> faces, Rectangle location)
        {
            _generator = new Random();
            _roll = _generator.Next(1, 7);
            _faces = faces;
            _location = location;
        }

        public int Roll
        {
            get { return _roll; }
            //set 
            //{ 
            //    _roll = value; 
            //}
        }

        public Rectangle Location
        {
            get { return _location; }
        }

        public int RollDie()
        {
            _roll = _generator.Next(1, 7);
            return _roll;
        }

        public void DrawRoll(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_faces[_roll - 1], _location, Color.White);
        }

        public override string ToString()
        {
            return _roll.ToString();
        }

    }
}
