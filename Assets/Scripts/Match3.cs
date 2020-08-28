using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Match3 : MonoBehaviour
{



    [Header("UI Element")]
    public Node[,] board;

    int width = 9;
    int height = 14;
    public ArrayLayout boardLayout;

    public Sprite[] pieces;

    public Sprite[] piecesWakeUp;
    public RectTransform gameBoard;
    public RectTransform gameBoardTitles;
    public RectTransform explosionBoard;
    public Sprite[] boardTitles;

    [Header("Prefabs")]
    public GameObject nodePiece;
    public GameObject BoardTitle;
    public GameObject[] explosion;
    System.Random random;

    List<NodePiece> update;
    List<FlippedPices> flipped;
    List<NodePiece> dead;

    void Start()
    {

        StartGame();
    }

    void StartGame()
    {
        RenderBoardTitle();
        random = new System.Random();
        update = new List<NodePiece>();
        flipped = new List<FlippedPices>();
        dead = new List<NodePiece>();
        InitializeBoard();
        verifyBoard();
        InstantiateBoard();
    }

    void Update()
    {
        

        List<NodePiece> finishedUpdating = new List<NodePiece>(); 
        for(int i = 0; i < update.Count; i++)
        {
            //change sprite wakeup
            update[i].GetComponent<Image>().sprite = piecesWakeUp[update[i].value - 1];

            NodePiece piece = update[i];
            bool updating = piece.UpdatePiece();
            if (!updating)
            {
                finishedUpdating.Add(update[i]);
                //Reset Sprite To Sleep
                update[i].GetComponent<Image>().sprite = pieces[update[i].value - 1];
            }
        }
        //Khi update xong , đã có vị trí mới , loop dưới đây xử lý những piece đã update xong
        for (int i = 0; i < finishedUpdating.Count; i++)
        {

            List<List<Point>> list2Connect = new List<List<Point>>(2);
            NodePiece piece = finishedUpdating[i];
            NodePiece flippedPiece = null;




            //Kiểm tra xem nếu có FLIP thì lấy ra sau đó thực hiện liên tiếp các bước bên dưới
            FlippedPices flipMaster = getFlip(piece);

            List<Point> connected = isConnected(piece.index, true);

            bool isFlipped = (flipMaster != null);

            //Initilize FX effect
            //First : check at connect 1
            int isGreate5_1 = connected.Count;
            Point pConnect_1 = Point.PHightest(connected);
            Point Pconnect_1_H = Point.PMostRight(connected);  //most right for horizontal 
            bool isHorizontal_1 = Point.DirectOfListPoint(connected);

            Point pConnect_2 = Point.zero;
            Point pConnect_2_H = Point.zero;
            int isGreate5_2 = 0;
            bool isHorizontal_2 = true;

            //Nếu có flip thì lấy ra otherPiece flipped của piece hiện tại
            if (isFlipped)
            {
                flippedPiece = flipMaster.getOtherPiece(piece);
                List<Point> connected2 = isConnected(flippedPiece.index, true);
                pConnect_2 = Point.PMostRight(connected2);
                isGreate5_2 = connected2.Count;//check at connect 2
                isHorizontal_2 = Point.DirectOfListPoint(connected2);

                AddPoints(ref connected, connected2);
            }

            if (connected.Count == 0)  //Neu khong co match nao
            {
                //Nếu có flip thì back về
                if (isFlipped)
                {
                    FlipPieces(piece.index, flippedPiece.index, false); // false : không add vào flip nữa , nghĩa là 2 khối sau khi có vị trí mới(ở update trên) , sẽ quay lại vị trí cũ
                }
            }
            else  // >0 ( =2  , =3 , ... )
            {

                Debug.Log(Pconnect_1_H.x);
                //_____________________________CREATE FX__________________________________-
                bool isGreate4 = (connected.Count >= 4) ? true : false;
                //Create FX if greate 5 pieces
                if (isGreate5_1 >=5)
                {

                    //create FX
                    //Get point highest (cuz long prefabs(pivot) set only for highest point)
                    if (isHorizontal_1)  //if horizontal
                    {
                        GameObject longFX = InstaniateExpolsion(Pconnect_1_H.x, Pconnect_1_H.y, 8);
                        RectTransform rectLong;
                        rectLong = longFX.GetComponent<RectTransform>();
                        rectLong.anchoredPosition = new Vector2(rectLong.anchoredPosition.x+16, rectLong.anchoredPosition.y);
                        rectLong.sizeDelta = new Vector2((isGreate5_1 + 1) * 50f, rectLong.sizeDelta.y);
                    }
                    else  //vertical
                    {
                        GameObject longFX = InstaniateExpolsion(pConnect_1.x, pConnect_1.y, 7);
                        RectTransform rectLong;
                        rectLong = longFX.GetComponent<RectTransform>();
                        rectLong.anchoredPosition = new Vector2(rectLong.anchoredPosition.x, rectLong.anchoredPosition.y - 16);
                        rectLong.sizeDelta = new Vector2(rectLong.sizeDelta.x, (isGreate5_1+1) * 50f);
                    }
                    isGreate5_1 = 0;
                }
                if (isGreate5_2 >=5 )
                {

                    //create FX
                    //Get point highest (cuz long prefabs(pivot) set only for highest point)
                    if (isHorizontal_2)  //if horizontal
                    {
                        GameObject longFX = InstaniateExpolsion(pConnect_2_H.x, pConnect_2_H.y, 8);
                        RectTransform rectLong;
                        rectLong = longFX.GetComponent<RectTransform>();
                        rectLong.anchoredPosition = new Vector2(rectLong.anchoredPosition.x+16, rectLong.anchoredPosition.y);
                        rectLong.sizeDelta = new Vector2((isGreate5_2 + 1) * 50f, rectLong.sizeDelta.y);
                    }
                    else
                    {
                        GameObject longFX = InstaniateExpolsion(pConnect_2.x, pConnect_2.y, 7);
                        RectTransform rectLong;
                        rectLong = longFX.GetComponent<RectTransform>();
                        rectLong.anchoredPosition = new Vector2(rectLong.anchoredPosition.x, rectLong.anchoredPosition.y - 16);
                        rectLong.sizeDelta = new Vector2(rectLong.sizeDelta.x, (isGreate5_2+1) * 50f);
                    }
                    isGreate5_2 = 0;
                }

                //_________________________kill all piece connected____________________________
                foreach (Point pnt in connected)
                {
                    Node node = getNodeAtPoint(pnt);
                    NodePiece nodePiece = node.getPiece();




                    #region explosion effect
                    //create explosion
                    GameObject exp = InstaniateExpolsion(pnt.x, pnt.y, nodePiece.value);

                    //create fx at pnt have greate 4 connect
                    if (isGreate4)
                    {
                        GameObject circleFX = InstaniateExpolsion(pnt.x, pnt.y, 6);
                        isGreate4 = false;
                    }

                    #endregion




                    //Kill pieces
                    if (nodePiece != null)
                    {
                        nodePiece.gameObject.SetActive(false);
                        dead.Add(nodePiece); //add to dead and regen on top
                    }
                    node.SetPiece(null);
                }

               

            }

            ApplyGravity();   //Luc piece roi xuong se add vao update => kiem tra connect tai do
            flipped.Remove(flipMaster);
            update.Remove(piece);
        }
    }


    void RenderBoardTitle()
    {
        int k = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject p = Instantiate(BoardTitle, gameBoardTitles);
                RectTransform rect = p.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(32 + (64 * x), -32 - (64 * y));

                if (k % 2 == 0)
                    p.GetComponent<Image>().sprite = boardTitles[0];
                else
                    p.GetComponent<Image>().sprite = boardTitles[1];
                k++;
                if(y==height-1)
                    k++;
            }
        }
    }


    #region Flip piece


    NodePiece getFlipped(NodePiece p)
    {
        NodePiece piece = null;
        for(int i = 0; i < flipped.Count; i++)
        {
            piece = flipped[i].getOtherPiece(p);
            if (piece != null) break;
        }

        return piece;
    }

    FlippedPices getFlip(NodePiece p)
    {
        FlippedPices temp = null;
        for(int i = 0; i < flipped.Count; i++)
        {
            if (flipped[i].getOtherPiece(p) != null)
            {
                temp = flipped[i];
                break;
            }
        }
        return temp;
    }

    public void FlipPieces(Point one, Point two, bool main)
    {
        if (getValueAtPoint(one) < 0)
            return;

        Node nodeOne = getNodeAtPoint(one);
        NodePiece pieceOne = nodeOne.getPiece();

        if (getValueAtPoint(two) > 0)
        {
            Node nodeTwo = getNodeAtPoint(two);
            NodePiece pieceTwo = nodeTwo.getPiece();

            nodeOne.SetPiece(pieceTwo);    //Đảo thuộc tính NodePiece cho nhau ,  => pos thay đổi , sau đó add vào update cho nó tự di chuyển về
            nodeTwo.SetPiece(pieceOne);

            if (main)
                flipped.Add(new FlippedPices(pieceOne, pieceTwo));

            update.Add(pieceOne);
            update.Add(pieceTwo);

        }
        else
            ResetPiece(pieceOne);

    }


    #endregion


    

    #region Process main(init , render , match , apply gravity ...)



    public void killPiece(Node node)
    {
        NodePiece nodePiece = node.getPiece();
        if (nodePiece != null)
        {
            nodePiece.gameObject.SetActive(false);
            dead.Add(nodePiece);
        }
        node.SetPiece(null);
    }

    void InitializeBoard()
    {
        board = new Node[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
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
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int val = board[x, y].value;
                if (val <= 0) continue;
                Node node = getNodeAtPoint(new Point(x, y));
                GameObject p = Instantiate(nodePiece, gameBoard);
                RectTransform rect = p.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(32 + (64 * x), -32 - (64 * y));

                //Component node quản lý giá trị tại mỗi node ( value ,index , spirte , ...)
                NodePiece piece = p.GetComponent<NodePiece>();

                piece.Initialize(val, new Point(x, y), pieces[val - 1]);

                node.SetPiece(piece);
            }
        }
    }

    void ApplyGravity()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = height - 1; y >= 0; y--)
            {
                Point currentPoint = new Point(x, y);
                int val = getValueAtPoint(currentPoint);
                Node node = getNodeAtPoint(currentPoint);
                if (val != 0) continue;    //only do when we have val = 0 (blank)


                for (int ny = y - 1; ny >= -1; ny--)
                {
                    int nextVal = getValueAtPoint(new Point(x, ny));
                    if (nextVal == 0) continue;

                    if (nextVal != -1)
                    {
                        Node n = getNodeAtPoint(new Point(x, ny));
                        NodePiece np = n.getPiece();

                        node.SetPiece(np);
                        update.Add(np); //add vào update để nó di chuyển , np đó xuống , đồng thời check connect tại vị trí mới

                        //Có thể thắc mắc tại sao np(NODE) tham chiếu np(N) nhưng khi set np(N) =  null thì np(NODE) k bị thay đổi gì?
                        // Do khi một component đã tồn tại thì việc set null là vô nghĩa , ta dùng SetPiece(null) vì trong method đó ta sẽ set value = 0 đưa về blank là chủ đạo
                        //Còn việc khi regen lại piece thì component đó xử(NodePiece) lý sau
                        n.SetPiece(null);
                    }
                    else //khi gap -1 -> dang o hole -> ket thuc gravity down
                    {
                        int newVal = fillPice();
                        NodePiece newPiece;
                        if (dead.Count > 0)
                        {
                            NodePiece respawn = dead[0];  //Moi lan chi dem 1 piece xuong
                            respawn.gameObject.SetActive(true);
                            newPiece = respawn;

                            dead.RemoveAt(0);

                            //Don` piece dau tien xuong truoc , sau do break , de curren heigh tang len 1 don vi
                            newPiece.Initialize(newVal, currentPoint, pieces[newVal - 1]);
                            newPiece.rect.anchoredPosition = getPostionFromPoint(new Point(x, -1));  //Tinh tu diem ban dau ngoai vung bien
                            node.SetPiece(newPiece);
                            update.Add(newPiece);
                        }
                    }
                    break;
                }
            }
        }
    }

    List<Point> isConnected(Point p, bool main)
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
        foreach (Point dir in direction)
        {
            List<Point> line = new List<Point>();    //Store dir has been check
            int same = 0; //count same block
            for (int i = 1; i < 3; i++)
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
        //                       X
        //check piece at mid    XOX
        for (int i = 0; i < 2; i++)
        {
            List<Point> line = new List<Point>();    //Store dir has been check
            int same = 0;
            Point[] check = { Point.add(p, direction[i]), Point.add(p, direction[i + 2]) };
            foreach (Point c in check)
            {
                if (getValueAtPoint(c) == val)
                {
                    line.Add(c);
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
            for (int i = 0; i < connected.Count; i++)  // Do connected.Count sẽ nới ra mỗi lần có connect => gọi hết tất cả các connect , chỉ set true là lần đầu tiên
                AddPoints(ref connected, isConnected(connected[i], false));
        }


        return connected;
    }

    GameObject InstaniateExpolsion(int x , int y , int val)
    {
        GameObject exp = Instantiate(explosion[val - 1], explosionBoard);
        exp.GetComponent<RectTransform>().anchoredPosition = getPostionFromPoint(new Point(x, y));
        Destroy(exp, 1);
        return exp;
    }

    #endregion



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

    int ad = 0;
    int fillPice()
    {
        int val = 1;
        val = (random.Next(0, 100) / (100 / pieces.Length)) + 1;
        return val;
    }

    public Vector2 getPostionFromPoint(Point p)
    {
        return new Vector2(32 + (64 * p.x), -32 - (64 * p.y));
    }

    public void ResetPiece(NodePiece piece)
    {
        piece.ResetPosition();   //Tra ve pos ban dau
        //piece.flipped = null;
        update.Add(piece);     // add piece vao de updating ve pos ban dau
    }


    Node getNodeAtPoint(Point p)
    {
        return board[p.x, p.y];
    }
 
}


[System.Serializable]
public class Node
{
    public int value; // 0 : blank , 1 : green , 2 : orange , 3 : purple, 4 : red , 5 : yellow, -1 : hole
    public Point index;
    NodePiece piece;
    public Node(int v , Point i)
    {
        value = v;
        index = i;
    }

    public void SetPiece(NodePiece p)
    {
        piece = p;
        value = (piece == null) ? 0 : piece.value;
        if (piece == null) return;
        piece.SetIndex(index);
    }

    public NodePiece getPiece()
    {
        return piece;
    }
}

[System.Serializable]
public class FlippedPices
{
    public NodePiece one;
    public NodePiece two;

    public FlippedPices(NodePiece a , NodePiece b)
    {
        one = a;
        two = b;
    }

    public NodePiece getOtherPiece(NodePiece p)
    {
        if (p == one) return two;
        else if (p == two) return one;
        else return null;
    }
}