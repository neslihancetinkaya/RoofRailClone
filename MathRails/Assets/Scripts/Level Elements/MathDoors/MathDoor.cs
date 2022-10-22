using System;
using Player;
using TMPro;
using UnityEngine;
using Utils;
using Utils.RefValue;

namespace Level_Elements.MathDoors
{
    public class MathDoor : MonoBehaviour
    {
        [SerializeField] private Operations MathOperations;
        [SerializeField] private Material GoodMaterial;
        [SerializeField] private Material BadMaterial;
        [SerializeField] private MeshRenderer DoorMesh;
        [SerializeField] private FloatRef StickScale;
        [SerializeField] private float Amount;
        [SerializeField] private TextMeshPro TextMesh;
        private String _prefix;
        private int _textAmount;

        private void Awake()
        {
            switch (MathOperations)
            {
                case Operations.Add:
                    _prefix = "+";
                    _textAmount = (int) (Amount * 10);
                    DoorMesh.material = GoodMaterial;
                    break;
                case Operations.Substract:
                    _prefix = "-";
                    _textAmount = (int) (Amount * 10);
                    DoorMesh.material = BadMaterial;
                    break;
                case Operations.Divide:
                    _prefix = "÷";
                    _textAmount = (int) Amount;
                    DoorMesh.material = BadMaterial;
                    break;
                case Operations.Multiply:
                    _prefix = "x";
                    _textAmount = (int) Amount;
                    DoorMesh.material = GoodMaterial;
                    break;
            }

            TextMesh.text = _prefix + _textAmount;
        }

        private void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent(out PlayerCollider player);
            if (player)
            {
                var scale = StickScale.Value;
                switch (MathOperations)
                {
                   case Operations.Add:
                       player.Slicer.IncreaseStickScale(Amount);
                       break;
                   case Operations.Substract:
                       player.Slicer.DecreaseStickScale(Amount * 2);
                       break;
                   case Operations.Divide:
                       for (int i = 0; i < Amount - 1; i++)
                       {
                           player.Slicer.DecreaseStickScale(2 * scale / Amount);
                       }
                       break;
                   case Operations.Multiply:
                       for (int i = 0; i < Amount - 1; i++)
                       {
                           player.Slicer.IncreaseStickScale(scale * (Amount - 1));
                       }
                       break;
                }
                gameObject.SetActive(false);
            }
            
        }
    }
}