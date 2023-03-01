using System.Collections;
using UnityEngine;

namespace MicroCombo
{
    public class SequenceTransition : MonoBehaviour
    {
        // Visuals
        private Coroutine _mainRoutine = null;
        private bool _isLocalRoutine = false;
        public bool isRunning
        {
            get { return _isLocalRoutine || (_mainRoutine != null); }
        }

        [SerializeField] private float _showDuration = 1f;
        [SerializeField] private float _hideDuration = 0.5f;

        [SerializeField] private CanvasGroup _screenGroup = null;
        [SerializeField] private AnimationCurve _screenCurve = null;

        [SerializeField] private RectTransform _animHandle = null;
        [SerializeField] private AnimationCurve _animCurve = null;

        [SerializeField] private CanvasGroup _transitionGroup = null;
        

        public void Show(bool instant)
        {
            Transition(true, instant);
        }

        public void Hide(bool instant)
        {
            Transition(false, instant);
        }

        private void Transition(bool isShow, bool instant)
        {
            // Stop any existing
            if (_mainRoutine != null)
            {
                StopCoroutine(_mainRoutine);
                _mainRoutine = null;
            }

            // Instant = set final states
            if (instant)
            {
                SetInterp(isShow);
            }
            else
            {
                _isLocalRoutine = true;
                _mainRoutine = StartCoroutine(ExecuteTransition(isShow));
            }
        }

        private IEnumerator ExecuteTransition(bool isShow)
        {
            // Start of transition
            SetInterp(!isShow);

            float duration = isShow ? _showDuration : _hideDuration;

            // Play the transition
            float animT = 0;
            while (animT < duration)
            {
                float interp = Mathf.Clamp01(animT / duration);
                float adjInterp = interp;
                if (!isShow)
                {
                    adjInterp = 1f - interp;
                }
                SetInterp(interp, adjInterp);

                yield return null;
                animT += Time.deltaTime;
            }

            // Done / end
            SetInterp(isShow);

            _isLocalRoutine = false;
            _mainRoutine = null;
        }

        private void SetInterp(bool isShow)
        {
            float interp = isShow ? 1 : 0;
            SetInterp(interp, interp);
        }

        private void SetInterp(float rawInterp, float adjInterp)
        {
            // Cover information
            float animInterp = UtilsMath.EvaluateCurve(rawInterp, _animCurve);

            Vector2 min = Vector2.zero;
            Vector2 max = Vector2.one;
            
            float buffer = 0.25f;
            min.x = Mathf.Lerp(-1f - buffer, 1f + buffer, animInterp);
            max.x = Mathf.Lerp(-buffer, 2f + buffer, animInterp);

            _animHandle.anchorMin = min;
            _animHandle.anchorMax = max;

            // Screen
            float screenInterp = UtilsMath.EvaluateCurve(adjInterp, _screenCurve);
            float screenAlpha = Mathf.Lerp(1, 0, screenInterp);
            _screenGroup.alpha = screenAlpha;
            _screenGroup.gameObject.SetActive(screenAlpha > 0);

            // Transition
            float transitionAlpha = 1f;//Mathf.Lerp(0, 1, interp);
            if (adjInterp <= 0 ||
                adjInterp >= 1)
            {
                transitionAlpha = 0;
            }

            _transitionGroup.alpha = transitionAlpha;
            _transitionGroup.gameObject.SetActive(transitionAlpha > 0);
        }

        public void Stop()
        {
            if (_mainRoutine != null)
            {
                StopCoroutine(_mainRoutine);
                _mainRoutine = null;
            }

            _isLocalRoutine = false;
        }
    }
}
