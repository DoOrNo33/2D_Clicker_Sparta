using TMPro;
using UnityEngine;

public enum TextType
{
    Level,
    Cost,
    Value
}

public class Item : MonoBehaviour, Purchase
{
    public ClickSO clickSO;
    [SerializeField] protected TextMeshProUGUI[] itemStatsText;


    protected virtual void Start()
    {
        clickSO = GameManager.Instance.ClickSO;
        itemStatsText = GetComponentsInChildren<TextMeshProUGUI>();
    }

    public virtual void PurchaseItem()
    {
        
    }

    protected virtual long IncreaseCost(long baseCost, int level)
    {
        //피보나치 수열 계산 코드

        long a = baseCost;
        long b = baseCost;
        long c = 0;

        for (int i = 0; i < level; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c;
    }
}
