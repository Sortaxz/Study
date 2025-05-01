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

    public void SetCoinText(int value)
    {
        int coin = balanceOperations.CoinValueIncrease(value);
        balanceTextMeshProGUI.text = coin.ToString();
    }
}
