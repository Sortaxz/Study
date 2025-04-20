using System.Collections;
using System.Collections.Generic;
using Enemy;
using Towers;
using UnityEngine;

public abstract class BaseTowerBullet : MonoBehaviour
{

    [SerializeField] protected GameObject towerBulletTarget;

    private Rigidbody2D towerBulletRb2D;

    private AudioClip towerBulletFireSound;

    private ParticleSystem towerBulletFireParticleEffect;

    public delegate void TowerBulletDestroy();
    public TowerBulletDestroy towerBulletDestroy;

    protected string towerBulletName;
    public string TowerBulletName=>towerBulletName;
    protected float towerBulletLifeTime;
    protected int towerBulletDamage;

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

    public virtual void SetTowerBulletTarget(GameObject target,TowerBulletDestroy _towerBulletDestroy)
    {
        towerBulletDestroy = _towerBulletDestroy;
        towerBulletTarget = target;
        gameObject.SetActive(true);
    }

    public abstract void SetTowerBulletParent(Transform parent,TowerBulletDestroy towerBulletDestroy);

   
    public abstract IEnumerator MovementToTarget(Transform target,float time);

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag != "TowerBullet" & !collision.collider.GetComponent<Tower>())
        towerBulletDestroy();
    
        BaseEnemy.EnemyHealtReductionFindEnemyType(collision.gameObject,20);
    }

}
