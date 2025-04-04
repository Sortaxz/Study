using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTowerBullet : MonoBehaviour
{
    protected string towerBulletName;
    public string TowerBulletName=>towerBulletName;

    protected GameObject towerBulletTarget;

    private Rigidbody2D towerBulletRb2D;

    private AudioClip towerBulletFireSound;

    private ParticleSystem towerBulletFireParticleEffect;

    protected int towerBulletDamage;

    protected float towerBulletLifeTime;
    protected int towerBulletSpeed;

    void Awake()
    {
        towerBulletRb2D = GetComponent<Rigidbody2D>();
    }

    public void SetTowerBulletName(string _towerBulletName,int indexCount)
    {
        string newTowerBulletName = _towerBulletName.Replace("(Clone)","");
        newTowerBulletName += $" {indexCount}";
        towerBulletName = newTowerBulletName;
    }

    public virtual void SetTowerBulletTarget(GameObject target)
    {
        towerBulletTarget = target;
    }

}
