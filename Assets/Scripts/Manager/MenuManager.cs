using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Button startGameBtn;
    public Button choseLeafBtn;
    public Image leavesChoseBg;

    //选择叶子
    public Button redLeafBtn;
    public Button yellowLeafBtn;
    public Button greenLeafBtn;

    public GameObject redLeaf;
    public GameObject yellwLeaf;
    public GameObject greenLeaf;

    
    

    public static MenuManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


    }
    // Use this for initialization
    void Start () {
        if (LeafManager.instance.leaf == null)
        {
            LeafManager.instance.leaf = redLeaf;
        }
        

        startGameBtn.GetComponent<Button>().onClick.AddListener(OnStartGameClick);
        choseLeafBtn.GetComponent<Button>().onClick.AddListener(OnChoseBtnClick);

        redLeafBtn.GetComponent<Button>().onClick.AddListener(OnRedLeafClick);
        yellowLeafBtn.GetComponent<Button>().onClick.AddListener(OnYellowLeafClick);
        greenLeafBtn.GetComponent<Button>().onClick.AddListener(OnGreenLeafClick);
        //Time.timeScale = 1;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnStartGameClick()
    {
        SceneManager.LoadScene("GameScene");
    }
    void OnChoseBtnClick()
    {
        leavesChoseBg.gameObject.SetActive(true);
    }

    void OnRedLeafClick()
    {
        leavesChoseBg.gameObject.SetActive(false);
        LeafManager.instance.leaf = redLeaf;
    }
    void OnYellowLeafClick()
    {
        leavesChoseBg.gameObject.SetActive(false);
        LeafManager.instance.leaf = yellwLeaf;
    }
    void OnGreenLeafClick()
    {
        leavesChoseBg.gameObject.SetActive(false);
        LeafManager.instance.leaf = greenLeaf;
    }
}
