using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    PlayerInput input;
    public void Click()
    {
        GameManager.Instance.CallChangeEnergyEvent(GameManager.Instance.ClickSO.ClickValue);
        GameManager.Instance.ClickEvent?.Invoke(GameManager.Instance.ClickSO.ClickValue);
    }

    private void OnEnable()
    {
        if (input == null)
        {
            input = new PlayerInput();            
        }
        input.Player.Planet.started += ctx => Click();
        input.Enable();
    }

    private void OnDisable()
    {
        input.Player.Planet.started -= ctx => Click();
        input.Disable();
    }


}
