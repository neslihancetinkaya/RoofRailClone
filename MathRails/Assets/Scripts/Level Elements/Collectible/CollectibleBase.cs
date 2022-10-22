using Player;
using UnityEngine;
using Utils.Event;

namespace Level_Elements.Collectible
{
    public abstract class CollectibleBase : MonoBehaviour
    {
        [SerializeField] private GameEvent CollectibleCollected;
        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out PlayerCollider player);
            if (player)
            {
                CollectibleCollected.Raise();
                OnCollected();
                gameObject.SetActive(false);
            }
        }

        protected abstract void OnCollected();
    }
}