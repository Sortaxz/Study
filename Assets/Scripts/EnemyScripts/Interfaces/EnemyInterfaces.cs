using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{


    public interface IBossEnemy
    {
        void SetTargetMovement(Vector3 targetPos);
        void Movement(Vector3 targetPos);
        
    }

    public interface IMageEnemy
    {
        void SetTargetMovement(Vector3 targetPos);
        void Movement(Vector3 targetPos);
    }


    public interface IMeleeEnemy
    {
        void SetTargetMovement(Vector3 targetPos);
        void Movement(Vector3 targetPos);
    }

    public interface IRangeEnemy
    {
        void SetTargetMovement(Vector3 targetPos);
        void Movement(Vector3 targetPos);
    }

    public interface ITankEnemy
    {
        void SetTargetMovement(Vector3 targetPos);
        void Movement(Vector3 targetPos);
    }

}
