using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{
    public Sprite[] unlock;


    public int[] start;
    public int Level;
    public static int chooseLevel;

    // Start is called before the first frame update
    void Start()
    {
        
            for (int i = 0; i < Level; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite = unlock[start[i]];
                Text t = gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                t.text = (i + 1).ToString();
                t.color = Color.white;
                t.fontSize = 36;
            }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadToLevel(int level)
    {
        chooseLevel = level;
        SceneManager.LoadScene(1);  
    }
}
