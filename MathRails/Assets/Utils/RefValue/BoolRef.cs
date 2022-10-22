using UnityEngine;

namespace Utils.RefValue
{
    [CreateAssetMenu]

    public class BoolRef : ScriptableObject
    {
        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        private bool _value;
    }
}