using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBg : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float bgVerticalLength;
    private Rigidbody2D rig;

    //public float scrollSpeed = -1.5f;
    private void Awake()
    {
        
        groundCollider = GetComponent<BoxCollider2D>();
        rig = GetComponent<Rigidbody2D>();
        bgVerticalLength = groundCollider.size.y;
    }
    // Use this for initialization
    void Start () {
        rig.velocity = new Vector2(0 ,GameControl.instance.scrollSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > bgVerticalLength)
        {
            RepositionBG();
        }

    }
    void RepositionBG()
    {
        //Vector2 offSet = new Vector2(0,bgVerticalLength *2f);
        //transform.position = (Vector2) transform.position + offSet;

        transform.position -= new Vector3(0, bgVerticalLength * 2f);
    }
}
