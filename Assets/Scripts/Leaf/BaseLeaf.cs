using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BaseLeaf : MonoBehaviour {
    //属性
    public int healthPoint = 0;//生命值
    public float fragrancePoint = 0;//香气值 0-1
    public float brightness = 0;//亮度 0-1
    public float mass = 0;//重量
    public float linerDarg = 0;//阻力
    public float immunity = 0;//对雪天冰冻延迟的免疫力0-1
    
    
    public int lifeValue = 3;
    
    

    
    
    
   
    private int goldValue = 0;
    
	// Use this for initialization
	void Start () {
        //transform.DORotate(new Vector3(0, 180, 0), 2).SetLoops(-1).SetEase(Ease.Linear);

        
    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 mousePositionOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        //rig.AddForce(windForce);
        //Debug.Log(windForce);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        transform.RotateAround(Vector3.zero, Vector3.up,60 *Time.deltaTime);
        //transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
    }
    

    void OnCollisionEnter2D(Collision2D other)
    {
        lifeValue--;
        LeafManager.instance.HealthLoss(lifeValue);
        //Debug.Log("发生碰撞");
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Gold")
        {
            
            //Debug.Log("叶子碰金币"+goldValue);
            LeafManager.instance.CollectionGold(other.gameObject);
        }
        if(other.tag == "Butterfly")
        {
            Debug.Log("靠近蝴蝶");
            LeafManager.instance.CloseToButterfly(other.gameObject);
            //other.gameObject.GetComponent<Butterfly>().FollowLeaf();
        }
    }
}
