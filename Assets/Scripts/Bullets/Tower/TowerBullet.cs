using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : BaseTowerBullet
{
    private static GameObject towerBullet;

    Rigidbody2D Rigidbody2D;

    void Start()
    {
        towerBullet = gameObject;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(MovementToTarget(towerBulletTarget.transform,3));
    }
    

    public override void SetTowerBulletParent(Transform parent,TowerBulletDestroy _towerBulletDestroy)
    {
        transform.SetParent(parent);
    }

    public override IEnumerator MovementToTarget(Transform target,float liveTime)
    {
        if(target != null)
        {
            Rigidbody2D.AddForce(towerBulletTarget.transform.position * 20);
            yield return new WaitForSeconds(liveTime);
            towerBulletDestroy();
        }
        else
        {
            StopCoroutine(MovementToTarget(transform,liveTime));
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            towerBulletDestroy();
        }
    }
}
