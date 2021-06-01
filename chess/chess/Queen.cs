﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;


namespace chess
{
    public class Queen : ChessPiece
    {
        

        public Queen(string name) : base(name)
        {
            
        }

        public void CreateIBForBG(string chessPiece, Button btn)
        {
            string[] split = chessPiece.Split('0');
            string strippedChessPiece = split[0];
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"/Sprites/{strippedChessPiece}.png"));
            btn.Background = brush;
            btn.Tag = chessPiece;
        }
    }
}
