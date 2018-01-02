using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour {
    public static WeatherManager instance;
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

    public Vector2 windForce = new Vector2(1, 1);
    public float delayMoveTime = 0.2f;
    // Use this for initialization
    void Start () {
        Rain();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void RandomWeather()
    {

    }
    /// <summary>
    /// 雨天 会有风 会下雨 影响视野 背景变暗 有闪电特效
    /// </summary>
    void Rain()
    {
        LeafManager.instance.leaf.delayMoveTime = delayMoveTime;
        LeafManager.instance.leaf.windForce = windForce;
    }
    /// <summary>
    /// 下雪天 暂定没有风 会影响操作延迟 会有雪人出现在障碍物上 可以收集
    /// </summary>
    void Snow()
    {

    }
    /// <summary>
    /// 晴天 会有蝴蝶 可以去靠近 有低几率吸引蝴蝶 高几率吓跑
    /// </summary>
    void SunShine()
    {

    }
    /// <summary>
    /// 沙尘天气 有风 视野会变得很差
    /// </summary>
    void SandStrom()
    {

    }
    /// <summary>
    /// 大风天气 操控难度会很高
    /// </summary>
    void Windy()
    {

    }
    
}
