using System;
using Lean.Pool;
using Player;
using UnityEngine;

namespace Level_Elements.Collectible
{
    public class StickCollectible : CollectibleBase
    {
        [SerializeField] private GameObject FloatingText;
        protected override void OnCollected()
        {
            if (FloatingText != null)
            {
                ShowFloatingText();
            }
        }

        private void ShowFloatingText()
        {
            var text = LeanPool.Spawn(FloatingText);
            text.transform.position = transform.position;
        }

    }
}