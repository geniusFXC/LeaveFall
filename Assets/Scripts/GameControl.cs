using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
    public static GameControl instance;
    public float scrollSpeed = -1.5f;

    public GameObject gameOverUI;
    public GameObject backBtn;
    public bool isGameOver = false;
    public GameObject bG;
    public GameObject leave;
    public Text meterText;


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
        if (isGameOver)
        {
            gameOverUI.SetActive(true);
            //gameOverText.text = "GG";
            //把背景滚动停止
            foreach(Rigidbody2D rig in bG.GetComponentsInChildren<Rigidbody2D>())
            {
                rig.velocity = Vector2.zero;
            }
            //障碍停止运动
            foreach (GameObject barriers in ObjectPool.instance.barriersPool)
            {
                barriers.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            //停止随机生成障碍
            ObjectPool.instance.isSpawn = false;
            //锁定物体
            leave.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        else
        {
            meters += Time.deltaTime;
            meterText.text = "飘落距离：" + meters.ToString("0.00") + "m";
        }

        
	}
    void OnBackClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
