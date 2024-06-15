using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action<int> EnergyChange;

    public EnergyController energyController;

    protected override void Awake()
    {
        base.Awake();

        if (energyController == null)
        {
            GameObject objg = new GameObject("EnergyController");
            energyController = objg.AddComponent<EnergyController>();
            objg.transform.SetParent(transform);
        }
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
}
