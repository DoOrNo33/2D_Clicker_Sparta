using System;
using UnityEngine;
using System.Numerics;
using System.Collections.Generic;

[Serializable]
public class EnergyController : MonoBehaviour
{
    [SerializeField] public BigInteger energyAmount { get; private set; }  // ���� ������ ��
    private string[] goldUnitArr = new string[] { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "Ud", "Dd", "Td", "Qad", "Qid", "Sxd", "Spd", "Od", "Nd", "Vg", "Uvg", "Dvg", "Tvg", "Qavg", "Qivg", "Sxvg", "Spvg", "Ovg", "Nvg", "Tg", "Utg", "Dtg", "Ttg", "Qatg", "Qitg", "Sxtg", "Sptg", "Otg", "Ntg", "Qag", "Uqag", "Dqag", "Tqag", "Qaqag", "Qiqag", "Sxqag", "Spqag", "Oqag", "Nqag", "Sg", "Usg", "Dsg", "Tsg", "Qasg", "Qisg", "Sxsg", "Spsg", "Osg", "Nsg", "Og", "Uog", "Dog", "Tog", "Qaog", "Qiog", "Sxog", "Spog", "Oog", "Nog", "Ng", "Ung", "Dng", "Tng", "Qang", "Qing", "Sxng", "Spng", "Ong", "Nng", "Cg" };


    private void Awake()
    {
        GameManager.Instance.EnergyChange += ChangeEnergyAmount;
    }

    public void ChangeEnergyAmount(int amount)
    {
        energyAmount += amount;
    }

    public string GetEnergyAmount()
    {
        int placeN = 3;  // ��� ������ �ڸ���
        BigInteger value = energyAmount;
        List<int> numList = new List<int>();
        int p = (int)Mathf.Pow(10, placeN); // ��� ������ �ڸ����� ����� ���� 10��  �������� ����

        do
        {
            numList.Add((int)(value % p));  // 3�ڸ��� ��� ����Ʈ�� �߰� (ex. 1234567890 -> 890, 456, 123)
            value /= p; // ����� ���� �����ϱ� ���� ����
        }
        while (value >= 1); // 3�ڸ��� ��� ���� ���� 1 �̻��� ���� �ݺ�

        string retStr = "";

        if (numList.Count < 3)
        {
            for (int i = numList.Count - 1; i >= 0; i--)
            {
                retStr = retStr + numList[i].ToString() + goldUnitArr[i];
            }
        }
        else
        {
            for (int i = numList.Count - 1; i >= numList.Count - 3; i--)
            {
                retStr = retStr + numList[i].ToString() + goldUnitArr[i];
            }
        }

        return retStr;
    }
}