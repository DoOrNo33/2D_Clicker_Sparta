using System.Diagnostics;

public class ItemNumOne : Item
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void PurchaseItem()
    {
        bool isPurchased = (cost <= GameManager.Instance.EnergyController.energyAmount);
        if (isPurchased)
        {
            GameManager.Instance.EnergyController.ChangeEnergyAmount(-cost);
            ClickSO.ClickValue += ItemValue;
            cost = (int)(cost * 1.5f);
        }
    }
}