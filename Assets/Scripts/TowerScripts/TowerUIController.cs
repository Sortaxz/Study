using System.Collections;
using System.Collections.Generic;
using Towers;
using Towers.UpgradeControl;
using UnityEngine;
using UnityEngine.UI;

public class TowerUIController : MonoBehaviour
{
    private Tower tower;
    private TowerUpgrade towerUpgrade;
    [SerializeField] Image healtBar;
    [SerializeField] private Image towerUpgradeIcon;
    [SerializeField] private Image towerFireIconImage;
    [SerializeField] private Button towerUpgradeButton => towerUpgradeIcon.GetComponent<Button>();

    void Awake()
    {

        tower = gameObject.GetComponent<Tower>();
        if (towerUpgrade == null) towerUpgrade = new TowerUpgrade();
        if (!gameObject.CompareTag("MainTower"))
        {
            if (GameManager.Instance.BalanceOperations.CoinValue > tower.TowerCost)
            {
                SetTowerUpgradeIconActive(true);
            }
        }


    }

    void Start()
    {
    }

    public void SetHealtBarValue(float towerHealt)
    {
        float a = towerHealt / 100f;
        healtBar.fillAmount = a;
    }

    public void HealtBarValueIncrease(float towerHealt)
    {
        SetHealtBarValue(towerHealt);
    }

    public void HealtBarValueReduction(float towerHealt)
    {
        SetHealtBarValue(towerHealt);
    }

    public void SetTowerUpgradeIconActive(bool isActive)
    {
        towerUpgradeIcon.gameObject.SetActive(isActive);
        SetTowerUpgradeButtonInteractableActive(isActive);
    }

    public void SetTowerUpgradeButtonInteractableActive(bool isActive)
    {
        towerUpgradeButton.interactable = isActive;
    }

    public void TowerUpgradeButton()
    {
        towerUpgrade.Upgrade(tower);
        towerUpgradeIcon.gameObject.SetActive(false);
    }

    public void TowerFireIconOpen(bool value)
    {
        TowerFireUI towerFireUI = towerFireIconImage.GetComponent<TowerFireUI>();
        towerFireUI.gameObject.SetActive(value);
        towerFireUI.TowerFireUIActiveFuntion(value);
    }

    public void TowerFireIconClose()
    {
        towerFireIconImage.gameObject.SetActive(false);
    }

}
