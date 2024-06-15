using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBtn : MonoBehaviour
{
    [SerializeField] private int EnergyModifier = 1;
    public void Click()
    {
        GameManager.Instance.CallChangeEnergyEvent(EnergyModifier);
    }
}
