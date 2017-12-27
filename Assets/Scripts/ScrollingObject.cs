using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {
    private Rigidbody2D rig;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(0, GameControl.instance.scrollSpeed);
    }
	
	// Update is called once per frame
	void Update () {
		
       
	}
}
