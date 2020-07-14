using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {

    
    // 主体
    public Transform[] Boby;

    public Vector3[] orgPos;

    // Use this for initialization
    void Start () {

// 		for (int i = 0; i < Boby.Length; i++)
//         {
//             orgPos[i] = Boby[i].localPosition;
//         }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStart()
    {
        OnClickReset();
        int[] indexs = GetRandom(2);


        Vector3 midPos1 = new Vector3((orgPos[indexs[0]].x+orgPos[indexs[1]].x)/2, 0, 0.4f);
        Vector3 midPos2 = new Vector3(midPos1.x, 0, -0.5f);
        Vector3[] path1 = { orgPos[indexs[0]], midPos1, orgPos[indexs[1]]};
        Vector3[] path2 = { orgPos[indexs[1]], midPos2, orgPos[indexs[0]]};

        Sequence tween = DOTween.Sequence();
        tween.Append(
                Boby[indexs[0]].transform.DOLocalPath(path1, 0.6f, PathType.CatmullRom)
                .SetOptions(false)
                .SetEase(Ease.Linear)
                );
        tween.Join(
                Boby[indexs[1]].transform.DOLocalPath(path2, 0.6f, PathType.CatmullRom)
                .SetOptions(false)
                .SetEase(Ease.Linear)
                );

    }


    public void OnClickReset()
    {
        for (int i = 0; i < Boby.Length; i++)
        {
            Boby[i].GetComponent<Boby>().Reset();
        }
    }

    private int[] GetRandom(int RmNum)
    {
        Hashtable hashtable = new Hashtable();
        System.Random rm = new System.Random();
        int[] RmValue = {0,1};
        for (int i = 0; hashtable.Count < RmNum; i++)
        {
            int nValue = rm.Next(Boby.Length);
            if (!hashtable.ContainsValue(nValue))
            {
                hashtable.Add(nValue, nValue);
                RmValue[i] = nValue;
            }
        }
        return RmValue;
    }

}
