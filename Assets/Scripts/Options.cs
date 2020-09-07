using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // Start is called before the first frame update
    DataPlayer data;
    void Start()
    {
        data = SaveLoadManager.LoadData();
        Slider music = gameObject.transform.GetChild(0).gameObject.GetComponent<Slider>();
        Slider sound = gameObject.transform.GetChild(1).gameObject.GetComponent<Slider>();
        if (data!=null)
        {
            music.value = data.volMusic;
            sound.value = data.volSound;
        }

        

        
    }

}
