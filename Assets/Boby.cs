using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boby : MonoBehaviour {

    // 球
    public Transform Ball;

    // 杯子
    public Transform Cup;

    // 坐标
    public Vector3 orgPos;

    public bool isShowBall;
    public bool isCanClick;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OpenCup()
    {
        if (isCanClick != true)
            return;

        Ball.gameObject.SetActive(isShowBall);

        // 打开杯子
        Sequence tween = DOTween.Sequence();
        tween.Append(Cup.DOLocalMoveY(2, 0.4f));

        if(isShowBall)
        {
            Debug.Log("你赢了");
        }
        else
        {
            Debug.Log("你输了");
        }

    }

    public void ShowBallAni()
    {
        isShowBall = true;
        Ball.gameObject.SetActive(true);
        Sequence tween = DOTween.Sequence();
        tween.Append(Cup.DOLocalMoveY(2, 0.4f));
        tween.AppendInterval(0.8f);
        tween.Append(Cup.DOLocalMoveY(1, 0.4f));
    }

    public void Reset()
    {
        isShowBall = false;
        isCanClick = false;
        Ball.gameObject.SetActive(false);
        this.transform.localPosition = orgPos;
        Cup.localPosition = new Vector3(0,1,0);
    }
}
