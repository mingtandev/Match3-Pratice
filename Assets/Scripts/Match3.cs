using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Match3 : MonoBehaviour
{



    [Header("UI Element")]
    public Node[,] board;
    int width = 9;
    int height = 14;
    public ArrayLayout boardLayout;
    public Sprite[] pieces;
    public RectTransform gameBoard;
    [Header("Prefabs")]
    public GameObject nodePiece;
    System.Random random;


    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        random = new System.Random();
        InitializeBoard();
        verifyBoard();
        InstantiateBoard(); 
    }

    void InitializeBoard()
    {
        board = new Node[width, height];
        for(int y = 0; y <height; y++)
        {
            for(int x = 0; x<width; x++)
            {
                board[x, y] = new Node(boardLayout.rows[y].row[x] ? -1 : fillPice(), new Point(x, y)); 
            }
        }
    }

    void verifyBoard()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Point p = new Point(x, y);
                int val = getValueAtPoint(p);
                if (val <= 0) continue;
                //Fill match when random
                List<int> remove = new List<int>();
                while (isConnected(p, true).Count > 0)
                {
                    val = getValueAtPoint(p);
                    if (!remove.Contains(val))
                        remove.Add(val);

                    setValueAtPoint(p, newValue(remove));


                }
            }
        }
    }

    void InstantiateBoard()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int val = board[x, y].value;
                if (val <= 0) continue;

                GameObject p = Instantiate(nodePiece, gameBoard);
                RectTransform rect = p.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(32 + (64 * x), -32 - (64 * y));

                //Component node quản lý giá trị tại mỗi node ( value ,index , spirte , ...)
                NodePiece node = p.GetComponent<NodePiece>();
                node.Initialize(val, new Point(x, y), pieces[val - 1]);

            }
        }
    }
    void setValueAtPoint(Point p , int val)
    {
        board[p.x, p.y].value = val;
    }

    int newValue(List<int> remove)
    {
        List<int> avaible = new List<int>();
        for(int i = 0; i < pieces.Length; i++)
        {
            avaible.Add(i + 1); //add value
        }

        foreach(int i in remove)
        {
            if (avaible.Contains(i))
                avaible.Remove(i);
        }

        if (avaible.Count <= 0) return 0;   //Khi xung quanh random giá trị nào cũng match đc thì phải trả về blank để qua Point tiếp theo

        return avaible[random.Next(0, avaible.Count)];

    }
    List<Point> isConnected(Point p , bool main)
    {
        List<Point> connected = new List<Point>();
        int val = getValueAtPoint(p);
        Point[] direction = 
        { 
            Point.up, 
            Point.right, 
            Point.down, 
            Point.left 
        };
        //At each point , checking if these is 2 or more same piece in direction
        foreach(Point dir in direction)
        {
            List<Point> line = new List<Point>();    //Store dir has been check
            int same = 0; //count same block
            for(int i = 1; i<3; i++)
            {
                Point check = Point.add(p, Point.mult(dir, i));
                if (getValueAtPoint(check) == val)
                {
                    line.Add(check);
                    same++;
                }
            }

            if (same > 1)  //same is 2 or more  , Concatenating list connected and line 
            {
                AddPoints(ref connected, line);
            }
        }


        if (main) //Checks for other matches along the current match
        {
            for (int i = 0; i < connected.Count; i++)
                AddPoints(ref connected, isConnected(connected[i], false));
        }


        return connected;
    }

    void AddPoints(ref List<Point> points , List<Point> newList)
    {
        foreach(Point p in newList)
        {
            bool isDuplicate = false;  //check not duplicate
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Equal(p))
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate) points.Add(p);
        }
    }

    int getValueAtPoint(Point p)
    {
        if (p.x < 0 || p.x >= width || p.y < 0 || p.y >= height) return -1;

        return board[p.x, p.y].value;
    }

    int fillPice()
    {
        int val = 1;
        val = (random.Next(0, 100) / (100 / pieces.Length)) + 1;
        return val;
    }



    void Update()
    {
        
    }
}


[System.Serializable]
public class Node
{
    public int value; // 0 : blank , 1 : cube , 2 : sphere , 3 : cylinder , 4 : pryamid , 5 : diamond , -1 : hole
    public Point index;
     
    public Node(int v , Point i)
    {
        value = v;
        index = i;
    }
}
