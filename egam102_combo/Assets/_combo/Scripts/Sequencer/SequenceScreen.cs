using System.Collections;
using UnityEngine;

namespace MicroCombo
{
    public class SequenceScreen : MonoBehaviour   
    {
        // UI 
        [SerializeField] private LivesUi _livesUi = null;

        [SerializeField] private GameUi _gamePrefab = null;
        [SerializeField] private Transform _gameParentHandle = null;
        private GameUi _gameUi = null;

        // Animation
        private Coroutine _mainRoutine = null;
        private bool _isLocalRoutine = false;
        public bool isRunning 
        {
            get { return _isLocalRoutine || (_mainRoutine != null); }
        }

        [SerializeField] private float _introDuration = 1f;
        [SerializeField] private float _resultDuration = 1f;
        [SerializeField] private float _loseLifeDuration = 1f;

        public void Init(int lives)
        {
            // Reset the screen to the original state
            _livesUi.Init(lives);
        }

        public void QueueGame(MicrogameData data)
        {
            Stop();

            if (_gameUi == null)
            {
                _gameUi = GameObject.Instantiate<GameUi>(_gamePrefab);
                _gameUi.transform.SetParent(_gameParentHandle, false);
            }

            _gameUi.SetData(data);
            _gameUi.SetInterp(-1, true);

            // Get this new game focused
            _isLocalRoutine = true;
            _mainRoutine = StartCoroutine(ExecuteIntro());
        }

        private IEnumerator ExecuteIntro()
        {
            // Show the results
            _gameUi.SetInterp(0, false);
            yield return new WaitForSeconds(_introDuration);

            // All done
            _isLocalRoutine = false;
            _mainRoutine = null;
        }

        public void SetResults(bool isWin, int newLivesCount)
        {
            Stop();

            _isLocalRoutine = true;
            _mainRoutine = StartCoroutine(ExecuteResults(isWin, newLivesCount));
        }

        private IEnumerator ExecuteResults(bool isWin, int newLivesCount)
        {
            // Lose a life?
            _gameUi.SetResult(isWin);
            if (!isWin)
            {
                yield return new WaitForSeconds(_loseLifeDuration);
            }

            // Show the results        
            _livesUi.SetLives(newLivesCount);
            _gameUi.SetInterp(1f, false);
            yield return new WaitForSeconds(_resultDuration);
            
            // All done
            _isLocalRoutine = false;
            _mainRoutine = null;
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