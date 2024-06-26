using UnityEngine;

[CreateAssetMenu(fileName = "ClickSO", menuName = "ScriptableObjects/ClickSO", order = 1)]
public class ClickSO : ScriptableObject
{
    public long ClickValue = 1;
    public float AutoClickInterval = 1f;
    public bool AutoClickEnabled = false;
}
