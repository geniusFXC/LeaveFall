using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeafManager : MonoBehaviour {

    public static LeafManager instance;
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
    //引用
    private Text lifeText;
    private Text goldText;
    private GameObject leaf;
    public GameObject testLeaf;
    //外部参数
    public float moveTimeMultiple = 7;
    public float delayMoveTime = 0;
    //内部参数
    private float moveTime;
    private Vector3 initPosition;
    private Rigidbody2D rig;
    public Vector2 windForce = new Vector2(0, 0);

    
    // Use this for initialization
    void Start () {
        
        if (GameFacade.instance == null)
        {
            leaf = testLeaf;
        }
        else
        {
            leaf = GameFacade.instance.leaf;
        }
        leaf = Instantiate(leaf);

        rig = leaf.GetComponent<Rigidbody2D>();
        
        lifeText = GameObject.Find("Canvas/LifeText").GetComponent<Text>();
        goldText = GameObject.Find("Canvas/GoldText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        Touch();
        
    }
    /// <summary>
    /// 操控叶子的事件触发方式
    /// </summary>
    void Touch()
    {
        if (Input.GetMouseButton(0))
        {
            moveTime += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            initPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(Move(Camera.main.ScreenToWorldPoint(Input.mousePosition) - initPosition, moveTime));
            moveTime = 0;
        }
    }
    IEnumerator Move(Vector3 offSet, float time)
    {
        //Debug.Log(time);
        if (time == 0)
        {
            yield break;
        }
        //transform.DOMove(transform.position + offSet, time * moveTimeMultiple).SetEase(Ease.InOutQuad);
        rig.velocity = offSet / time / moveTimeMultiple;

        //rig.DOMove(transform.position + offSet, time * moveTimeMultiple).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(delayMoveTime);
    }

    public void HealthLoss(int health)
    {        
        lifeText.text = "生命值：" + health.ToString();
        if (health <= 0)
        {
            rig.velocity = Vector2.zero;
            GameCtrManager.instance.isGameOver = true;
        }
    }
    public void CollectionGold(int goldNum,GameObject gold)
    {
        gold.transform.position = new Vector2(0, PoolManager.instance.goldPool.spawnYPosition);
        //Debug.Log(goldPosition);        
        goldText.text = "获得金币：" + goldNum;
    }

    public GameObject GetCurrentLeaf()
    {
        return leaf;
    }
}
