using System;
using DG.Tweening;
using Lean.Pool;
using Level_Elements.Obstacle;
using UnityEngine;
using Utils.Event;
using Utils.RefValue;

namespace Stick
{
    public class SliceController : MonoBehaviour
    {
        [SerializeField] private float CutAmount = 1;
        [SerializeField] private float RepeatTime;
        [SerializeField] private GameObject Stick;
        [SerializeField] private GameEvent LevelFailed;
        [SerializeField] private float MinimumLength = .5f;
        [SerializeField] private BoolRef IsInPool;
        [SerializeField] private FloatRef StickScale;

        private float _nextTime;
        private bool _isFailed;

        private void Awake()
        {
            StickScale.Value = Stick.transform.localScale.y;
        }

        private void Update()
        {
            /*
            if (StickScale.Value < MinimumLength)
            {
                if (!_isFailed)
                {
                    _isFailed = true;
                    LevelFailed.Raise();
                }
            }
            */
            
            if(!IsInPool.Value)
                return;
            if (Time.time > _nextTime)
            {
                PoolCut();
                _nextTime = Time.time + RepeatTime;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out ObstacleCollider obstacle);
            if (!obstacle)
                return;
            SawCut(obstacle.transform.position.x);
        }

        private void CreateStick(float sign, float distance, float localScaleY)
        {
            Vector3 stickScale = Stick.transform.localScale;
            Vector3 stickPos = Stick.transform.position;
            GameObject newObject = LeanPool.Spawn(Stick);
            newObject.transform.localScale = new Vector3(stickScale.x, distance / 2, stickScale.z);
            newObject.transform.rotation = Stick.transform.rotation;
            newObject.transform.position = new Vector3(sign * (localScaleY - newObject.transform.localScale.y), stickPos.y, stickPos.z);
            newObject.TryGetComponent(out Rigidbody rb);
            if (!rb)
            {
                newObject.AddComponent<Rigidbody>();
            }
            LeanPool.Despawn(newObject, 1f);
        }
        
        private void SawCut(float xPos)
        {
            if (Stick.transform.localScale.y < MinimumLength)
            {
                if (!_isFailed)
                {
                    _isFailed = true;
                    LevelFailed.Raise();
                }
                return;
            }
            
            if (xPos < Stick.transform.position.x)
            {
                float localScaleY = Stick.transform.localScale.y;
                localScaleY -= Stick.transform.position.x;
                float distance = localScaleY + xPos;

                if (distance / 2 > 0)
                {
                    DecreaseStickScale(distance);
                    Stick.transform.position = new Vector3(Stick.transform.position.x + distance / 2, Stick.transform.position.y, Stick.transform.position.z);
                    CreateStick(-1, distance, localScaleY);
                }
            }
            else
            {
                float localScaleY = Stick.transform.localScale.y;
                localScaleY += Stick.transform.position.x;
                float distance = localScaleY - xPos;

                if (distance / 2 > 0)
                {
                    DecreaseStickScale(distance);
                    Stick.transform.position = new Vector3(Stick.transform.position.x - distance / 2, Stick.transform.position.y, Stick.transform.position.z);

                    CreateStick(1, distance, localScaleY);
                }
            }

            DOVirtual.DelayedCall(.8f, () => Stick.transform.DOLocalMoveX(0, .8f));

        }

        private void PoolCut()
        {
            if (transform.localScale.y < MinimumLength)
            {
                if (!_isFailed)
                {
                    _isFailed = true;
                    LevelFailed.Raise();
                }
                return;
            }
            
            DecreaseStickScale(CutAmount);
            
            float localScaleY = Stick.transform.localScale.y;
            localScaleY -= Stick.transform.position.x;
            CreateStick(-1, CutAmount, localScaleY);
            
            localScaleY = Stick.transform.localScale.y;
            localScaleY += Stick.transform.position.x;
            CreateStick(1, CutAmount, localScaleY);
        }

        public void IncreaseStickScale(float amount)
        {
            var newY = Stick.transform.localScale.y + amount;
            Stick.transform.DOScaleY(newY, 0);
            StickScale.Value = newY;
        }

        public void DecreaseStickScale(float distance)
        {
            var newY = Stick.transform.localScale.y - distance / 2;
            Stick.transform.DOScaleY(newY, 0);
            StickScale.Value = newY;
        }
    }
}