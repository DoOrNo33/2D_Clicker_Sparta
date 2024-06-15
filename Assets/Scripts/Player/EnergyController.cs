using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public int energyAmount { get; private set; }

    private void Awake()
    {
        GameManager.Instance.EnergyChange += ChangeEnergyAmount;
    }

    public void ChangeEnergyAmount(int amount)
    {
        energyAmount += amount;
    }
}