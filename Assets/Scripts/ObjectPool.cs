using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    //引用
    public GameObject barrierPfb;
    //
    [Header("生成速率")]
    public float spawnRate = 0.5f;
    public int objectPoolSize = 10;
    public float spawnYPosition = -8;
    public float xMax = 7;
    public float xMin = -7;
    public bool isSpawn = true;//是否产生新的位置

    private GameObject[] barriers;
    private float timeSinceLastSpawn = 0;
    private Vector2 barrierPoolPosition = new Vector2(-10,0);
    private int currentBarrier = 0;

    public GameObject[] barriersPool
    {
        get { return barriers; }
        private set { }
    }

    
    public static ObjectPool instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
        barriers = new GameObject[objectPoolSize];
        for (int i = 0;i< barriers.Length;i++)
        {
            barriers[i] = Instantiate(barrierPfb, barrierPoolPosition, Quaternion.identity);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (isSpawn)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn > spawnRate)
            {
                timeSinceLastSpawn = 0;
                float spawnXPosition = Random.Range(xMin, xMax);
                barriers[currentBarrier].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                currentBarrier++;
                if (currentBarrier >= objectPoolSize)
                {
                    currentBarrier = 0;
                }
            }
        }

        
	}
    
}
