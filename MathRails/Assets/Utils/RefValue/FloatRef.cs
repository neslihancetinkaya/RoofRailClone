using UnityEngine;

namespace Utils.RefValue
{
    [CreateAssetMenu]
    public class FloatRef : ScriptableObject
    {
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        private float _value;
    }
}