using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab13
{
    public partial class Form1 : Form
    {
        private ShapeCollection shapes = new ShapeCollection();
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing = false;

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;

        private BufferedGraphicsContext bufferedGraphicsContext = BufferedGraphicsManager.Current;
        private BufferedGraphics bufferedGraphics;

        private List<Point> curvePoints = new List<Point>(); // Список точек для кривой
        private List<Point> fillPoints = new List<Point>(); // Список точек для заливки

        public Form1()
        {
            InitializeComponent();

            comboBox1 = new System.Windows.Forms.ComboBox();
            comboBox1.Items.AddRange(new object[] { "Line", "Curve", "Area Fill", "Bezier Curve" });
            comboBox1.Location = new Point(10, 10);
            comboBox1.SelectedIndex = 0;
            this.Controls.Add(comboBox1);

            panel1 = new Panel();
            panel1.Dock = DockStyle.Fill;
            this.Controls.Add(panel1);
            bufferedGraphics = bufferedGraphicsContext.Allocate(panel1.CreateGraphics(), panel1.ClientRectangle);

            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            panel1.Paint += panel1_Paint;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                endPoint = e.Location;
                isDrawing = true;

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Curve":
                        curvePoints.Add(startPoint); // Добавляем точку в список для кривой
                        break;
                    case "Area Fill":
                        fillPoints.Add(startPoint); // Добавляем точку в список для заливки
                        break;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                endPoint = e.Location;

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Curve":
                        curvePoints.Add(endPoint); // Добавляем точку в список для кривой
                        shapes.AddShape(new Curve(Color.Green, curvePoints)); // Добавляем кривую в shapes                                                 
                        break;
                    case "Area Fill":
                        fillPoints.Add(endPoint); // Добавляем точку в список для заливки
                        shapes.AddShape(new AreaFill(Color.Blue, fillPoints)); // Добавляем заливку в shapes
                        break;
                }

                panel1.Invalidate(); // Перерисовываем панель
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Line":
                        shapes.AddShape(new Line(Color.Red, startPoint, endPoint));
                        break;
                    case "Bezier Curve":
                        shapes.AddShape(new BezierCurve(Color.Black, startPoint, new Point(startPoint.X + 50, startPoint.Y), new Point(endPoint.X - 50, endPoint.Y), endPoint));
                        break;
                    
                }

                isDrawing = false;
                panel1.Invalidate();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            bufferedGraphics.Graphics.Clear(Color.White); // Очистка буфера
            shapes.DrawShapes(bufferedGraphics.Graphics); // Рисование фигур

            if (isDrawing)
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Curve":
                        if (curvePoints.Count >= 2) // Проверяем наличие минимум двух точек
                        {
                            bufferedGraphics.Graphics.DrawCurve(Pens.Green, curvePoints.ToArray()); // Рисуем временную кривую
                        }
                        break;
                        
                    case "Area Fill":
                        bufferedGraphics.Graphics.DrawPolygon(Pens.Blue, fillPoints.ToArray()); // Рисуем временную линию для заливки
                        break;
                    case "Bezier Curve":
                        bufferedGraphics.Graphics.DrawBezier(Pens.Black, startPoint, new Point(startPoint.X + 50, startPoint.Y), new Point(endPoint.X - 50, endPoint.Y), endPoint); // Рисуем временную кривую Безье
                        break;
                }
            }

            bufferedGraphics.Render();
            
            // Перенос рисунка на панель
        }

        
    }
    public abstract class Shape
    {
        public Color Color { get; set; }
        public Pen Pen { get; private set; }

        public Shape(Color color)
        {
            Color = color;
            Pen = new Pen(color, 2); // Толщина линии по умолчанию - 2 пикселя
        }

        public abstract void Draw(Graphics g);
    }

    public class Line : Shape
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Color color, Point start, Point end) : base(color)
        {
            Start = start;
            End = end;
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(Pen, Start, End);
        }
    }

    public class Curve : Shape
    {
        public List<Point> Points { get; set; }

        public Curve(Color color, List<Point> points) : base(color)
        {
            Points = points;
        }

        public override void Draw(Graphics g)
        {
            if (Points.Count > 1)
            {
                g.DrawCurve(Pen, Points.ToArray());
            }
        }
    }

    public class AreaFill : Shape
    {
        public List<Point> Points { get; set; }

        public AreaFill(Color color, List<Point> points) : base(color)
        {
            Points = points;
        }

        public override void Draw(Graphics g)
        {
            if (Points.Count > 2)
            {
                g.FillPolygon(new SolidBrush(Color), Points.ToArray());
            }
        }
    }

    public class BezierCurve : Shape
    {
        public Point Start { get; set; }
        public Point ControlPoint1 { get; set; }
        public Point ControlPoint2 { get; set; }
        public Point End { get; set; }

        public BezierCurve(Color color, Point start, Point controlPoint1, Point controlPoint2, Point end) : base(color)
        {
            Start = start;
            ControlPoint1 = controlPoint1;
            ControlPoint2 = controlPoint2;
            End = end;
        }

        public override void Draw(Graphics g)
        {
            g.DrawBezier(Pen, Start, ControlPoint1, ControlPoint2, End);
        }
    }

    public class ShapeCollection
    {
        public List<Shape> Shapes { get; set; } = new List<Shape>();

        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        public void DrawShapes(Graphics g)
        {
            foreach (var shape in Shapes)
            {
                shape.Draw(g);
            }
        }
    }

    
}
