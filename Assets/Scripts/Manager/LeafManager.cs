﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafManager : MonoBehaviour {
    public static LeafManager instance;
    public BaseLeaf leaf;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
        if (GameFacade.instance == null)
        {
            return;
        }
        else
        {
            leaf = GameFacade.instance.leaf;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
