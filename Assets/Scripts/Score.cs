using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static Score instance;

    public int score = 0;
    TextMeshProUGUI scoreText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
