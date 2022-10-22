using UnityEngine;

namespace Player
{
    public class SwerveMovement : MonoBehaviour
    {
        [SerializeField] private float SwerveSpeed = 0.5f;
        [SerializeField] private float MaxSwerveAmount = 1f;
        [SerializeField] private float ForwardSpeed = 1f;
        [SerializeField] private float ForwardRailSpeed = 7f;

        private SwerveInput _swerveInput;
        private bool _isActive;
        private float _forwardSpeed;
        private void Awake()
        {
            _swerveInput = GetComponent<SwerveInput>();
            _forwardSpeed = ForwardSpeed;
        }

        private void Update()
        {
            if(!_isActive) 
                return;
            float swerveAmount = Time.deltaTime * SwerveSpeed * _swerveInput.MoveFactorX;
            float finalPos = transform.position.x + swerveAmount;
            
            if (finalPos < -MaxSwerveAmount)
                swerveAmount = -MaxSwerveAmount - transform.localPosition.x;
            else if(finalPos > MaxSwerveAmount)
                swerveAmount = MaxSwerveAmount - transform.localPosition.x;
            
            transform.position += transform.right * swerveAmount;
            transform.position += transform.forward * (_forwardSpeed * Time.deltaTime);
        }

        public void SetIsActive(bool flag)
        {
            _isActive = flag;
        }

        public void IncreaseSpeed()
        {
            _forwardSpeed = ForwardRailSpeed;
        }

        public void DecreaseSpeed()
        {
            _forwardSpeed = ForwardSpeed;
        }
    }
}