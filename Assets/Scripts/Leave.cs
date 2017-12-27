using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Leave : MonoBehaviour {

    public float moveTimeMultiple = 5;

    private float moveTime;
    private Vector3 initPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector2 mousePositionOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        #region 触摸事件
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            
              //transform.Translate(Input.GetTouch(0).deltaPosition * Time.deltaTime);
            
            
        }
        #endregion
        if (Input.GetMouseButton(0))
        {
            //if (mousePositionOnScreen.x * Time.deltaTime * leaveSpeed > -9.9&& mousePositionOnScreen.x * Time.deltaTime * leaveSpeed <9.9)
            //{
            //    transform.Translate(mousePositionOnScreen * Time.deltaTime * leaveSpeed);
            //}     
            moveTime += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            initPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {

            Move(Camera.main.ScreenToWorldPoint(Input.mousePosition) - initPosition, moveTime);
            moveTime = 0;
        }

        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    void Move(Vector3 offSet, float time)
    {

        transform.DOMove(transform.position + offSet, time * moveTimeMultiple).SetEase(Ease.InOutQuad);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

    }
}
