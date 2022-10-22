using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int Hanging = Animator.StringToHash("Hanging");
        private static readonly int IsDie = Animator.StringToHash("Die");
        private static readonly int Dance = Animator.StringToHash("Dance");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Idle()
        {
            _animator.SetBool(IsWalking, false);
            //_animator.SetBool(Hanging, false);
        }
        public void Walk()
        {
            _animator.SetBool(IsWalking, true);
        }

        public void Hang(bool flag)
        {
            _animator.SetBool(Hanging, flag);
        }

        public void Die()
        {
            _animator.SetTrigger(IsDie);
        }

        public void Cheer()
        {
            _animator.SetBool(IsWalking, false);
            _animator.SetBool(Dance, true);
        }
        
    }
}