using System;
using Player;
using TMPro;
using UnityEngine;
using Utils.Event;

namespace Level_Elements
{
    public class FinishFloor : MonoBehaviour
    {
        [SerializeField] private GameEvent LevelCompleted;
        [SerializeField] private Transform Model;
        [SerializeField] private MeshRenderer Mesh;
        [SerializeField] private TextMeshPro TextMesh;

        private void OnCollisionEnter(Collision collision)
        {
            collision.collider.TryGetComponent(out PlayerCollider player);
            if (player)
            {
                LevelCompleted.Raise();
                //Flick material
            }
        }

        public Vector3 GetScale()
        {
            return Model.localScale;
        }
        public void SetMaterial(Material m)
        {
            Mesh.material = m;
        }

        public void SetPosition(float z)
        {
            transform.localPosition = new Vector3(0, 0, z);
        }

        public void SetText(int multiplier)
        {
            TextMesh.text = "x" + multiplier;
        }
    }
}