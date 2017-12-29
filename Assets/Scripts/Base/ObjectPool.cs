using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject prefab;
    public float spawnRate = 0.5f;//生成物体的时间间隔 
    public int objectPoolSize = 10;
    public float spawnYPosition = -8;
    public float xMax = 7;
    public float xMin = -7;
    public bool isSpawn = true;//是否重新生成

    private GameObject[] objcetPool;
    private float timeSinceLastSpawn = 0;
    private Vector2 objectPoolPosition = new Vector2(-10, 0);
    private int currentObject = 0;

    public GameObject[] getPool
    {
        get { return objcetPool; }
        private set { }
    }

    // Use this for initialization
    public virtual void Start()
    {

        objcetPool = new GameObject[objectPoolSize];
        for (int i = 0; i < objcetPool.Length; i++)
        {
            objcetPool[i] = Instantiate(prefab, objectPoolPosition, Quaternion.identity);
            objcetPool[i].transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        ResetObjectPosition();


    }
    /// <summary>
    /// 重新生成对象的位置
    /// </summary>
    void ResetObjectPosition()
    {
        if (isSpawn)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn > spawnRate)
            {
                timeSinceLastSpawn = 0;
                float spawnXPosition = Random.Range(xMin, xMax);
                objcetPool[currentObject].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                currentObject++;
                if (currentObject >= objectPoolSize)
                {
                    currentObject = 0;
                }
            }
        }
    }

}
