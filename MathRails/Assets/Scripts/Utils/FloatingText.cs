using System;
using Lean.Pool;
using UnityEngine;

namespace Utils
{
    public class FloatingText : MonoBehaviour
    {
        [SerializeField] private float DespawnTime = 3f;
        [SerializeField] private Vector3 Offset = new Vector3(0, 2, 0);
        private void Start()
        {
            LeanPool.Despawn(gameObject, DespawnTime);
            //transform.localPosition += Offset;
        }
    }
}