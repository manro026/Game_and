using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sta : MonoBehaviour
{
    public Text text_score;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score_save");
        text_score.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
