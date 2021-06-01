using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        List<Pawn> allPawns = new List<Pawn>();
        List<Queen> allQueens = new List<Queen>();
        List<King> allKings = new List<King>();
        List<Bishop> allBishops = new List<Bishop>();
        List<Rook> allRooks = new List<Rook>();
        List<Knight> allKnights = new List<Knight>();

        #region spawnFigures

        #region spawnWhiteFigures
        #region spawnWhitePawns

        Pawn whitePawn01 = new Pawn("whitePawn01");
        Pawn whitePawn02 = new Pawn("whitePawn02");
        Pawn whitePawn03 = new Pawn("whitePawn03");
        Pawn whitePawn04 = new Pawn("whitePawn04");
        Pawn whitePawn05 = new Pawn("whitePawn05");
        Pawn whitePawn06 = new Pawn("whitePawn06");
        Pawn whitePawn07 = new Pawn("whitePawn07");
        Pawn whitePawn08 = new Pawn("whitePawn08");

        #endregion

        #region spawnWhiteRooks

        Rook whiteRook01 = new Rook("whiteRook01");
        Rook whiteRook02 = new Rook("whiteRook02");

        #endregion

        #region spawnWhiteBishops

        Bishop whiteBishop01 = new Bishop("whiteBishop01");
        Bishop whiteBishop02 = new Bishop("whiteBishop02");

        #endregion

        #region spawnWhiteKnights

        Knight whiteKnight01 = new Knight("whiteKnight01");
        Knight whiteKnight02 = new Knight("whiteKnight02");


        #endregion

        #region spawnWhiteQueen

        Queen whiteQueen01 = new Queen("whiteQueen01");

        #endregion

        #region spawnWhiteKing
        King whiteKing01 = new King("whiteKing01");

        #endregion
        #endregion

        #region spawnBlackFigures

        #region spawnBlackPawns
        Pawn blackPawn01 = new Pawn("blackPawn01");
        Pawn blackPawn02 = new Pawn("blackPawn02");
        Pawn blackPawn03 = new Pawn("blackPawn03");
        Pawn blackPawn04 = new Pawn("blackPawn04");
        Pawn blackPawn05 = new Pawn("blackPawn05");
        Pawn blackPawn06 = new Pawn("blackPawn06");
        Pawn blackPawn07 = new Pawn("blackPawn07");
        Pawn blackPawn08 = new Pawn("blackPawn08");

        #endregion

        #region spawnBlackRooks

        Rook blackRook01 = new Rook("blackRook01");
        Rook blackRook02 = new Rook("blackRook02");

        #endregion

        #region spawnBlackBishops
        Bishop blackBishop01 = new Bishop("blackBishop01");
        Bishop blackBishop02 = new Bishop("blackBishop02");


        #endregion

        #region spawnBlackKnights

        Knight blackKnight01 = new Knight("blackKnight01");
        Knight blackKnight02 = new Knight("blackKnight02");

        #endregion

        #region drawBlackQueen
        Queen blackQueen01 = new Queen("blackQueen01");

        #endregion

        #region drawBlackKing
        King blackKing01 = new King("blackKing01");

        #endregion

        #endregion

        #endregion

        bool figureChosen = false;



        List<Button> chosenButton = new List<Button>();

        List<Button> allButtons = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            CreatingFigures();
            CreateBtnList();

        }

        private void CreatingFigures()
        {

            #region drawWhiteFigures


            #region drawWhitePawns
            whitePawn01.CreateIBForBG(whitePawn01.Name, btnA02);
            allPawns.Add(whitePawn01);
            whitePawn02.CreateIBForBG(whitePawn02.Name, btnB02);
            allPawns.Add(whitePawn02);
            whitePawn03.CreateIBForBG(whitePawn03.Name, btnC02);
            allPawns.Add(whitePawn03);
            whitePawn04.CreateIBForBG(whitePawn04.Name, btnD02);
            allPawns.Add(whitePawn04);
            whitePawn05.CreateIBForBG(whitePawn05.Name, btnE02);
            allPawns.Add(whitePawn05);
            whitePawn06.CreateIBForBG(whitePawn06.Name, btnF02);
            allPawns.Add(whitePawn06);
            whitePawn07.CreateIBForBG(whitePawn07.Name, btnG02);
            allPawns.Add(whitePawn07);
            whitePawn08.CreateIBForBG(whitePawn08.Name, btnH02);
            allPawns.Add(whitePawn08);
            #endregion

            #region CreatingAndDrawingWhiteRooks
            whiteRook01.CreateIBForBG(whiteRook01.Name, btnA01);
            allRooks.Add(whiteRook01);
            whiteRook02.CreateIBForBG(whiteRook02.Name, btnH01);
            allRooks.Add(whiteRook02);
            #endregion

            #region CreatingAndDrawingWhiteBishops
            whiteBishop01.CreateIBForBG(whiteBishop01.Name, btnC01);
            allBishops.Add(whiteBishop01);
            whiteBishop02.CreateIBForBG(whiteBishop02.Name, btnF01);
            allBishops.Add(whiteBishop02);
            #endregion

            #region CreatingAndDrawingWhiteKnights
            whiteKnight01.CreateIBForBG(whiteKnight01.Name, btnB01);
            allKnights.Add(whiteKnight01);
            whiteKnight02.CreateIBForBG(whiteKnight02.Name, btnG01);
            allKnights.Add(whiteKnight02);
            #endregion

            #region CreatingAndDrawingWhiteQueen
            whiteQueen01.CreateIBForBG(whiteQueen01.Name, btnD01);
            allQueens.Add(whiteQueen01);
            #endregion

            #region CreatingAndDrawingWhiteKing
            whiteKing01.CreateIBForBG(whiteKing01.Name, btnE01);
            allKings.Add(whiteKing01);
            #endregion

            #endregion

            #region drawBlackFigures

            #region CreatingAndDrawingBlackPawns
            blackPawn01.CreateIBForBG(blackPawn01.Name, btnA07);
            allPawns.Add(blackPawn01);
            blackPawn02.CreateIBForBG(blackPawn02.Name, btnB07);
            allPawns.Add(blackPawn02);
            blackPawn03.CreateIBForBG(blackPawn03.Name, btnC07);
            allPawns.Add(blackPawn03);
            blackPawn04.CreateIBForBG(blackPawn04.Name, btnD07);
            allPawns.Add(blackPawn04);
            blackPawn05.CreateIBForBG(blackPawn05.Name, btnE07);
            allPawns.Add(blackPawn05);
            blackPawn06.CreateIBForBG(blackPawn06.Name, btnF07);
            allPawns.Add(blackPawn06);
            blackPawn07.CreateIBForBG(blackPawn07.Name, btnG07);
            allPawns.Add(blackPawn07);
            blackPawn08.CreateIBForBG(blackPawn08.Name, btnH07);
            allPawns.Add(blackPawn08);

            #endregion

            #region CreatingAndDrawingBlackRooks
            blackRook01.CreateIBForBG(blackRook01.Name, btnA08);
            allRooks.Add(blackRook01);
            blackRook02.CreateIBForBG(blackRook02.Name, btnH08);
            allRooks.Add(blackRook02);
            #endregion

            #region CreatingAndDrawingBlackBishops
            blackBishop01.CreateIBForBG(blackBishop01.Name, btnC08);
            allBishops.Add(blackBishop01);
            blackBishop02.CreateIBForBG(blackBishop02.Name, btnF08);
            allBishops.Add(blackBishop02);
            #endregion

            #region CreatingAndDrawingBlackKnights
            blackKnight01.CreateIBForBG(blackKnight01.Name, btnB08);
            allKnights.Add(blackKnight01);
            blackKnight02.CreateIBForBG(blackKnight02.Name, btnG08);
            allKnights.Add(blackKnight02);
            #endregion

            #region CreatingAndDrawingBlackQueen
            blackQueen01.CreateIBForBG(blackQueen01.Name, btnD08);
            allQueens.Add(blackQueen01);
            #endregion

            #region CreatingAndDrawingBlackKing
            blackKing01.CreateIBForBG(blackKing01.Name, btnE08);
            allKings.Add(blackKing01);
            #endregion

            #endregion


        }

        private void CreateBtnList()
        {
            #region btnA
            allButtons.Add(btnA01);
            allButtons.Add(btnA02);
            allButtons.Add(btnA03);
            allButtons.Add(btnA04);
            allButtons.Add(btnA05);
            allButtons.Add(btnA06);
            allButtons.Add(btnA07);
            allButtons.Add(btnA08);
            #endregion

            #region btnB
            allButtons.Add(btnB01);
            allButtons.Add(btnB02);
            allButtons.Add(btnB03);
            allButtons.Add(btnB04);
            allButtons.Add(btnB05);
            allButtons.Add(btnB06);
            allButtons.Add(btnB07);
            allButtons.Add(btnB08);
            #endregion

            #region btnC
            allButtons.Add(btnC01);
            allButtons.Add(btnC02);
            allButtons.Add(btnC03);
            allButtons.Add(btnC04);
            allButtons.Add(btnC05);
            allButtons.Add(btnC06);
            allButtons.Add(btnC07);
            allButtons.Add(btnC08);
            #endregion

            #region btnD
            allButtons.Add(btnD01);
            allButtons.Add(btnD02);
            allButtons.Add(btnD03);
            allButtons.Add(btnD04);
            allButtons.Add(btnD05);
            allButtons.Add(btnD06);
            allButtons.Add(btnD07);
            allButtons.Add(btnD08);
            #endregion

            #region btnE
            allButtons.Add(btnE01);
            allButtons.Add(btnE02);
            allButtons.Add(btnE03);
            allButtons.Add(btnE04);
            allButtons.Add(btnE05);
            allButtons.Add(btnE06);
            allButtons.Add(btnE07);
            allButtons.Add(btnE08);
            #endregion

            #region btnF
            allButtons.Add(btnF01);
            allButtons.Add(btnF02);
            allButtons.Add(btnF03);
            allButtons.Add(btnF04);
            allButtons.Add(btnF05);
            allButtons.Add(btnF06);
            allButtons.Add(btnF07);
            allButtons.Add(btnF08);
            #endregion

            #region btnG
            allButtons.Add(btnG01);
            allButtons.Add(btnG02);
            allButtons.Add(btnG03);
            allButtons.Add(btnG04);
            allButtons.Add(btnG05);
            allButtons.Add(btnG06);
            allButtons.Add(btnG07);
            allButtons.Add(btnG08);
            #endregion

            #region btnH
            allButtons.Add(btnH01);
            allButtons.Add(btnH02);
            allButtons.Add(btnH03);
            allButtons.Add(btnH04);
            allButtons.Add(btnH05);
            allButtons.Add(btnH06);
            allButtons.Add(btnH07);
            allButtons.Add(btnH08);
            #endregion

        }

        private static ImageBrush CreateIBForBG(string chessPiece)
        {
            string[] split = chessPiece.Split('0');
            chessPiece = split[0];
            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"/Sprites/{chessPiece}.png"));
            return brush;
        }



        #region WhitePawnMoves
        public void WhitePawnsAvailableMoves(string chessPiece, string btn)
        {
            string btnName = btn;
            string[] btnNameSplit = btnName.Split('0');
            int splittedName = Convert.ToInt32(btnNameSplit[1]);

            if (chessPiece.Contains("whitePawn"))
            {
                string availableMovementBtn = btnNameSplit[0] + "0" + Convert.ToString(splittedName + 1);
                foreach (Button btnn in allButtons)
                {
                    if (btnn.Name.ToString() == availableMovementBtn && btnn.Tag == null || btnn.Tag.ToString().Length < 1)
                    {
                        btnn.Foreground = Brushes.Green;
                        btnn.FontSize = 35;
                        btnn.Content = "O";
                        btnn.Tag = chessPiece;
                    }
                    else if (btnn.Name.ToString() == availableMovementBtn && btnn.Tag.ToString().Length > 1)
                    {
                        btnn.Foreground = Brushes.Red;
                        btnn.FontSize = 35;
                        btnn.Content = "X";
                    }
                }
            }
        }

        public void HideWhitePawnsAvailableMoves(string chesspiece, string btn)
        {
            string btnName = btn;
            string[] btnNameSplit = btnName.Split('0');
            int splittedName = Convert.ToInt32(btnNameSplit[1]);

            if (chesspiece.Contains("whitePawn"))
            {
                string availableMovementBtn = btnNameSplit[0] + "0" + Convert.ToString(splittedName + 1);
                foreach (Button btnn in allButtons)
                {
                    if (btnn.Name.ToString() == availableMovementBtn)
                    {

                        btnn.Foreground = Brushes.Transparent;
                        btnn.FontSize = 35;
                        btnn.Content = string.Empty;
                        btnn.Tag = string.Empty;
                    }
                }
            }
        }


        #endregion

        #region redrawPosition

        private void redrawPawnPosition(Pawn pawn, Button btn)
        {
            pawn.CreateIBForBG(pawn.Name, btn);
        }
        #endregion

        private void btnA02_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!figureChosen) 
                {
                    figureChosen = true;
                    chosenButton.Add(btnA02);
                    if (btnA02.Tag.ToString().Contains("whitePawn") && btnA02.Tag != null)
                    {
                        
                        WhitePawnsAvailableMoves(btnA02.Tag.ToString(), btnA02.Name);
                    }
                }
                else
                {
                    if (figureChosen)
                    {
                        figureChosen = false;
                        chosenButton.Clear();
                        if (btnA02.Tag.ToString().Contains("whitePawn") && btnA02.Tag != null)
                        {
                            HideWhitePawnsAvailableMoves(btnA02.Tag.ToString(), btnA02.Name);
                        }

                    }
                }    
                
            }
            catch
            {
                

            }
        }

        private void btnA03_Click(object sender, RoutedEventArgs e)
        {
            if (figureChosen && btnA03.Content.ToString() == "O" && btnA03.Tag.ToString().Contains("whitePawn"))
            {
                foreach (Pawn pawn in allPawns)
                {
                    if (pawn.Name == btnA03.Tag.ToString())
                    {
                        btnA03.Content = "";
                        redrawPawnPosition(pawn, btnA03);
                        chosenButton[0].Background = Brushes.Transparent;
                        chosenButton[0].Tag = "";
                        chosenButton.Clear();
                    }
                }
               
            }
        }


    }
}
