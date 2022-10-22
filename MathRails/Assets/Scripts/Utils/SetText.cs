using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Utils.Event;
using Utils.RefValue;

namespace Utils
{
    public class SetText : MonoBehaviour
    {
        [SerializeField] private IntRef DiamondAmount;
        [SerializeField] private TextMeshProUGUI TextMesh;

        public void OnDiamondCollected()
        {
            DOVirtual.DelayedCall(.3f, () => TextMesh.text = DiamondAmount.Value.ToString());
        }
    }
}