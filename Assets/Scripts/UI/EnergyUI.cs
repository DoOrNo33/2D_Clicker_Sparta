using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    private TextMeshProUGUI energyText;

    void Start()
    {
        energyText = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.EnergyChange += UpdateEnergyUI;       
    }

    void Update()
    {
        
    }

    public void UpdateEnergyUI(long amount)
    {
        energyText.text = GameManager.Instance.EnergyController.GetEnergyAmount();
    }
}
