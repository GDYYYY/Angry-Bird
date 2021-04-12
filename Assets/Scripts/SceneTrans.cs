using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTrans : MonoBehaviour
{
    private static SceneTrans instance;
    public GameObject LevelChoicePanel;
    //public GameObject dataSave;
    private static DataSaver data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindWithTag("data").GetComponent<DataSaver>();
        //if (!data)
            //data = Instantiate(dataSave, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<DataSaver>();
        //data = GameObject.FindWithTag("data").GetComponent<DataSaver>();
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
            SceneManager.LoadScene("Game" + id, LoadSceneMode.Single);
        else
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void StartGame()
    {

        instance.LevelChoicePanel.SetActive(true);
        //ChangeScene(1);
    }
    
    public void NextGame()
    {
        data.curLevel++;
        SceneManager.LoadScene("Game" + data.curLevel, LoadSceneMode.Single);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("Game" + data.curLevel, LoadSceneMode.Single);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
