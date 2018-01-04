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
        
    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 mousePositionOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        
        //rig.AddForce(windForce);
        //Debug.Log(windForce);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
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
            goldValue++;
            LeafManager.instance.CollectionGold(goldValue,other.gameObject);
        }
    }
}
