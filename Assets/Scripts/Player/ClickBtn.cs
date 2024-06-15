using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBtn : MonoBehaviour
{
    public void Click()
    {
        GameManager.Instance.CallChangeEnergyEvent(GameManager.Instance.ClickSO.ClickValue);
    }
}
