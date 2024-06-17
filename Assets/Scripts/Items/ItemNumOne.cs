using UnityEngine;

public class ItemNumOne : Item
{

    [SerializeField][Range(0, 10)] private int maxLevel;
    [SerializeField][Range(0, 10)] protected int level;

    [SerializeField] private int baseCost;
    [SerializeField] protected int cost;
    [SerializeField] protected int itemValue;

    protected override void Start()
    {
        base.Start();

        itemStatsText[(int)TextType.Level].text = $"레벨 : {level} / {maxLevel}";
        itemStatsText[(int)TextType.Cost].text = $"구매 비용 : {cost}";
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

            itemStatsText[(int)TextType.Level].text = $"레벨 : {level} / {maxLevel}";
            itemStatsText[(int)TextType.Cost].text = $"구매 비용 : {cost}";
        }
    }
}
