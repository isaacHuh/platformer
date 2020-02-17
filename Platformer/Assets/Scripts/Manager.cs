using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    int score = 0;
    int coins = 0;

    float currentTime = 0f;
    float startingTime = 300f;

    public Text timeText;
    public Text coinText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        string timeTxt = "Time: " + (int)currentTime;
        timeText.text = timeTxt;

        string coinTxt = "Coin: " + coins;
        coinText.text = coinTxt;

        string scoreTxt = "Score: " + score;
        scoreText.text = scoreTxt;
    }

    public void increaseCoins() {
        coins++;
    }
}
