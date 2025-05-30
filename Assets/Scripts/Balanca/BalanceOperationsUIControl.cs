using System.Collections;
using System.Collections.Generic;
using Balance;
using TMPro;
using UnityEngine;

public class BalanceOperationsUIControl
{
    BalanceOperations balanceOperations;
    private TextMeshProUGUI balanceTextMeshProGUI;

    public BalanceOperationsUIControl(BalanceOperations _balanceOperations,TextMeshProUGUI textMeshProUGUI)
    {
        balanceOperations = _balanceOperations;
        balanceTextMeshProGUI = textMeshProUGUI;
    }

    public void SetCoinIncraseText(int value)
    {
        float coin = balanceOperations.CoinValueIncrease(value);
        balanceTextMeshProGUI.text = coin.ToString();
        
    }

    public void SetCoinValueReductionText(float value)
    {
        float coin = balanceOperations.CoinValueReduction(value);
        balanceTextMeshProGUI.text = coin.ToString();
    }
}
