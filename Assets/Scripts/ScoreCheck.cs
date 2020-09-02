using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCheck : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite starOn;
    // Update is called once per frame
    public int requireScore;
    public int curScore;
    public int curStar;

    Match3 game;
    Score gScore;

    GameObject progress;
    GameObject value;
    GameObject star1;
    GameObject star2;
    GameObject star3;



    //Popup manager

    private void Awake()
    {
        curStar = 0;
        game = GameObject.FindObjectOfType<Match3>();
        gScore = GameObject.FindObjectOfType<Score>();
        progress = gameObject.transform.GetChild(2).gameObject;
        value = progress.transform.GetChild(0).gameObject;
        star1 = progress.transform.GetChild(1).gameObject;
        star2 = progress.transform.GetChild(2).gameObject;
        star3 = progress.transform.GetChild(3).gameObject;



    }
    private void Start()
    {
        requireScore = game.requireScore;
    }
    void Update()
    {


        float ratio  = (float)gScore.score / requireScore;
        if (ratio > 1)
            ratio = 1;
        value.transform.localScale = new Vector2(ratio, 1);

        if (ratio == 1)
        {
            star3.GetComponent<Image>().sprite = starOn;
            curStar = 3;
        }
        else if (ratio >= 0.7f)
        {
            star2.GetComponent<Image>().sprite = starOn;
            curStar = 2;
        }
        else if (ratio >= 0.2f)
        {

            star1.GetComponent<Image>().sprite = starOn;
            curStar = 1;
        }

        if(curStar>= game.star)
            game.star = curStar;



    }
}
