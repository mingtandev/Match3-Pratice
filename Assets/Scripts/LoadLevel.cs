using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{


    Match3 game;
    public Sprite[] unlock;
    private static LoadLevel instance;

    public static int[] star = new int[20];
    public static int Level;
    public static int chooseLevel;

    // Start is called before the first frame update
    //private void Awake()
    //{

    //    if (instance == null)
    //    {
    //        Debug.Log("Awake");
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //        Level = 1;
    //        star = new int[20];
    //        star[0] = 0;
    //        game = FindObjectOfType<Match3>();
    //    }
    //    else if (instance != this)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }
    //}
    void Start()
    {
            
            //for (int i = 0; i < Level; i++)
            //{
            //    gameObject.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite = unlock[start[i]];
            //    Text t = gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            //    t.text = (i + 1).ToString();
            //    t.color = Color.white;
            //    t.fontSize = 36;
            //}

    }

    // Update is called once per frame
    void Update()
    {



        if (Level < chooseLevel)
            Level = chooseLevel;


        for (int i = 0; i < Level; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite = unlock[star[i]];
            Text t = gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            t.text = (i + 1).ToString();
            t.color = Color.white;
            t.fontSize = 36;
        }
    }

    public void LoadToLevel(int level)
    {
        chooseLevel = level;
        SceneManager.LoadScene(1);  
    }
}
