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
    void Rain()
    {
        LeafManager.instance.leaf.delayMoveTime = delayMoveTime;
        LeafManager.instance.leaf.windForce = windForce;
    }
    
}
