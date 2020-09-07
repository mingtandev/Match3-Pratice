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
    public static int Level=1;
    public static int chooseLevel;

    public static DataPlayer data;
    private void Awake()
    {

        data = SaveLoadManager.LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        if(data!=null)
        {
            Level = data.Lv;
            star = data.star;
            if(data.Lv==0)
                Level=1;
        }

        


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
        // if(data==null)
        //     Debug.Log("test");
        
        if (level > Level )
            return;

        chooseLevel = level;
        SceneManager.LoadScene(1);  
    }
}

[System.Serializable]
public class DataPlayer
{
    public int Lv;
    public int[] star;
    public float volMusic = 1;
    public float volSound = 1;

    public DataPlayer(int l , int[] st , float sound , float music)
    {
        star = new int[20];
        Lv = l;
        this.star = st;

        volMusic = music;
        volSound = sound;
    }
    public DataPlayer(DataPlayer b)
    {
        this.star = new int[20];
        this.Lv = b.Lv;
        this.star = b.star;
        this.volMusic = b.volMusic;
        this.volSound = b.volSound;
    }
}
