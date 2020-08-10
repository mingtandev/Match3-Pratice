using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
        //Field : là thuộc tính luôn luôn ở mode private
        //Quy tắc dặt tên field : camelCase
        public int x;
        public int y;

        //Properties : là một phần mở rông của field(cũng đc hiểu như thuộc tính) , thông qua properties ta có thể thay đổi các field(để tiện validation)
        //Quy tắc dặt tên Properties : PascalCase
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
}

