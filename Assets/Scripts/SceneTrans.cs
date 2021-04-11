using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTrans : MonoBehaviour
{
    private static SceneTrans instance;
    public GameObject LevelChoicePanel;

    private DataSaver data;
    // Start is called before the first frame update
    void Start()
    {
       data = GameObject.FindWithTag("data").GetComponent<DataSaver>();
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
        data.curLevel = id;
        if (id > 0)
            SceneManager.LoadScene("Game" + id);
        else
            SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {

        instance.LevelChoicePanel.SetActive(true);
        //ChangeScene(1);
    }
    
    public void NextGame()
    {
        data.curLevel++;
        SceneManager.LoadScene("Game" + data.curLevel);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("Game" + data.curLevel);
    }
}
