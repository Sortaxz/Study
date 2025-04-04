using System;
using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;

namespace Enemy.Bullet
{
    public class EnemyBullet : BaseEnemyBullet
    {
        [SerializeField] private ArcherTower enemyBulletCollisionArcherTower;
        [SerializeField]private FireTower enemyBulletCollisionFireTower;
        [SerializeField]private IceTower enemyBulletCollisionIceTower;
        [SerializeField]private GameObject enemyBulletCollisionMaiTower;
        [SerializeField] Rigidbody2D rb2D;
        [SerializeField] private GameObject target;
        void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        public void EnemyDestory()
        {
            StartCoroutine(StartEnemyBulletDestoryTime());
        }

        public IEnumerator StartEnemyBulletDestoryTime()
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            FindEnemyBulletCollisonGameObject(collision.gameObject);
        }

        private void FindEnemyBulletCollisonGameObject(GameObject collisionGameObject)
        {
            switch(collisionGameObject.tag)
            {
                case "ArcherTower":
                    enemyBulletCollisionArcherTower = collisionGameObject.GetComponent<ArcherTower>();
                    gameObject.SetActive(false);
                    enemyBulletCollisionArcherTower.ReductionTowerHealt(50);
                break;
                
                case "FireTower":
                    enemyBulletCollisionFireTower = collisionGameObject.GetComponent<FireTower>();
                    gameObject.SetActive(false);
                break;
                
                case "IceTower":
                    enemyBulletCollisionIceTower = collisionGameObject.GetComponent<IceTower>();
                    gameObject.SetActive(false);
                break;
                
                case "MainTower":
                    enemyBulletCollisionMaiTower = collisionGameObject;
                    gameObject.SetActive(false);
                break;
                
                default:
                break;

            }

        }

        [SerializeField] private bool isMove = false;

        public void EnemyBulletMovement(Transform _target)
        {
            isMove = true;
            target = _target.gameObject;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position,5 * Time.deltaTime );
        }

        void FixedUpdate()
        {
        }


    }
}

