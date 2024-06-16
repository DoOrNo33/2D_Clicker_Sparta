using UnityEngine;

public class Item : MonoBehaviour, Purchase
{
    public ClickSO ClickSO;

    [SerializeField] protected int Level;
    [SerializeField] protected int cost;
    [SerializeField] protected int ItemValue;

    protected virtual void Awake()
    {
        ClickSO = GameManager.Instance.ClickSO;
    }

    public virtual void PurchaseItem()
    {
        
    }
}
