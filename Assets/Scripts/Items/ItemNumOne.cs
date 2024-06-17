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

        itemStatsText[(int)TextType.Level].text = $"Level : {level} / {maxLevel}";
        itemStatsText[(int)TextType.Cost].text = $"Cost : {cost}";
        itemStatsText[(int)TextType.Value].text = $"Value : {itemValue}";
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
            itemStatsText[(int)TextType.Cost].text = $"Cost : {cost}";
        }
    }
}
