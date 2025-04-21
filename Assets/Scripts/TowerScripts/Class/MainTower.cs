using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;

public class MainTower : MonoBehaviour
{
    [SerializeField] TowerUIController towerUIController;
    [SerializeField]private float towerHealt;
    private const float maxTowerHealt = 100;
    private int towerCost;
    private float towerDamage;
    void Awake()
    {
        towerHealt = 100;
        towerUIController = GetComponent<TowerUIController>();
    }

    public virtual void MainTowerHealtIncrease(float healt)
    {
        if (towerHealt < maxTowerHealt)
        {
            towerHealt += healt;
        }
        else
        {
            towerHealt = maxTowerHealt;
        }

        towerUIController.HealtBarValueIncrease(towerHealt);
    }

    public virtual void MainTowerHealtReduction(float value)
    {
        if (towerHealt > 0)
        {
            towerHealt -= value;
        }
        else
        {
            MainTowerDestroy();
            towerHealt = 0;
        }
        towerUIController.HealtBarValueReduction(towerHealt);
    }



    public void SetTowerCost(int cost)
    {
        towerCost = cost;
    }

    

    public  void SetTowerDamage(int damage)
    {
        towerDamage = damage;
    }

    public void MainTowerDestroy()
    {
        GameManager.Instance.GameOver();
        gameObject.SetActive(false);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
    }

    public static void MainTowerDamaged(GameObject _mainTower,float damagedValue)
    {
        MainTower mainTower = _mainTower.GetComponent<MainTower>();
        mainTower.MainTowerHealtReduction(damagedValue);
    }

    
}

