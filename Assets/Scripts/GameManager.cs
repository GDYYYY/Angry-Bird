using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Text userScore;

    public GameObject levelChoicePanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

    public void ChangeScene(int id)
    {
        //Debug.Log("ss"+id);
        if (id > 0)
            SceneManager.LoadScene("Game" + id);
        else SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        
        instance.levelChoicePanel.SetActive(true);
        //ChangeScene(1);
    }
}