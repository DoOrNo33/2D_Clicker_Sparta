using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClick : MonoBehaviour
{
    private bool isAutoClicking = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.ClickSO.AutoClickEnabled && !isAutoClicking)
        {
            isAutoClicking = true;
            StartCoroutine(AutoClickRoutine());
        }
    }

    IEnumerator AutoClickRoutine()
    {
        while (GameManager.Instance.ClickSO.AutoClickEnabled)
        {
            GameManager.Instance.CallChangeEnergyEvent(GameManager.Instance.ClickSO.ClickValue);
            GameManager.Instance.ClickEvent?.Invoke(GameManager.Instance.ClickSO.ClickValue);
            yield return new WaitForSeconds(GameManager.Instance.ClickSO.AutoClickInterval);
        }
    }
}
