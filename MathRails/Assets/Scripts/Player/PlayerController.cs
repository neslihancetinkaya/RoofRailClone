using System;
using DG.Tweening;
using Lean.Pool;
using Level_Elements;
using Level_Elements.Collectible;
using Level_Elements.Obstacle;
using Stick;
using UnityEngine;
using Utils.Event;
using Utils.RefValue;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerAnimatorController PlayerAnimator;
        [SerializeField] private BoolRef IsInPool;
        [SerializeField] private SkinnedMeshRenderer MeshRenderer;
        [SerializeField] private Material DeadMaterial;
        [SerializeField] private GameEvent IncreaseSpeed;
        [SerializeField] private GameEvent DecreaseSpeed;
        [SerializeField] private GameObject ParticleLeft;
        [SerializeField] private GameObject ParticleRight;



        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out PoolCollider pool);
            if (pool)
                IsInPool.Value = true;
            
            other.TryGetComponent(out CliffCollider cliff);
            if (cliff)
            {
                IncreaseSpeed.Raise();
                PlayerAnimator.Idle();
                PlayerAnimator.Hang(true);
            }
            
            other.TryGetComponent(out RailCollider rail);
            if (rail)
            {
                ParticleLeft.transform.localPosition = rail.LeftRail.localPosition;
                ParticleLeft.SetActive(true);
                ParticleRight.transform.localPosition = rail.RightRail.localPosition;
                ParticleRight.SetActive(true);
            }
        }
        

        private void OnTriggerExit(Collider other)
        {
            other.TryGetComponent(out PoolCollider pool);
            if (pool)
                IsInPool.Value = false;
            
            other.TryGetComponent(out CliffCollider cliff);
            if (cliff)
            {
                DecreaseSpeed.Raise();
                PlayerAnimator.Hang(false);
                PlayerAnimator.Walk();
            }
            
            other.TryGetComponent(out RailCollider rail);
            if (rail)
            {
                ParticleLeft.SetActive(false);
                ParticleRight.SetActive(false);
            } 
        }

        public void OnGameStarted()
        {
            PlayerAnimator.Walk();
        }

        public void Die()
        {
            PlayerAnimator.Die();
            MeshRenderer.material = DeadMaterial;
        }

        public void OnLevelCompleted()
        {
            transform.DORotate(new Vector3(0, 180, 0), .8f);
            PlayerAnimator.Cheer();
        }
    }
}
