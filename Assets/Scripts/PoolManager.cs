using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    public static PoolManager instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    public GoldPool goldPool;
    public BarrierPool barrierPool;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameStop()
    {
        StopObject(barrierPool);
        StopObject(goldPool);
    }
    void StopObject(ObjectPool objPool)
    {
        //障碍停止运动
        foreach (GameObject barriers in objPool.getPool)
        {
            barriers.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        //停止随机生成各种对象
        objPool.isSpawn = false;
    }
}
