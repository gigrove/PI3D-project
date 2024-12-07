using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private TMP_Text scoreText;

    private int _score = 0;
    public int Score
    { 
        get {return _score;}  
        set 
        {
            if (value < 0)
            {
                _score = 0;
            }
            else
            {
                _score = value;
            }
        } 
    
    }
    

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        _score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _score.ToString();   
    }
}
