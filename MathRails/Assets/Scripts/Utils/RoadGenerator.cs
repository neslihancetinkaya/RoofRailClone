using System;
using UnityEngine;

namespace Utils
{
    public class RoadGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject Road;
        [SerializeField] private float RoadLength;

        private void Start()
        {
            Generate();
        }

        public void Generate()
        {
            for (int i = 0; i < 50; i++)
            {
                var road = Instantiate(Road);
                road.transform.position = new Vector3(0, 0, -1 + i * this.RoadLength);
            }
        }

    }
}
