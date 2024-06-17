using System;
using UnityEngine;

[Serializable]
public class EnergyController : MonoBehaviour
{
    [SerializeField] public int energyAmount { get; private set; }  // 메인 에너지 양

    private void Awake()
    {
        GameManager.Instance.EnergyChange += ChangeEnergyAmount;
    }

    public void ChangeEnergyAmount(int amount)
    {
        energyAmount += amount;
    }
}