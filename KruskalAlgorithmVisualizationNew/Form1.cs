using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KruskalAlgorithmVisualizationNew
{
    public partial class MainForm : Form
    {
        private int nodeRadius = 10;
        private List<Point> nodes;
        private List<Tuple<Point, Point>> edges;
        private List<Tuple<Point, Point>> minimumSpanningTree;
        private Random random;

        public MainForm()
        {
            InitializeComponent();
            random = new Random();
            nodes = new List<Point>();
            edges = new List<Tuple<Point, Point>>();
            minimumSpanningTree = new List<Tuple<Point, Point>>();
        }

        private void GenerateGraphButton_Click(object sender, EventArgs e)
        {
            nodes.Clear();
            edges.Clear();
            minimumSpanningTree.Clear();

            int numNodes = Convert.ToInt32(numNodesTextBox.Text);
            int width = graphPictureBox.Width;
            int height = graphPictureBox.Height;

            for (int i = 0; i < numNodes; i++)
            {
                int x = random.Next(nodeRadius, width - nodeRadius);
                int y = random.Next(nodeRadius, height - nodeRadius);
                nodes.Add(new Point(x, y));
            }

            for (int i = 0; i < numNodes; i++)
            {
                for (int j = i + 1; j < numNodes; j++)
                {
                    edges.Add(new Tuple<Point, Point>(nodes[i], nodes[j]));
                }
            }

            edges.Sort((a, b) =>
            {
                double distA = GetDistance(a.Item1, a.Item2);
                double distB = GetDistance(b.Item1, b.Item2);
                return distA.CompareTo(distB);
            });

            minimumSpanningTree = KruskalAlgorithm();

            graphPictureBox.Invalidate();
        }

        private List<Tuple<Point, Point>> KruskalAlgorithm()
        {
            List<Tuple<Point, Point>> result = new List<Tuple<Point, Point>>();
            int[] parent = new int[nodes.Count];
            int[] rank = new int[nodes.Count];

            for (int i = 0; i < nodes.Count; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }

            foreach (var edge in edges)
            {
                int rootA = Find(parent, nodes.IndexOf(edge.Item1));
                int rootB = Find(parent, nodes.IndexOf(edge.Item2));

                if (rootA != rootB)
                {
                    result.Add(edge);
                    Union(parent, rank, rootA, rootB);
                }
            }

            return result;
        }

        private int Find(int[] parent, int i)
        {
            if (parent[i] != i)
                parent[i] = Find(parent, parent[i]);
            return parent[i];
        }

        private void Union(int[] parent, int[] rank, int x, int y)
        {
            int rootX = Find(parent, x);
            int rootY = Find(parent, y);

            if (rank[rootX] < rank[rootY])
                parent[rootX] = rootY;
            else if (rank[rootX] > rank[rootY])
                parent[rootY] = rootX;
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }
        }

        private double GetDistance(Point p1, Point p2)
        {
            int dx = p2.X - p1.X;
            int dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void GraphPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var edge in edges)
            {
                Pen pen = new Pen(Color.Gray, 2f);
                g.DrawLine(pen, edge.Item1, edge.Item2);
            }

            foreach (var edge in minimumSpanningTree)
            {
                Pen pen = new Pen(Color.Red, 2f);
                g.DrawLine(pen, edge.Item1, edge.Item2);
            }

            foreach (var node in nodes)
            {
                int nodeSize = nodeRadius * 2;
                Rectangle nodeRect = new Rectangle(node.X - nodeRadius, node.Y - nodeRadius, nodeSize, nodeSize);

                using (Brush fillBrush = new SolidBrush(Color.White))
                {
                    g.FillEllipse(fillBrush, nodeRect);
                }

                using (Pen borderPen = new Pen(Color.Black, 2f))
                {
                    g.DrawEllipse(borderPen, nodeRect);
                }
            }
        }

    }
}
