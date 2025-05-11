using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerBullets.FireTowerBullets
{
    public class FireTowerBullet : BaseTowerBullet
    {
        private bool isStop = false;
        private bool isPause = false;

        void Awake()
        {
            towerBulletRb2D = GetComponent<Rigidbody2D>();
        }

        void OnEnable()
        {
            if (towerBulletTarget != null)
                StartCoroutine(MovementToTarget(towerBulletTarget.transform, 3));
        }

        void Start()
        {
            StartCoroutine(MovementToTarget(towerBulletTarget.transform, 3));
        }

        public override IEnumerator MovementToTarget(Transform target, float time)
        {
            while (!isStop)
            {
                if (!isPause)
                {
                    float distance = Vector3.Distance(transform.position, towerBulletTarget.transform.position);
                    if (distance > .5f)
                    {
                        transform.position = Vector3.Lerp(transform.position, towerBulletTarget.transform.position, Time.deltaTime * 2f);
                    }
                    else
                    {
                        isStop = true;
                    }
                    yield return null;
                }
            }
        }

        public override void SetTowerBulletParent(Transform parent)
        {
        }
    }
}
