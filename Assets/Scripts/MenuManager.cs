using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Button startGameBtn;
	// Use this for initialization
	void Start () {
        startGameBtn.GetComponent<Button>().onClick.AddListener(OnStartGameClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnStartGameClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
