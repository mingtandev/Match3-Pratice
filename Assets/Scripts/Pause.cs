using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update

    Score gScore;
    Match3 game;
    void Start()
    {
        gScore = GameObject.FindObjectOfType<Score>();
        game = GameObject.FindObjectOfType<Match3>();
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Score " + Mathf.RoundToInt(game.requireScore * 0.2f).ToString() + " points";

    }

    // Update is called once per frame
    void Update()
    {
        if (gScore.score >= game.requireScore * 0.2f) 
             gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprites/checkTrue");
    }
 
}
