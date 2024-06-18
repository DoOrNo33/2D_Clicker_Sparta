using UnityEngine;
using System.Numerics;
using System.Collections.Generic;

public class ItemNumOne : Item
{

    [SerializeField][Range(0, 10)] private int maxLevel;
    [SerializeField][Range(0, 10)] protected int level;

    [SerializeField] private long baseCost;
    [SerializeField] protected long cost;
    [SerializeField] protected long itemValue;

    private string[] goldUnitArr = new string[] { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "Ud", "Dd", "Td", "Qad", "Qid", "Sxd", "Spd", "Od", "Nd", "Vg", "Uvg", "Dvg", "Tvg", "Qavg", "Qivg", "Sxvg", "Spvg", "Ovg", "Nvg", "Tg", "Utg", "Dtg", "Ttg", "Qatg", "Qitg", "Sxtg", "Sptg", "Otg", "Ntg", "Qag", "Uqag", "Dqag", "Tqag", "Qaqag", "Qiqag", "Sxqag", "Spqag", "Oqag", "Nqag", "Sg", "Usg", "Dsg", "Tsg", "Qasg", "Qisg", "Sxsg", "Spsg", "Osg", "Nsg", "Og", "Uog", "Dog", "Tog", "Qaog", "Qiog", "Sxog", "Spog", "Oog", "Nog", "Ng", "Ung", "Dng", "Tng", "Qang", "Qing", "Sxng", "Spng", "Ong", "Nng", "Cg" };


    protected override void Start()
    {
        base.Start();

        itemStatsText[(int)TextType.Level].text = $"Level : {level} / {maxLevel}";
        itemStatsText[(int)TextType.Cost].text = $"Cost : {GetBigInt(cost)}";
        itemStatsText[(int)TextType.Value].text = $"Value : {GetBigInt(itemValue)}";
    }

    public override void PurchaseItem()
    {
        bool isPurchased = (cost <= GameManager.Instance.EnergyController.energyAmount);
        bool isMaxLevel = (level < maxLevel);
        if (isPurchased && isMaxLevel)
        {
            GameManager.Instance.CallChangeEnergyEvent(-cost);

            clickSO.ClickValue += itemValue;

            level++;
            cost = IncreaseCost(baseCost, level);

            itemStatsText[(int)TextType.Level].text = $"Level : {level} / {maxLevel}";
            itemStatsText[(int)TextType.Cost].text = $"Cost : {GetBigInt(cost)}";
        }
    }

    public string GetBigInt(long num)
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


        for (int i = numList.Count - 1; i >= 0; i--)
        {
            if (numList[i] != 0)
            {
                retStr = retStr + numList[i].ToString() + goldUnitArr[i];
            }

        }


        return retStr;
    }
}
