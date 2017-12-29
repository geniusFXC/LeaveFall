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
    public GameObject leave;

    public Text meterText;
    public Text goldText;

    private float meters = 0;

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
    }
    // Use this for initialization
    void Start () {
        backBtn.GetComponent<Button>().onClick.AddListener(OnBackClick);
	}
	
	// Update is called once per frame
	void Update () {
        GameOver();
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
        //背景静止
        foreach (Rigidbody2D rig in bG.GetComponentsInChildren<Rigidbody2D>())
        {
            rig.velocity = Vector2.zero;
        }
        //对象池静止
        PoolManager.instance.GameStop();
        //锁定叶子
        leave.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }
    void GameStart()
    {

    }
    void OnBackClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
