using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action<int> EnergyChange;
    public Action<int> ClickEvent;

    public EnergyController EnergyController;

    public ClickSO ClickSO;

    public AutoClick AutoClick;

    protected override void Awake()
    {
        base.Awake();

        if (EnergyController == null)
        {
            GameObject objg = new GameObject("EnergyController");
            EnergyController = objg.AddComponent<EnergyController>();
            objg.transform.SetParent(transform);
        }

        if (AutoClick == null)
        {
            GameObject objg = new GameObject("AutoClick");
            AutoClick = objg.AddComponent<AutoClick>();
            objg.transform.SetParent(transform);
        }

        InitializeGame();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CallChangeEnergyEvent(int amount)
    {
        EnergyChange?.Invoke(amount);
    }

    private void InitializeGame()
    {
        // TODO : Load data from save file
        ClickSO.ClickValue = 1;
        ClickSO.AutoClickInterval = 1;
        ClickSO.AutoClickEnabled = false;
    }
}
