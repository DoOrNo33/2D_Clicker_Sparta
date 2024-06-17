using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action<int> EnergyChange;
    public Action<int> ClickEvent;

    public EnergyController EnergyController;

    public ClickSO ClickSO;

    public AutoClick AutoClick;

    public Particle mainParticle;

    public ObjectPool objectPool;

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
        ClickEvent += CreateText;
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

    // TODO : ��ũ��Ʈ �и�
    public void CreateText(int temp)
    {
        GameObject obj = objectPool.SpawnFromPool("ClickTxt");
        TextMeshProUGUI txt = obj.GetComponent<TextMeshProUGUI>();
        Animator animator = obj.GetComponent<Animator>();

        txt.text = ClickSO.ClickValue.ToString();
        animator.SetTrigger("Click");
    }
}
