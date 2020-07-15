using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {

    
    // 主体
    public Transform[] Boby;

    public Vector3[] orgPos;

    public int moveTime = 10;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStart()
    {
        OnClickReset();
       
        int rd = Random.Range(0, 3);
        Boby[rd].GetComponent<Boby>().ShowBallAni();
       
        Sequence tween = DOTween.Sequence();
        tween.AppendInterval(2);
        tween.AppendCallback(MoveOnce);

    }


    public void OnClickReset()
    {
        for (int i = 0; i < Boby.Length; i++)
        {
            Boby[i].GetComponent<Boby>().Reset();
        }
        moveTime = 10;
    }


    private void MoveOnce()
    {

        int[] indexs = GetRandom(2);

        Vector3 pos1 = Boby[indexs[0]].localPosition;
        Vector3 pos2 = Boby[indexs[1]].localPosition;

        Vector3 midPos1 = new Vector3((pos1.x + pos2.x) / 2, 0, 0.5f);
        Vector3 midPos2 = new Vector3(midPos1.x, 0, -0.5f);
        Vector3[] path1 = { pos1, midPos1, pos2 };
        Vector3[] path2 = { pos2, midPos2, pos1 };

        Sequence tween = DOTween.Sequence();
        tween.Append(
                Boby[indexs[0]].transform.DOLocalPath(path1, 0.3f, PathType.CatmullRom)
                .SetOptions(false)
                .SetEase(Ease.Linear)
                );
        tween.Join(
                Boby[indexs[1]].transform.DOLocalPath(path2, 0.3f, PathType.CatmullRom)
                .SetOptions(false)
                .SetEase(Ease.Linear)
                );

        moveTime--;
        if (moveTime > 0)
        {
            tween.AppendCallback(MoveOnce);
        }
        else
        {
            for (int i = 0; i < Boby.Length; i++)
            {
                Boby[i].GetComponent<Boby>().isCanClick = true;
            }
        
        }

    }

    private int[] GetRandom(int RmNum)
    {
        Hashtable hashtable = new Hashtable();
        System.Random rm = new System.Random();
        int[] RmValue = {0,1};
        int index = 0;
        for (int i = 0; hashtable.Count < RmNum; i++)
        {
            int nValue = rm.Next(Boby.Length);
            if (!hashtable.ContainsValue(nValue))
            {
                hashtable.Add(nValue, nValue);
                RmValue[index] = nValue;
                //Debug.Log(nValue);
                index++;
            }
        }
        return RmValue;
    }

}
