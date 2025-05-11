using System.Collections;
using System.Collections.Generic;
using Enemy;
using Towers;
using UnityEngine;

public abstract class BaseTowerBullet : MonoBehaviour
{

    [SerializeField] protected GameObject towerBulletTarget;
    
    protected Rigidbody2D towerBulletRb2D;

    private AudioClip towerBulletFireSound;

    private ParticleSystem towerBulletFireParticleEffect;


    protected string towerBulletName;
    public string TowerBulletName=>towerBulletName;
    protected float towerBulletLifeTime;
    protected float towerBulletDamage;

    protected float towerBulletSpeed;

    void Awake()
    {
    }

    public void SetTowerBulletName(string _towerBulletName,int indexCount)
    {
        string newTowerBulletName = _towerBulletName.Replace("(Clone)","");
        newTowerBulletName += $" {indexCount}";
        towerBulletName = newTowerBulletName;
    }

    public virtual void SetTowerBulletTarget(GameObject target,float towerDamage)
    {
        towerBulletDamage += towerDamage;
        towerBulletTarget = target;
        gameObject.SetActive(true);
    }

    public virtual void RemoveTowerBulletTarget()
    {
        towerBulletTarget = null;
        gameObject.SetActive(false);
    }

    public abstract void SetTowerBulletParent(Transform parent);

   
    public abstract IEnumerator MovementToTarget(Transform target,float time);

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag != "TowerBullet" & !collision.collider.GetComponent<Tower>() && !collision.collider.CompareTag("TowerPosition"))
        {
            BaseEnemy.EnemyHealtReductionFindEnemyType(collision.gameObject,towerBulletDamage);
            gameObject.SetActive(false);
        }
    }

}
