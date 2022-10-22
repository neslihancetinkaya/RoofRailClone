using System;
using UnityEngine;
using Utils.RefValue;

namespace Utils
{
    public class ValueSetter : MonoBehaviour
    {
        [SerializeField] private BoolRef IsInPool;
        [SerializeField] private IntRef DiamondAmount;

        private void Awake()
        {
            DiamondAmount.Value = 0;
            IsInPool.Value = false;
        }
    }
}