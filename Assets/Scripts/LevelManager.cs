using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    public Match3 game;
    
    //END GAME POPUP
    public Sprite starOn;
    public GameObject popupNexetLevel;
    public GameObject shadow;
    public GameObject starManager;
    public GameObject scoreObj;

    public static LevelManager instance;

    public int currenLevel;

    private void Awake()
    {
        instance = this;
        game = gameObject.GetComponent<Match3>();
    }
    public void Level_1()
    {
        int requireScore = 1000;
        int movement = 20;

        game.requireScore = requireScore;
        game.movement = movement;

        game.map = new bool[14, 9]{
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
        };


    }

    public void Level_2()
    {
        int requireScore = 1500;
        int movement = 20;

        game.requireScore = requireScore;
        game.movement = movement;

        game.map = new bool[14, 9]{
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,true,true,false,false,false,true,true,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,true,true,true,false,false,false},
            {false,false,false,true,true,true,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
        };

    }


    public void Level_3()
    {
        int requireScore = 1500;
        int movement = 20;

        game.requireScore = requireScore;
        game.movement = movement;

        game.map = new bool[14, 9]{
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,true,true,false,false,false,true,true,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,true,true,true,false,false,false},
            {false,false,false,true,true,true,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,true,true,true,true,true,false,false},
            {true,true,true,true,true,true,true,true,true},
            {true,true,true,true,true,true,true,true,true},
        };

    }

    public void Level_4()
    {
        int requireScore = 2000;
        int movement = 20;

        game.requireScore = requireScore;
        game.movement = movement;

        game.map = new bool[14, 9]{
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,true,true,false,false,false,true,true,true},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,true,true,true,false,false,false},
            {false,false,false,true,true,true,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
        };

    }


    public void Level_5()
    {
        int requireScore = 2200;
        int movement = 20;

        game.requireScore = requireScore;
        game.movement = movement;

        game.map = new bool[14, 9]{
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,true,true,false,false,false,true,true,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,true,true,true,false,false,false},
            {false,false,false,true,true,true,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,true,false,false,false,false},
            {false,false,true,true,true,true,true,false,false},
            {false,false,true,true,true,true,true,false,false},
            {true,true,true,true,true,true,true,true,true},
            {true,true,true,true,true,true,true,true,true},
        };

    }
    public void Level_6()
    {
        int requireScore = 3000;
        int movement = 25;

        game.requireScore = requireScore;
        game.movement = movement;

        game.map = new bool[14, 9]{
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
        };
    }

    public void Level_7()
    {
        int requireScore = 3000;
        int movement = 25;

        game.requireScore = requireScore;
        game.movement = movement;

        game.map = new bool[14, 9]{
            {true,false,false,false,true,false,false,true,true},
            {false,true,false,false,false,false,true,false,false},
            {false,false,true,false,false,true,false,false,false},
            {false,false,false,true,true,false,false,false,false},
            {false,false,false,true,true,false,false,false,false},
            {true,true,true,true,true,true,true,true,true},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false},
            {true,true,true,true,true,true,true,true,true},
        };
    }

    public void Level_8()
    {
        int requireScore = 3000;
        int movement = 25;

        game.requireScore = requireScore;
        game.movement = movement;

        game.map = new bool[14, 9]{
            {true,true,true,true,true,true,true,true,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,true},
            {true,true,true,true,true,true,true,true,true},
        };
    }

    public void LevelLoad(int level)
    {
        switch (level)
        {
            case 1: Level_1(); break;
            case 2: Level_2(); break;
            case 3: Level_3(); break;
            case 4: Level_4(); break;
            case 5: Level_5(); break;
            case 6: Level_6(); break;
            case 7: Level_7(); break;
            case 8: Level_8(); break;
            default: Level_8(); break;
        }
    }

    public void Level_Complete(int start , int score)
    {
        popupNexetLevel.SetActive(true);
        shadow.SetActive(true);
        for (int i = 0; i < start; i++)
        {
            starManager.transform.GetChild(i).gameObject.GetComponent<Image>().sprite = starOn;
        }

        scoreObj.GetComponent<TextMeshProUGUI>().text = "Score : " + score.ToString();

    }

}
