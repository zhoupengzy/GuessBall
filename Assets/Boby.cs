using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boby : MonoBehaviour {

    // 球
    public Transform Ball;

    // 杯子
    public Transform Cup;

    // 坐标
    public Vector3 orgPos;

    private bool isShowBall;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenCup()
    {
        Ball.gameObject.SetActive(isShowBall);

        Sequence tween = DOTween.Sequence();
        // 打开杯子
        tween.Append(Cup.DOLocalMoveY(3, 2));

    }

    public void Reset()
    {
        Ball.gameObject.SetActive(true);
        this.transform.localPosition = orgPos;
        //Cup.localPosition = orgPos;
    }
}
