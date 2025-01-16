using Microsoft.VisualBasic.ApplicationServices;
using ScottPlot;

namespace ParticleSwarmAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            aTextBox.Text = "-4";
            bTextBox.Text = "12";
            dComboBox.SelectedIndex = 2;
            nTextBox.Text = "50";
            tTextBox.Text = "100";
            c1TextBox.Text = "0.8";
            c2TextBox.Text = "1";
            c3TextBox.Text = "1.2";
        }
        int a;
        int b;
        int d;
        int n;
        int t;
        double c1;
        double c2;
        double c3;
        private void StartButton_Click(object sender, EventArgs e)
        {
            this.graph.Plot.Clear();
            this.animationGraph.Plot.Clear();

            a = int.Parse(aTextBox.Text);
            b = int.Parse(bTextBox.Text);
            d = (int)((-1) * Math.Log10(Convert.ToDouble(dComboBox.Text)));
            t = int.Parse(tTextBox.Text);
            n = int.Parse(nTextBox.Text);
            c1 = double.Parse(c1TextBox.Text);
            c2 = double.Parse(c2TextBox.Text);
            c3 = double.Parse(c3TextBox.Text);


            double[] dataX = new double[t];
            double[] dataMaxY = new double[t];
            double[] dataAvgY = new double[t];
            double[] dataMinY = new double[t];

            Swarm[] swarm = new Swarm[t];

            swarm[0] = new Swarm(a, b, d, n, c1, c2, c3);
            dataX[0] = 1;
            dataMaxY[0] = Swarm.bgy;
            dataAvgY[0] = swarm[0].avgY;
            dataMinY[0] = swarm[0].minY;
            for (int i = 1; i < t; ++i)
            {
                swarm[i] = new Swarm(swarm[i - 1]);
                dataX[i] = i + 1;
                dataMaxY[i] = Swarm.bgy;
                dataAvgY[i] = swarm[i].avgY;
                dataMinY[i] = swarm[i].minY;
            }
            //wynik
            resTextBox.Text = "x = " + Swarm.bgx + " f(x) = " + Swarm.bgy;
            //wykres
            this.graph.Plot.AddScatter(dataX, dataMaxY, label: "BestY"); // wyrzuca x > b
            this.graph.Plot.AddScatter(dataX, dataAvgY, label: "AvgY"); // czasem avg == min
            this.graph.Plot.AddScatter(dataX, dataMinY, label: "MinY");
            this.graph.Plot.Legend();
            this.graph.Plot.AxisAuto();
            this.graph.Plot.SetAxisLimitsY(-2.1, 2.1, 0);
            this.graph.Refresh();
            // animacja
            double[] dataAnimY = new double[n];
            for(int i = 0; i < t; ++i )
            {
                Thread.Sleep(10000 / t);
                this.animationGraph.Plot.Clear();
                this.animationGraph.Plot.AddScatterPoints(swarm[i].xArr, dataAnimY, Color.Navy, 10, MarkerShape.filledDiamond);
                this.animationGraph.Plot.AxisAuto();
                this.animationGraph.Plot.YAxis.Ticks(false);
                this.animationGraph.Plot.SetAxisLimitsX(a - 0.1, b + 0.1, 0);
                this.animationGraph.Refresh();
            }
        }
    }
}