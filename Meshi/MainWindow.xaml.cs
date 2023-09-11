using System;
using System.Collections.Generic;
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

namespace Meshi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string statsGraph = getGraph();
            PointCollection graphing = PointCollection.Parse(statsGraph);
            GraphDrawn.Points = graphing;

        }
        private string getGraph()
        {            
            //temporary get input
            string CaloriesInput  = getInput(CaloriesNum.txtInput.Text);
            string ProteinInput = getInput(ProteinNum.txtInput.Text);
            string FatInput = getInput(FatNum.txtInput.Text);
            string CarbsInput = getInput(CarbsNum.txtInput.Text);
            string CalciumInput = getInput(CalciumNum.txtInput.Text);
            string IronInput = getInput(IronNum.txtInput.Text);
            string VitaminAInput = getInput(VitaminANum.txtInput.Text);
            string SodiumInput = getInput(SodiumNum.txtInput.Text);
            string VitaminCInput = getInput(VitaminCNum.txtInput.Text);
            string graph = "";

            //out of 2000 calorie diet
            double x = 170;
            double y = 170-((double.Parse(CaloriesInput) / 2000) * 170);
            graph += x + "," + y + " ";

            //out of 56 gram protein diet
            double proteinH = Double.Parse(ProteinInput)/56 * 170;
            x = calculateX(proteinH, 1);
            y = calculateY(proteinH, 1);
            graph += x + "," + y + " ";
            x = calculateX(getH(Double.Parse(FatInput)), 2);
            y = calculateY(getH(Double.Parse(FatInput)), 2);
            graph += x + "," + y + " ";
            x = calculateX(getH(Double.Parse(CarbsInput)), 3);
            y = calculateY(getH(Double.Parse(CarbsInput)), 3);
            graph += x + "," + y + " ";
            x = calculateX(getH(Double.Parse(CalciumInput)), 4);
            y = calculateY(getH(Double.Parse(CalciumInput)), 4);
            graph += x + "," + y + " ";
            x = calculateX(getH(Double.Parse(IronInput)), 5);
            y = calculateY(getH(Double.Parse(IronInput)), 5);
            graph += x + "," + y + " ";
            x = calculateX(getH(Double.Parse(VitaminAInput)), 6);
            y = calculateY(getH(Double.Parse(VitaminAInput)), 6);
            graph += x + "," + y + " ";
            x = calculateX(getH(Double.Parse(SodiumInput)), 7);
            y = calculateY(getH(Double.Parse(SodiumInput)), 7);
            graph += x + "," + y + " ";
            x = calculateX(getH(Double.Parse(VitaminCInput)), 8);
            y = calculateY(getH(Double.Parse(VitaminCInput)), 8);
            graph += x + "," + y;

            return graph;
        }

        private double calculateX(double h, int i)
        {
            if (i > 0 && i < 9) return (170 + (Math.Sin(Math.PI * (40*i) / 180.0) * h));
            else return 0;
        }
        private double calculateY(double h, int i)
        {
            if (i > 0 && i < 9) return (170 - (Math.Cos(Math.PI * (40 * i) / 180.0) * h));
            else return 0;
        }
        private double getH(double input)
        {
             return ((input)*170 / 100);   
        }
        private string getInput(string source)
        {
            if (string.IsNullOrEmpty(source)) return "0";
            else return source;
        }

    }
}
