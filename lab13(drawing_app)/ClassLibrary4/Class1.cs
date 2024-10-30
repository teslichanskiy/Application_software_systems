using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary4
{
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
