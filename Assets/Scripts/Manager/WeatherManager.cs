using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Weather
{
    SunShine,
    Rain,
    Snow,
    Windy,
    SandStrom
}
public class WeatherManager : MonoBehaviour {
    //外部修改参数
    public float weatherChangeTimeInterval = 60;

    //引用
    public ParticleSystem rainFallParticle;
    public ParticleSystem rainMistParticle;
    public ParticleSystem snowParticle;
    public ParticleSystem dustStromParticle;
    public ParticleSystem windyParticle;

    private float timer = 0;
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

    public Vector2 windForce = new Vector2(0,0);
    public float delayMoveTime = 0f;
    // Use this for initialization
    void Start () {
        Rain();
	}
	
	// Update is called once per frame
	void Update () {

        //RandomWeather();
    }
    void RandomWeather()
    {
        timer += Time.deltaTime;
        //Debug.Log((int)Time.time % weatherChangeTimeInterval);
        if (timer >= weatherChangeTimeInterval)
        {
            timer = 0;
            Debug.Log("改变天气");
            StopAllParticle();
            switch ((Weather)Random.Range(0, 5))
            {
                case Weather.SunShine:
                    SunShine();
                    break;
                case Weather.Rain:
                    Rain();
                    break;
                case Weather.Snow:
                    Snow();
                    break;
                case Weather.Windy:
                    Windy();
                    break;
                case Weather.SandStrom:
                    DustStrom();
                    break;
            }
            
        }
        
    }
    /// <summary>
    /// 停止所有天气粒子特效
    /// </summary>
    void StopAllParticle()
    {
        rainFallParticle.Stop();
        rainFallParticle.transform.Rotate(Vector3.zero);

        rainMistParticle.Stop();
        snowParticle.Stop();
        dustStromParticle.Stop();
        //windyParticle.Stop();
    }
    void RandomWind()
    {
        windForce = new Vector2(Random.Range(0, 3), Random.Range(0, 3));
        //Debug.Log("randomWind" + windForce);
    }
    /// <summary>
    /// 雨天 会有风 会下雨 影响视野 背景变暗 有闪电特效
    /// </summary>
    void Rain()
    {
        RandomWind();
        LeafManager.instance.delayMoveTime = delayMoveTime;
        LeafManager.instance.windForce = windForce;
        
        rainFallParticle.Play();
        rainMistParticle.Play();
        //改变雨滴下落的方向
        rainFallParticle.transform.Rotate(new Vector3(0,0,windForce.x));
    }
    /// <summary>
    /// 下雪天 暂定没有风 会影响操作延迟 会有雪人出现在障碍物上 可以收集
    /// </summary>
    void Snow()
    {
        snowParticle.Play();
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
    void DustStrom()
    {
        dustStromParticle.Play();
    }
    /// <summary>
    /// 大风天气 操控难度会很高
    /// </summary>
    void Windy()
    {

    }
    
}
