using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class NodePiece : MonoBehaviour
{

    public int value;
    public Point index;


    [HideInInspector]
    public Vector2 pos;
    [HideInInspector]
    public RectTransform rect;

    Image img;
    public void Initialize(int v , Point p , Sprite sp)
    {
        img = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        value = v;
        index = p;
        img.sprite = sp;
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
        transform.name = "Node[" + index.x + "][" + index.y + "]";
    }
}
