using UnityEngine;

namespace Utils
{
    public class TargetController : MonoBehaviour
    {
        [SerializeField] private Vector3 StartRotation;
        void Start()
        {
            transform.eulerAngles = StartRotation;
        }
        
        void Update()
        {
        
        }
    }
}
