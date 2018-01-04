using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCtrManager : MonoBehaviour {
    public static GameCtrManager instance;
    public float scrollSpeed = -1.5f;

    public GameObject gameOverUI;
    public GameObject backBtn;
    public bool isGameOver = false;
    public GameObject bG;
    public GameObject leaf;

    public Text meterText;
    public Text goldText;
    public Button stopBtn;
    public Text stopBtnText;

    private float meters = 0;
    private bool isStop = false;

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);

        //Debug.Log("awake"+Time.timeScale);
    }
    // Use this for initialization
    void Start () {
        
        //LeafManager.instance.leaf = Instantiate(LeafManager.instance.leaf);
        backBtn.GetComponent<Button>().onClick.AddListener(OnMenuSceneClick);
        stopBtn.GetComponent<Button>().onClick.AddListener(OnStopClick);
	}
	
	// Update is called once per frame
	void Update () {
        GameOver();
	}
    void LateUpdate()
    {
        isGameOver = false;
    }
    void GameOver()
    {
        if (isGameOver)
        {
            gameOverUI.SetActive(true);
            GameStop();

        }
        else
        {
            meters += Time.deltaTime;
            meterText.text = "飘落距离：" + meters.ToString("0.00") + "m";
        }
    }
    /// <summary>
    /// 游戏暂停
    /// </summary>
    void GameStop()
    {
        //Debug.Log("执行");
        Time.timeScale = 0;
    }
    void GameStart()
    {

    }
    void GameReStart()
    {

    }
    void OnMenuSceneClick()
    {
        Time.timeScale = 1;
        //Debug.Log(Time.timeScale);
        SceneManager.LoadScene("MenuScene");
    }
    void OnStopClick()
    {
        
        isStop = !isStop;
        if (isStop)
        {

            stopBtnText.text = "开始";
            Time.timeScale = 0;
        }
        else
        {
            stopBtnText.text = "暂停";
            Time.timeScale = 1;
        }

    }
}
