using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace marto_app
{
    public class figures
    {
        
        public string name { get; set; }
        public SolidColorBrush bg { get; set; }
        public int totalLabelsIncluded { get; set; }
        public int validPositions = 0;
        public List<string> validPosStartPnt = new List<string>();

        public figures(string namE, SolidColorBrush color, int totalLabelsincluded)
        {
            name = namE;
            bg = color;
            totalLabelsIncluded = totalLabelsincluded;
        }


        public void buildFigure1a(Label startPoint, figures figure, List<Label> allLabels, bool counting)
        {

            if(startPoint.Name.Contains('x') && startPoint.Name.Contains('y'))
            {
                startPoint.Background = figure.bg;

                //x1y1Lbl
                int startPointX = Convert.ToInt32(startPoint.Name[1].ToString());
                int startPointY = Convert.ToInt32(startPoint.Name[3].ToString());
                findLabelByXandY(startPointX, startPointY, allLabels, figure);

                // find second label from start point
                int secondPointX = startPointX;
                int secondPointY = startPointY + 1;
                findLabelByXandY(secondPointX, secondPointY, allLabels, figure);

                // find third label from second label
                int thirdPointX = secondPointX + 1;
                int thirdPointY = secondPointY;
                findLabelByXandY(thirdPointX, thirdPointY, allLabels, figure);

                // find fourth label from third label
                int fourthPointX = thirdPointX + 1;
                int fourthPointY = thirdPointY;
                findLabelByXandY(fourthPointX, fourthPointY, allLabels, figure);

                // find fifth label from fourth label
                int fifthPointX = fourthPointX;
                int fifthPointY = fourthPointY + 1;
                findLabelByXandY(fifthPointX, fifthPointY, allLabels, figure);

                bool validation = validateFigure(figure.totalLabelsIncluded, figure.bg, allLabels);

                if (validation && counting)
                {
                    figure.validPositions++;
                    validPosStartPnt.Add(startPoint.Name.ToString());
                }
                else
                {

                }
            }
           
        }


        private void findLabelByXandY(int x, int y, List<Label> allLabels, figures figure)
        {
            foreach(Label label in allLabels)
            {
                string newLblName = 'x' + x.ToString() + 'y' + y.ToString() + "Lbl";
                if (label.Name.ToString() == newLblName)
                {
                    label.Background = figure.bg;
                }
                
            }
        }

        private bool validateFigure(int numberOfLabelsInFigure, SolidColorBrush figureColor, List<Label> allLabels)
        {
            int counter = 0;

            foreach ( Label label in allLabels )
            {
                if (label.Background.Equals(figureColor))
                {
                    counter++;
                }
            }

            if(counter == numberOfLabelsInFigure)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
