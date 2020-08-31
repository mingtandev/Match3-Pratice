using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Sprite[] unlock;


    public int[] start;
    public int Level = 3;

    int maxLevel = 4;
    // Start is called before the first frame update
    void Start()
    {
        if (Level < maxLevel)
        {
            for (int i = 0; i < Level; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = unlock[start[i]];

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
