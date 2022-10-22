using DG.Tweening;
using UnityEngine;

namespace Level_Elements.Obstacle
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 MoveVector;

        [SerializeField] private float TravelTime;

        [SerializeField] private float WaitAfterEnd;

        [SerializeField] private float WaitAfterComeBack;

        [SerializeField] private Ease TravelCurve;

        [SerializeField] private Ease ComeBackCurve;
        
        
        private Sequence _sequence;
        private Vector3 _beginPosition;

        private void Awake()
        {
            _beginPosition = transform.localPosition;
        }

        private void Start()
        {
            Invoke(nameof(Activate), 0f);
        }
        
        private void Activate()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(
                transform.DOLocalMove(MoveVector, TravelTime)
                    .SetEase(TravelCurve)
                    .SetRelative()
                    .SetDelay(WaitAfterComeBack));
            _sequence.Append(
                transform.DOLocalMove(_beginPosition, TravelTime)
                    .SetEase(ComeBackCurve)
                    .SetDelay(WaitAfterEnd));
            _sequence.SetLoops(-1, LoopType.Restart);
        }

    }
}