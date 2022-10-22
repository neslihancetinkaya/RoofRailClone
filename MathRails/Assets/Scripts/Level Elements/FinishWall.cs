using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level_Elements
{
    public class FinishWall : MonoBehaviour
    {
        [SerializeField] private FinishFloor Floor;
        [SerializeField] private List<Material> Materials;

        private void Start()
        {
            int mCount = Materials.Count;
            Floor.TryGetComponent(out FinishFloor floor);

            for (int i = 0; i < 15; i++)
            {
                var go = Instantiate(Floor, transform);
                var scaleZ = go.GetScale().z;
                go.SetPosition(i * scaleZ);
                go.SetMaterial(Materials[i % mCount]);
                go.SetText(i + 1);
            }
        }
    }
}