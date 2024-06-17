using TMPro;
using UnityEngine;

public enum TextType
{
    Level,
    Cost,
    Stats
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

    protected virtual int IncreaseCost(int baseCost, int level)
    {
        //�Ǻ���ġ ���� ��� �ڵ�

        int a = baseCost;
        int b = baseCost;
        int c = 0;

        for (int i = 0; i < level; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c;
    }
}
