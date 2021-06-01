using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace chess
{
    public class Drawing
    {
        #region drawBorder

        public static void drawBorder(Canvas draw)
        {
            //draw.Width = 640;
            //draw.Height = 640;

            #region coordinates
            #region aCoords
            int[] a1 = new int[] { 1, 560 };
            int[] a2 = new int[] { 1, 480 };
            int[] a3 = new int[] { 1, 400 };
            int[] a4 = new int[] { 1, 320 };
            int[] a5 = new int[] { 1, 240 };
            int[] a6 = new int[] { 1, 160 };
            int[] a7 = new int[] { 1, 80 };
            int[] a8 = new int[] { 1, 1 };
            #endregion

            #region bCoords
            int[] b1 = new int[] { 80, 560 };
            int[] b2 = new int[] { 80, 480 };
            int[] b3 = new int[] { 80, 400 };
            int[] b4 = new int[] { 80, 320 };
            int[] b5 = new int[] { 80, 240 };
            int[] b6 = new int[] { 80, 160 };
            int[] b7 = new int[] { 80, 80 };
            int[] b8 = new int[] { 80, 1 };
            #endregion

            #region cCoords

            int[] c1 = new int[] { 160, 560 };
            int[] c2 = new int[] { 160, 480 };
            int[] c3 = new int[] { 160, 400 };
            int[] c4 = new int[] { 160, 320 };
            int[] c5 = new int[] { 160, 240 };
            int[] c6 = new int[] { 160, 160 };
            int[] c7 = new int[] { 160, 80 };
            int[] c8 = new int[] { 160, 1 };
            #endregion

            #region dCoords

            int[] d1 = new int[] { 240, 560 };
            int[] d2 = new int[] { 240, 480 };
            int[] d3 = new int[] { 240, 400 };
            int[] d4 = new int[] { 240, 320 };
            int[] d5 = new int[] { 240, 240 };
            int[] d6 = new int[] { 240, 160 };
            int[] d7 = new int[] { 240, 80 };
            int[] d8 = new int[] { 240, 1 };
            #endregion

            #region eCoords
            int[] e1 = new int[] { 320, 560 };
            int[] e2 = new int[] { 320, 480 };
            int[] e3 = new int[] { 320, 400 };
            int[] e4 = new int[] { 320, 320 };
            int[] e5 = new int[] { 320, 240 };
            int[] e6 = new int[] { 320, 160 };
            int[] e7 = new int[] { 320, 80 };
            int[] e8 = new int[] { 320, 1 };
            #endregion

            #region fCoords
            int[] f1 = new int[] { 400, 560 };
            int[] f2 = new int[] { 400, 480 };
            int[] f3 = new int[] { 400, 400 };
            int[] f4 = new int[] { 400, 320 };
            int[] f5 = new int[] { 400, 240 };
            int[] f6 = new int[] { 400, 160 };
            int[] f7 = new int[] { 400, 80 };
            int[] f8 = new int[] { 400, 1 };
            #endregion

            #region gCoords
            int[] g1 = new int[] { 480, 560 };
            int[] g2 = new int[] { 480, 480 };
            int[] g3 = new int[] { 480, 400 };
            int[] g4 = new int[] { 480, 320 };
            int[] g5 = new int[] { 480, 240 };
            int[] g6 = new int[] { 480, 160 };
            int[] g7 = new int[] { 480, 80 };
            int[] g8 = new int[] { 480, 1 };
            #endregion

            #region hCoords
            int[] h1 = new int[] { 560, 560 };
            int[] h2 = new int[] { 560, 480 };
            int[] h3 = new int[] { 560, 400 };
            int[] h4 = new int[] { 560, 320 };
            int[] h5 = new int[] { 560, 240 };
            int[] h6 = new int[] { 560, 160 };
            int[] h7 = new int[] { 560, 80 };
            int[] h8 = new int[] { 560, 1 };
            #endregion
            #endregion

            #region drawRows
            //// row 8
            //drawWhiteBox(draw, a8);
            //drawBlackBox(draw, b8);
            //drawWhiteBox(draw, c8);
            //drawBlackBox(draw, d8);
            //drawWhiteBox(draw, e8);
            //drawBlackBox(draw, f8);
            //drawWhiteBox(draw, g8);
            //drawBlackBox(draw, h8);
            //
            //// row 7
            //drawBlackBox(draw, a7);
            //drawWhiteBox(draw, b7);
            //drawBlackBox(draw, c7);
            //drawWhiteBox(draw, d7);
            //drawBlackBox(draw, e7);
            //drawWhiteBox(draw, f7);
            //drawBlackBox(draw, g7);
            //drawWhiteBox(draw, h7);
            //
            //// row 6
            //drawWhiteBox(draw, a6);
            //drawBlackBox(draw, b6);
            //drawWhiteBox(draw, c6);
            //drawBlackBox(draw, d6);
            //drawWhiteBox(draw, e6);
            //drawBlackBox(draw, f6);
            //drawWhiteBox(draw, g6);
            //drawBlackBox(draw, h6);
            //
            //// row 5
            //drawBlackBox(draw, a5);
            //drawWhiteBox(draw, b5);
            //drawBlackBox(draw, c5);
            //drawWhiteBox(draw, d5);
            //drawBlackBox(draw, e5);
            //drawWhiteBox(draw, f5);
            //drawBlackBox(draw, g5);
            //drawWhiteBox(draw, h5);
            //
            //// row 4
            //drawWhiteBox(draw, a4);
            //drawBlackBox(draw, b4);
            //drawWhiteBox(draw, c4);
            //drawBlackBox(draw, d4);
            //drawWhiteBox(draw, e4);
            //drawBlackBox(draw, f4);
            //drawWhiteBox(draw, g4);
            //drawBlackBox(draw, h4);
            //
            //// row 3
            //drawBlackBox(draw, a3);
            //drawWhiteBox(draw, b3);
            //drawBlackBox(draw, c3);
            //drawWhiteBox(draw, d3);
            //drawBlackBox(draw, e3);
            //drawWhiteBox(draw, f3);
            //drawBlackBox(draw, g3);
            //drawWhiteBox(draw, h3);
            //
            //// row 2
            //drawWhiteBox(draw, a2);
            //drawBlackBox(draw, b2);
            //drawWhiteBox(draw, c2);
            //drawBlackBox(draw, d2);
            //drawWhiteBox(draw, e2);
            //drawBlackBox(draw, f2);
            //drawWhiteBox(draw, g2);
            //drawBlackBox(draw, h2);
            //
            //// row 1
            //drawBlackBox(draw, a1);
            //drawWhiteBox(draw, b1);
            //drawBlackBox(draw, c1);
            //drawWhiteBox(draw, d1);
            //drawBlackBox(draw, e1);
            //drawWhiteBox(draw, f1);
            //drawBlackBox(draw, g1);
            //drawWhiteBox(draw, h1);
            #endregion



        }

        //private static void drawWhiteBox(Canvas draw, int[] coord)
       //{
       //    Rectangle rectangle = new Rectangle { Width = 80, Height = 80 };
       //    rectangle.Fill = Brushes.DarkGray;
       //    rectangle.Stroke = Brushes.Black;
       //    rectangle.StrokeThickness = 1.5;
       //    draw.Children.Add(rectangle);
       //
       //    Canvas.SetLeft(rectangle, 1 * coord[0]);
       //    Canvas.SetTop(rectangle, 1 * coord[1]);
       //}

        //private static void drawBlackBox(Canvas draw, int[] coord)
        //{
        //    Rectangle rectangle = new Rectangle { Width = 80, Height = 80 };
        //    rectangle.Fill = Brushes.Gray;
        //    rectangle.Stroke = Brushes.White;
        //    rectangle.StrokeThickness = 1.5;
        //    draw.Children.Add(rectangle);
        //
        //    Canvas.SetLeft(rectangle, 1 * coord[0]);
        //    Canvas.SetTop(rectangle, 1 * coord[1]);
        //}
        #endregion




        //public static void drawPiece(Canvas draw, int[] coord, string name)
        //{
        //    
        //    draw.Width = 640;
        //    draw.Height = 640;
        //    Rectangle rectangle = new Rectangle { Width = 80, Height = 80 };
        //    var ib = CreateIBForBG(name);
        //    rectangle.Name = name;
        //    rectangle.Fill = ib;
        //    draw.Children.Add(rectangle);
        //
        //    Canvas.SetLeft(rectangle, 1 * coord[0]);
        //    Canvas.SetTop(rectangle, 1 * coord[1]);
        //}
    }
}
