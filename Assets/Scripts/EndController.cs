using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndController : MonoBehaviour
{
    private DataSaver data;
    public Text userScore;
    public Text TitleText;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindWithTag("data").GetComponent<DataSaver>();
        userScore.text = data.score.ToString("000");
        if (data.isWin)
        {
            TitleText.text = "You Win!";
            GameObject.Find("next").SetActive(true);
            GameObject.Find("retry").SetActive(false);

        }
        else
        {
            TitleText.text = "You Lose";
            GameObject.Find("band").SetActive(false);
            GameObject.Find("next").SetActive(false);
            GameObject.Find("retry").SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
