using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class BossEnemy : BaseEnemy, IBossMovement
    {
        Vector3 pos = Vector3.zero;

        public void RigidBodyMove(Vector3 target)
        {
            transform.Translate(target * Time.deltaTime);
        }

        public void SetTargetMovement(Vector3 target)
        {
            pos = target;
        }

        void Update()
        {
            RigidBodyMove(pos);
        }
    }

}
