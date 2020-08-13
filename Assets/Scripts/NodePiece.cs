using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NodePiece : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
{

    public int value;
    public Point index;


    [HideInInspector]
    public Vector2 pos;
    [HideInInspector]
    public NodePiece flipped;
    [HideInInspector]
    public RectTransform rect;

    Image img;

    bool updating;
    public void Initialize(int v , Point p , Sprite sp)
    {

        flipped = null;
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
        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, move, Time.deltaTime * 16f);
    }

    public void ResetPosition()
    {
        pos = new Vector2(32 + (64 * index.x), -32 - (64 * index.y));
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
        MovingPiece.instance.MovePiece(this);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MovingPiece.instance.Droppiece();

    }
}
