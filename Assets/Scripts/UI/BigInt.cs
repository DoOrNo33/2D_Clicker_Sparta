using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BigInt : MonoBehaviour
{
    public TextMeshProUGUI label;

    BigInteger gold = 0;

    void Update()
    {
        // TODO : 테스트용 업데이트 문 나중에 지우기
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    AddGold(1000000000);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    DoubleGold();
        //}
    }

    public void DisplayGold()
    {
        label.text = GetGoldUnit();
    }

    public void AddGold(int add)
    {
        gold += add;
        DisplayGold();
    }

    public void DoubleGold()
    {
        gold *= 2;
        DisplayGold();
    }

    private string[] goldUnitArr = new string[] { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "Ud", "Dd", "Td", "Qad", "Qid", "Sxd", "Spd", "Od", "Nd", "Vg", "Uvg", "Dvg", "Tvg", "Qavg", "Qivg", "Sxvg", "Spvg", "Ovg", "Nvg", "Tg", "Utg", "Dtg", "Ttg", "Qatg", "Qitg", "Sxtg", "Sptg", "Otg", "Ntg", "Qag", "Uqag", "Dqag", "Tqag", "Qaqag", "Qiqag", "Sxqag", "Spqag", "Oqag", "Nqag", "Sg", "Usg", "Dsg", "Tsg", "Qasg", "Qisg", "Sxsg", "Spsg", "Osg", "Nsg", "Og", "Uog", "Dog", "Tog", "Qaog", "Qiog", "Sxog", "Spog", "Oog", "Nog", "Ng", "Ung", "Dng", "Tng", "Qang", "Qing", "Sxng", "Spng", "Ong", "Nng", "Cg" };
    private string GetGoldUnit()
    {
        int placeN = 3;  // 끊어서 보여줄 자리수
        BigInteger value = gold;
        List<int> numList = new List<int>();
        int p = (int)Mathf.Pow(10, placeN); // 끊어서 보여줄 자리수를 만들기 위해 10의  제곱값을 구함

        do
        {
            numList.Add((int)(value % p));  // 3자리씩 끊어서 리스트에 추가 (ex. 1234567890 -> 890, 456, 123)
            value /= p; // 저장된 구간 제외하기 위해 나눔
        }
        while (value >= 1); // 3자리씩 끊어서 나눈 값이 1 이상일 때는 반복

        string retStr = "";
        for( int i = 0; i < numList.Count; i++)
        {
            retStr = numList[i].ToString() + goldUnitArr[i] + retStr;
        }

        return retStr;
    }



}