using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Butterfly : MonoBehaviour {

    public int followProbability;
    public float followTime;
    public Vector3 flyOutPositon;
    public Vector3 flyInPositon;
    public float flyTime;
    private float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ButterflyAppear();
    }
    private bool isFollow = false;

    void LateUpdate()
    {
        if (isFollow)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, LeafManager.instance.GetCurrentLeaf().transform.position, Time.deltaTime);
            if(timer > followTime)
            {
                Debug.Log("时间到了要飞走了");
                timer = 0;
                isFollow = false;
                flyAway();
            }
        }

    }
    public void FollowLeaf()
    {
        if(Random.Range(0, 100) <= followProbability)
        {
            Debug.Log("跟随叶子");
            isFollow = true;
        }
        else
        {
            flyAway();
        }
        
    }
    private void flyAway()
    {
        //飞走
        Debug.Log("飞走了");
        
        transform.DOMove(flyOutPositon,flyTime);
    }

    void ButterflyAppear()
    {
        if(transform.position == flyOutPositon)
        {
            if(Random.Range(0,100) < 50)
            {
                Debug.Log("蝴蝶出现");  
                transform.DOMove(flyInPositon, flyTime);
            }
            
        }
    }
    public bool IsFollow()
    {
        return isFollow;
    }
    
}
