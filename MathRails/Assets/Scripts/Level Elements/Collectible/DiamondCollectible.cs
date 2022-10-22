using UnityEngine;
using Utils.RefValue;

namespace Level_Elements.Collectible
{
    public class DiamondCollectible : CollectibleBase
    {
        [SerializeField] private IntRef DiamondAmount;


        protected override void OnCollected()
        {
            DiamondAmount.Value++;
        }
    }
}