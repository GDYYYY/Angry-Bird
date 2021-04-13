using System;
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
    private int maxScore;
    private DataSaver data;
   // public GameObject LevelChoicePanel;

    private int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        maxScore = 0;
        data = GameObject.FindWithTag("data").GetComponent<DataSaver>();
        GameObject[] woods = GameObject.FindGameObjectsWithTag("wood");//.GetComponent<BreakController>().maxScore;
        int l = woods.Length;
        for (int i = 0; i < l; i++)
        {
            maxScore += woods[i].GetComponent<BreakController>().maxScore;
        }
        maxScore += (GameObject.FindGameObjectsWithTag("pig").Length) * GameObject.FindWithTag("pig").GetComponent<BreakController>().maxScore;
        maxScore += (GameObject.FindGameObjectsWithTag("bird").Length - 1) * birdScore;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckEnd();

    }

   public void CheckEnd()
    {
        Debug.Log("aaaaaaa");
        if (GameObject.FindGameObjectsWithTag("pig").Length == 0)
        {
            //Invoke("UserWin", 2.0f);
            UserWin();
            return;
        }
        Debug.Log(GameObject.FindWithTag("bird").transform.position);
        if (GameObject.FindGameObjectsWithTag("bird").Length <= 1)
        {
            Debug.Log("sssaaa");
            UserLose();return;
        }
        //Debug.Log(GameObject.FindGameObjectsWithTag("bird")[0].transform.position);

    }

    public void checkWin()
    {
        if (GameObject.FindGameObjectsWithTag("pig").Length == 0)
        {
            UserWin();
        }
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
        Debug.Log("add"+add);
        totalScore += add;
        userScore.text = totalScore.ToString("000");

    }

    void UserWin()
    {
       addScore((GameObject.FindGameObjectsWithTag("bird").Length-1)*birdScore);
       data.score = totalScore;
       data.isWin = true;
       data.rank = (int)Math.Ceiling((double)totalScore * 3 / maxScore);
       Debug.Log("max"+maxScore);
        SceneManager.LoadScene("End");
    }

    void UserLose()
    {
        data.score = totalScore;
        data.isWin = false;
        SceneManager.LoadScene("End");
    }

   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}