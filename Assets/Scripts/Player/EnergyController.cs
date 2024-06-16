using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public int energyAmount { get; private set; }  // 메인 에너지 양

    private void Awake()
    {
        GameManager.Instance.EnergyChange += ChangeEnergyAmount;
    }

    public void ChangeEnergyAmount(int amount)
    {
        energyAmount += amount;
    }
}