using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action<long> EnergyChange;
    public Action<long> ClickEvent;

    public EnergyController EnergyController;

    public ClickSO ClickSO;

    public AutoClick AutoClick;

    public Particle mainParticle;

    public ObjectPool objectPool;

    public ClickManager ClickManager;

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

    public void CallChangeEnergyEvent(long amount)
    {
        EnergyChange?.Invoke(amount);
    }

    private void InitializeGame()
    {
        // TODO : 저장 데이터 불러오기
        ClickSO.ClickValue = 1;
        ClickSO.AutoClickInterval = 1;
        ClickSO.AutoClickEnabled = false;
    }


}
