using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MicroCombo
{
    public class SequenceManager : MonoBehaviour
    {
        // UI information
        [SerializeField] private SequenceScreen _screen = null;
        [SerializeField] private SequenceTransition _transition = null;        
        
        // Scene loading / unloading
        private string _loadedSceneName = string.Empty;   

        private bool _isMicrogameLoadPending = false;   
        private bool _isMicrogameUnloadPending = false;   

        public enum SequenceStep
        {
            None,
            Loading,
            Loaded,
            Results,
            Unloading
        }

        private SequenceStep _currentStep = SequenceStep.None;
        public SequenceStep step
        {
            get { return _currentStep; }
        }

        // Main coroutine
        private Coroutine _mainRoutine = null;
        private bool _isRoutineRunning = false;
        public bool isRunning
        {
            get { return _isRoutineRunning || (_mainRoutine != null); }
        }
        
        private int _livesRemaining = 4;
        private bool _isGameOver
        {
            get { return _livesRemaining <= 0; }
        }

        private List<MicrogameData> _originalDatas = new List<MicrogameData>();
        private List<MicrogameData> _dataQueue = new List<MicrogameData>();

        private ComboManager _comboManager = null;
        
        void Start()
        {
            _comboManager = GameObject.FindObjectOfType<ComboManager>();

            // No one started us?  Kickoff a routien
            if (!isRunning)
            {                
                List<MicrogameData> games = new List<MicrogameData>();
                _comboManager.dictionary.GetDatas(ref games, string.Empty, false, -1);

                Setup(games);
                StartSequence();
            }
        }

        public void Setup(List<MicrogameData> datas)
        {
            // Copy over the data
            _originalDatas.Clear();
            _originalDatas.AddRange(datas);

            // Prep the screen / UI?
            _transition.Hide(true);
        }

        public void StartSequence()
        {
            // We need to kickoff a "clean up" routine if we're already running
            if (isRunning)
            {
                StartCoroutine(ExecuteRestart());
            }
            else
            {
                _mainRoutine = StartCoroutine(ExecuteMainRoutine());
            }
        }

        private IEnumerator ExecuteRestart()
        {   
            // Stop the routine
            if (_mainRoutine != null)
            {
                StopCoroutine(_mainRoutine);
                _mainRoutine = null;
            }
            _isRoutineRunning = false;

            // Stop all children routines
            _screen.Stop();
            _transition.Stop();
            
            // Wait for unloads
            while (_isMicrogameLoadPending)
            {
                yield return null;
            }

            // Then unload any remaining
            if (_isMicrogameUnloadPending)
            {
                SceneManager.sceneUnloaded += OnMicrogameUnloaded;
                SceneManager.UnloadSceneAsync(_loadedSceneName);

                while (_isMicrogameUnloadPending)
                {
                    yield return null;
                }
            }

            // End by starting the main routine
            _mainRoutine = StartCoroutine(ExecuteMainRoutine());
        }

        private IEnumerator ExecuteMainRoutine()
        {
            // Initialize values
            _dataQueue.Clear();

            _livesRemaining = 4;
            _screen.Init(_livesRemaining);        

            // At this point the screen is safe to show
            
            // Intro sequence

            // Run the routine
            while (!_isGameOver)
            {
                // Pick a game
                MicrogameData data = PickNewData();

                // Intro sequence
                _screen.QueueGame(data);
                while (_screen.isRunning)
                {
                    yield return null;
                }

                // Load
                _currentStep = SequenceStep.Loading;      
                _loadedSceneName = ComboManager.GetSafeSceneName(data.GetScenePath());
                SceneManager.LoadSceneAsync(_loadedSceneName, LoadSceneMode.Additive);
                while (_isMicrogameLoadPending)
                {
                    yield return null;
                }

                // Play
                _currentStep = SequenceStep.Loaded;    
                _transition.Show(false);
                while (_transition.isRunning)
                {
                    yield return null;
                }

                // Wait for a result (or for the game to time out)
                bool isGameWon = false;

                EgamMicrogameInstance microgameInstance = GameObject.FindObjectOfType<EgamMicrogameInstance>();
                if (microgameInstance != null)
                {
                    while (!microgameInstance.isGameOver)
                    {
                        yield return null;
                    }

                    isGameWon = (microgameInstance.result == EgamMicrogameHelper.WinLose.Win);
                }
                else
                {
                    float timeoutT = 0;
                    while (timeoutT < data.timeoutDuration)
                    {
                        yield return null;
                        timeoutT += Time.deltaTime;
                    }
                }
                
                _currentStep = SequenceStep.Results;    

                // Return to the screen
                _transition.Hide(false);
                while (_transition.isRunning)
                {
                    yield return null;
                }

                // Display the results
                if (!isGameWon)
                {
                    _livesRemaining--;
                }

                _screen.SetResults(isGameWon, _livesRemaining);
                while (_screen.isRunning)
                {
                    yield return null;
                }

                // Unload the scene
                _currentStep = SequenceStep.Unloading;
                SceneManager.UnloadSceneAsync(_loadedSceneName);
                while (_isMicrogameUnloadPending)
                {
                    yield return null;
                }

                // Finished with the loop
                _currentStep = SequenceStep.None;                
            }

            // All done = end the routine
            _mainRoutine = null;

            _comboManager.GoToMenu();
        }

        private MicrogameData PickNewData()
        {
            // Take histry into account?
            if (_dataQueue.Count <= 0)
            {
                _dataQueue.AddRange(_originalDatas);                
            }

            int randomIndex = Random.Range(0, _dataQueue.Count);
            MicrogameData data = _dataQueue[randomIndex];
            _dataQueue.RemoveAt(randomIndex);

            return data;
        }

        private void OnMicrogameLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == _loadedSceneName)
            {
                SceneManager.SetActiveScene(scene);

                SceneManager.sceneLoaded -= OnMicrogameLoaded;
                _isMicrogameLoadPending = false;
            }
        }

        private void OnMicrogameUnloaded(Scene scene)
        {
            if (scene.name == _loadedSceneName)
            {
                SceneManager.sceneUnloaded -= OnMicrogameUnloaded;

                _loadedSceneName = string.Empty;
                _isMicrogameUnloadPending = false;
            }
        }
    }
}