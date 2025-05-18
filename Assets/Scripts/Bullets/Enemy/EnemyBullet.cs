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
        [SerializeField] private GameObject target;
        private Vector3 oldPosition;
        public Vector3 OldPosition { get { return oldPosition; }  set { oldPosition = value; } }
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

            target = null;
            isMove = false;

            transform.position = oldPosition;

            gameObject.SetActive(false);

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            //FindEnemyBulletCollisonGameObject(collision.gameObject);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            FindEnemyBulletCollisonGameObject(collision.gameObject);
        }

        private void FindEnemyBulletCollisonGameObject(GameObject collisionGameObject)
        {
            switch (collisionGameObject.tag)
            {
                case "ArcherTower":
                    enemyBulletCollisionArcherTower = collisionGameObject.GetComponent<ArcherTower>();
                    transform.position = oldPosition;
                    enemyBulletCollisionArcherTower.ReductionTowerHealt(bulletDamage);
                    gameObject.SetActive(false);
                    break;

                case "FireTower":
                    enemyBulletCollisionFireTower = collisionGameObject.GetComponent<FireTower>();
                    transform.position = oldPosition;
                    enemyBulletCollisionFireTower.ReductionTowerHealt(bulletDamage);
                    gameObject.SetActive(false);
                    break;

                case "IceTower":
                    enemyBulletCollisionIceTower = collisionGameObject.GetComponent<IceTower>();
                    transform.position = oldPosition;
                    enemyBulletCollisionIceTower.ReductionTowerHealt(bulletDamage);
                    gameObject.SetActive(false);
                    break;

                case "MainTower":
                    enemyBulletCollisionMaiTower = collisionGameObject;
                    transform.position = oldPosition;
                    MainTower.MainTowerDamaged(collisionGameObject, bulletDamage);
                    gameObject.SetActive(false);
                    break;

                default:
                    break;

            }

            

        }

        [SerializeField] private bool isMove = false;

        public void EnemyBulletMovement(Transform _target,Vector3 pos)
        {
            transform.position = oldPosition;
            isMove = true;
            target = _target.gameObject;
        }

        void Update()
        {
            if (isMove)
            {
                if (target != null)
                    {
                        if (target.activeSelf)
                            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 5 * Time.deltaTime);
                    }
            }
        }

        


    }
}

