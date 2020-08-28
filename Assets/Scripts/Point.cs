using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
        public int x;
        public int y;

        public Point(int nx, int ny)
        {
            x = nx;
            y = ny;
        }

        public void mult(int m)
        {
            x *= m;
            y *= m;
        }

        public void add(Point p)
        {
            x += p.x;
            y += p.y;
        }


        
        public Vector2 ToVector()
        {
            return new Vector2(x, y);
        }

        public bool Equal(Point p)
        {
            return (x == p.x && y == p.y);
        }

        public static Point fromVector(Vector2 v)
        {
            return new Point((int)v.x, (int)v.y);
        }

        public static Point fromVector(Vector3 v)
        {
            return new Point((int)v.x, (int)v.y);
        }

        public static Point mult(Point p , int m)
        {
            return new Point(p.x * m, p.y * m);
        }

        public static Point add(Point p , Point o)
        {
            return new Point(p.x + o.x, p.y + o.y);
        }

        public static Point Clone(Point p)
        {
            return new Point(p.x, p.y);
        }

        public static Point zero
        {
            get { return new Point(0, 0); }
        }
        public static Point one
        {
            get { return new Point(1, 1); }
        }
        public static Point up
        {
            get { return new Point(0, 1); }
        }
        public static Point down
        {
            get { return new Point(0, -1); }
        }
        public static Point right
        {
            get { return new Point(1, 0); }
        }
        public static Point left
        {
            get { return new Point(-1, 0); }
        }

        public static bool DirectOfListPoint(List<Point> list)   //true : horizontal , false : vertical
        {
            int count = list.Count;
            for(int i = 0; i < count-1; i++)
            {
                if (list[i].y != list[i + 1].y)
                {
                    return false;
                }
            }
            return true;
        }
    public static Point PHightest(List<Point> list)
    {
        Point temp = Point.zero;
        if (!Point.DirectOfListPoint(list))
        {
            for (int i = 0; i < list.Count ; i++)
            {
                if (list[i].y > temp.y)
                {
                    temp = Point.Clone(list[i]);
                }
            }
        }

        return temp;
    }

    public static Point PMostRight(List<Point> list)
    {
        Point temp = Point.zero;
        if (Point.DirectOfListPoint(list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].x > temp.x)
                {
                    temp = Point.Clone(list[i]);
                }
            }
        }

        return temp;
    }
}

