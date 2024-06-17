using UnityEngine;

public class ItemAutoClick : Item
{
    [SerializeField][Range(0, 10)] private int maxLevel;
    [SerializeField][Range(0, 10)] protected int level;

    [SerializeField] private int baseCost;
    [SerializeField] protected int cost;
    [SerializeField] protected float itemValue;

    protected override void Start()
    {
        base.Start();

        itemStatsText[(int)TextType.Level].text = $"Level : {level} / {maxLevel}";
        itemStatsText[(int)TextType.Cost].text = $"Cost : {cost}";
        itemStatsText[(int)TextType.Value].text = $"AutoTime : {-itemValue}";
    }

    public override void PurchaseItem()
    {
        bool isPurchased = (cost <= GameManager.Instance.EnergyController.energyAmount);
        bool isMaxLevel = (level < maxLevel);
        if (isPurchased && isMaxLevel)
        {
            GameManager.Instance.CallChangeEnergyEvent(-cost);

            if (!GameManager.Instance.ClickSO.AutoClickEnabled)
            {
                GameManager.Instance.ClickSO.AutoClickEnabled = true;
            }
            else
            {
                GameManager.Instance.ClickSO.AutoClickInterval -= itemValue;
            }

            level++;
            cost = IncreaseCost(baseCost, level) * IncreaseCost(baseCost, level);

            itemStatsText[(int)TextType.Level].text = $"Level : {level} / {maxLevel}";
            itemStatsText[(int)TextType.Cost].text = $"Cost : {cost}";
        }
    }
}