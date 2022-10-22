using System;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class UITweener : MonoBehaviour
    {
        [SerializeField] private RectTransform Cursor;
        [SerializeField] private Vector2 StartPos;
        [SerializeField] private Vector2 EndPos;
        [SerializeField] private float Duration;
        [SerializeField] private Ease EaseType;

        private Sequence _sequence;

        private void Awake()
        {
           _sequence = DOTween.Sequence()
                .Append(Cursor.DOAnchorPos(EndPos, Duration)).SetEase(EaseType)
                .Append(Cursor.DOAnchorPos(StartPos, Duration)).SetEase(EaseType).SetLoops(-1, LoopType.Yoyo);
        }

        public void OnGameStarted()
        {
            _sequence.Pause();
            _sequence.Kill();
        }
    }
}
