using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MovingPiece : MonoBehaviour
{
    public static MovingPiece instance; //we can call it anywhere
    Match3 game;

    NodePiece moving;
    Point newIndex;
    Vector2 mouseStart;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        game = GetComponent<Match3>();
    }


    // Update is called once per frame
    void Update()
    {
        if (moving != null)  //if we need to moving
        {
            Vector2 dir = (Vector2)Input.mousePosition - mouseStart;
            Vector2 nDir = dir.normalized;
            Vector2 aDir = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y));

            newIndex = Point.Clone(moving.index);

            Point add = Point.zero;

            if (dir.magnitude > 32)  // Nếu có dấu hiệu di chuyển thì lấy hướng = Vector add
            {
                if(aDir.x>aDir.y)  // move x axis
                    add = new Point( (nDir.x>0) ? 1 : -1 , 0);
                else if(aDir.y > aDir.x)  // move y axis
                    add = new Point(0, (nDir.y > 0) ? -1 : 1);
            }

            newIndex.add(add);

            Vector2 pos = game.getPostionFromPoint(moving.index);

            if (!newIndex.Equal(moving.index))
                pos += Point.mult(add, 16).ToVector(); // Object sẽ đc kéo theo hướng của chuột
            moving.MovePositionTo(pos);
        }
    }

    public void MovePiece(NodePiece piece)
    {
        if (moving != null)
            return;

        moving = piece;
        mouseStart = Input.mousePosition;
    }

    public void Droppiece()
    {
        if (moving == null)
            return;

        if (!newIndex.Equal(moving.index))
        {
            game.FlipPieces(moving.index, newIndex,true);
        }
        game.ResetPiece(moving);
        moving = null;
    }
}


