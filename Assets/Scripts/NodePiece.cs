using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;
using System;

public class NodePiece : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{

    public int value;
    public Point index;


    [HideInInspector]
    public Vector2 pos;
    [HideInInspector]
    public RectTransform rect;   // real position

    Image img;

    bool updating;    //When click , object will movement of back
    public void Initialize(int v , Point p , Sprite sp)
    {

        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        value = v;
        index = p;
        img.sprite = sp;

        UpdateName();
    }

    public void MovePosition(Vector2 move)
    {
        rect.anchoredPosition += move * Time.deltaTime * 16;
    }

    public void MovePositionTo(Vector2 move)
    {
        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, move, Time.deltaTime * 6f);
    }

    public void ResetPosition()
    {
        pos = new Vector2(Match3.widthObj/2 + (Match3.widthObj * index.x), -Match3.heighObj/2- (Match3.heighObj* index.y));
    }

    public void SetIndex(Point p)
    {
        index = p;
        ResetPosition();
        UpdateName();
    }


    void UpdateName()
    {
        transform.name = "Node[" + index.x + "][" + index.y + "] - " + value;
    }

    public bool UpdatePiece()
    {
        if (Vector3.Distance(rect.anchoredPosition, pos) > 1)
        {
            MovePositionTo(pos);
            updating = true;
            return true;
        }
        else
        {
            rect.anchoredPosition = pos;
            updating = false;
            return false;
        }
        // return false if it's not moving
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (updating) return;

        if(value<=5 && value>=0)
            gameObject.GetComponent<Image>().sprite = FindObjectOfType<Match3>().piecesWakeUp[value - 1];
        MovingPiece.instance.MovePiece(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MovingPiece.instance.Droppiece();

    }
}
