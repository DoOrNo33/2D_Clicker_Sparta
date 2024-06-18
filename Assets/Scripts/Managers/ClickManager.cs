using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class ClickManager : MonoBehaviour
{
    GameManager gm;

    private int onClick = Animator.StringToHash("Click");

    private string[] goldUnitArr = new string[] { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "Ud", "Dd", "Td", "Qad", "Qid", "Sxd", "Spd", "Od", "Nd", "Vg", "Uvg", "Dvg", "Tvg", "Qavg", "Qivg", "Sxvg", "Spvg", "Ovg", "Nvg", "Tg", "Utg", "Dtg", "Ttg", "Qatg", "Qitg", "Sxtg", "Sptg", "Otg", "Ntg", "Qag", "Uqag", "Dqag", "Tqag", "Qaqag", "Qiqag", "Sxqag", "Spqag", "Oqag", "Nqag", "Sg", "Usg", "Dsg", "Tsg", "Qasg", "Qisg", "Sxsg", "Spsg", "Osg", "Nsg", "Og", "Uog", "Dog", "Tog", "Qaog", "Qiog", "Sxog", "Spog", "Oog", "Nog", "Ng", "Ung", "Dng", "Tng", "Qang", "Qing", "Sxng", "Spng", "Ong", "Nng", "Cg" };


    private void Start()
    {
        GameManager.Instance.ClickManager = this;
        gm = GameManager.Instance;
        gm.ClickEvent += CreateText;
    }

    // TODO : 스크립트 분리
    public void CreateText(long temp)
    {
        GameObject obj = gm.objectPool.SpawnFromPool("ClickTxt");
        TextMeshProUGUI txt = obj.GetComponent<TextMeshProUGUI>();
        Animator animator = obj.GetComponent<Animator>();

        txt.text = GetValue(gm.ClickSO.ClickValue);
        animator.SetTrigger(onClick);
    }

    public string GetValue(long num)
    {
        int placeN = 3;  // 끊어서 보여줄 자리수
        BigInteger value = num;
        List<int> numList = new List<int>();
        int p = (int)Mathf.Pow(10, placeN); // 끊어서 보여줄 자리수를 만들기 위해 10의  제곱값을 구함

        do
        {
            numList.Add((int)(value % p));  // 3자리씩 끊어서 리스트에 추가 (ex. 1234567890 -> 890, 456, 123)
            value /= p; // 저장된 구간 제외하기 위해 나눔
        }
        while (value >= 1); // 3자리씩 끊어서 나눈 값이 1 이상일 때는 반복

        string retStr = "";

        if (numList.Count < 2)
        {
            for (int i = numList.Count - 1; i >= 0; i--)
            {
                retStr = retStr + numList[i].ToString() + goldUnitArr[i];
            }
        }
        else
        {
            for (int i = numList.Count - 1; i >= numList.Count - 2; i--)
            {
                retStr = retStr + numList[i].ToString() + goldUnitArr[i];
            }
        }

        return retStr;
    }
}