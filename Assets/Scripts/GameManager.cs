using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    //public static GameManager _instance;
    public Text userScore;
    public int birdScore;
    public int curLevel;
    private SceneTrans sceneTrans;

    private DataSaver data;
   // public GameObject LevelChoicePanel;

    private int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        data = GameObject.FindWithTag("data").GetComponent<DataSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnd();

    }

    void CheckEnd()
    {
        if (GameObject.FindGameObjectsWithTag("pig").Length == 0)
        {
            Invoke("UserWin", 2.0f);
            return;
        }

        if (GameObject.FindGameObjectsWithTag("bird").Length == 0)
        {
            UserLose();return;
        }
        //Debug.Log(GameObject.FindGameObjectsWithTag("bird")[0].transform.position);

    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

     public void goBack()
     {
        SceneManager.LoadScene("Menu");
     }

   public void addScore(int add)
    {
        totalScore += add;
        userScore.text = totalScore.ToString("000");

    }

    void UserWin()
    {
       addScore(GameObject.FindGameObjectsWithTag("bird").Length*birdScore);
       data.score = totalScore;
       data.isWin = true;
       SceneManager.LoadScene("End");
    }

    void UserLose()
    {
        data.score = totalScore;
        data.isWin = false;
        SceneManager.LoadScene("End");
    }
}