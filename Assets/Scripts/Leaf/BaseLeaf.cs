using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BaseLeaf : MonoBehaviour {

    
    public float moveTimeMultiple = 7;
    public int lifeValue = 3;
    public float delayMoveTime = 0;
    public Vector2 windForce = new Vector2(0,0);

    private Text lifeText;
    private Text goldText;
    private Rigidbody2D rig;
    private float moveTime;
    private Vector3 initPosition;
    private int goldValue = 0;
    
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        lifeText = GameObject.Find("Canvas/LifeText").GetComponent<Text>();
        goldText = GameObject.Find("Canvas/GoldText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 mousePositionOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        #region 触摸事件
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            
              //transform.Translate(Input.GetTouch(0).deltaPosition * Time.deltaTime);
            
            
        }
        #endregion
        if (Input.GetMouseButton(0))
        {
            //if (mousePositionOnScreen.x * Time.deltaTime * leaveSpeed > -9.9&& mousePositionOnScreen.x * Time.deltaTime * leaveSpeed <9.9)
            //{
            //    transform.Translate(mousePositionOnScreen * Time.deltaTime * leaveSpeed);
            //}     
            moveTime += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            initPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {

            StartCoroutine(Move(Camera.main.ScreenToWorldPoint(Input.mousePosition) - initPosition, moveTime));
            //Move(Camera.main.ScreenToWorldPoint(Input.mousePosition) - initPosition, moveTime);
            moveTime = 0;
        }
        rig.AddForce(windForce);
        
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    IEnumerator Move(Vector3 offSet, float time)
    {
        //Debug.Log(time);
        if (time == 0)
        {
            yield break;
        }
        //transform.DOMove(transform.position + offSet, time * moveTimeMultiple).SetEase(Ease.InOutQuad);
        
        //rig.DOMove(transform.position + offSet, time * moveTimeMultiple).SetEase(Ease.InOutQuad);
        
        yield return new WaitForSeconds(delayMoveTime);
        rig.velocity = offSet / time / moveTimeMultiple;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        lifeValue--;
        lifeText.text = "生命值：" + lifeValue.ToString();
        if (lifeValue <= 0)
        {
            rig.velocity = Vector2.zero;
            GameCtrManager.instance.isGameOver = true;
        }
        //Debug.Log("发生碰撞");
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Gold")
        {
            other.transform.position = new Vector2(0, PoolManager.instance.goldPool.spawnYPosition);
            goldValue++;
            goldText.text = "获得金币：" + goldValue;
        }
    }
}
