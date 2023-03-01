using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace MicroCombo
{
    public class ComboManager : MonoBehaviour
    {
        // Scenes
        [SerializeField] private string _menuSceneName = "menu_scene";
        [SerializeField] private string _gameSceneName = "combo_scene";

        // References
        [SerializeField] private MicrogameDictionary _dictionary = null;
        public MicrogameDictionary dictionary 
        {
            get { return _dictionary; }
        }

        // Scene references
        [SerializeField] private Camera _camera = null;
        [SerializeField] private EventSystem _eventSystem = null;        
        [SerializeField] private AudioListener _audioListener = null;

        [SerializeField] private TransitionManager _transition = null;

        void Awake()
        {
            // Make sure we survive scene changes
            DontDestroyOnLoad(gameObject);
        }        

        public void GoToMenu()
        {
            // For now, just load the scene
            SceneManager.LoadScene(_menuSceneName, LoadSceneMode.Single);
        }

        public void GoToGame()
        {
            // For now, just load the scene
            SceneManager.LoadScene(_gameSceneName, LoadSceneMode.Single);
        }

        void Update()
        {
            // Input / listeners for pause?


            // Search every frame for audio listeners and event managers
            // Overkill, but less management needed
            RefreshAudioListeners();
            RefreshCameras();
        }

        void LateUpdate()
        {
            RefreshEventManagers();
        }

        private void RefreshCameras()
        {
            // Needs to be at least one on
            Camera[] cameras = GameObject.FindObjectsOfType<Camera>();
            int nonUsCamerasEnabled = 0;
            for (int i = 0; i < cameras.Length; i++)
            {
                if (cameras[i] != _camera &&
                    cameras[i].enabled)
                {
                    nonUsCamerasEnabled++;
                }
            }

            _camera.enabled = nonUsCamerasEnabled <= 0;
        }

        private void RefreshAudioListeners()
        {
            AudioListener[] listeners = GameObject.FindObjectsOfType<AudioListener>(true);

            // Only one can be active - prefer not ours?
            bool isOursActive = listeners.Length == 1;
            int activeCount = 0;

            for (int i = 0; i < listeners.Length; i++)
            {
                bool isOurs = listeners[i] == _audioListener;
                
                bool isEnabled = false;
                if (isOurs &&
                    isOursActive)
                {
                    isEnabled = true;   
                }
                else if (!isOurs &&
                    !isOursActive)
                {
                    isEnabled = true;  
                }
                
                if (activeCount > 0)
                {
                    isEnabled = false;
                }

                listeners[i].enabled = isEnabled;
                if (isEnabled)
                {
                    activeCount++;
                }
            }
        }

        private void RefreshEventManagers()
        {
            EventSystem[] eventSystems = GameObject.FindObjectsOfType<EventSystem>(true);

            // Sometimes ALL are knocked out
            bool allDisabled = _transition.isRunning;

            bool restoreCursor = false;

            if (allDisabled)
            {
                for (int i = 0; i < eventSystems.Length; i++)
                {
                    eventSystems[i].enabled = false;
                }
                restoreCursor = true;
            }
            else
            {
                EventSystem newSystem = null;

                // Picking a new system?
                bool isOursActive = eventSystems.Length == 1;
                // if (_pauseUi.isVisible)
                // {
                //     isOursActive = true;
                // }

                // Just get the reference
                for (int i = 0; i < eventSystems.Length; i++)
                {
                    bool isOurs = eventSystems[i] == _eventSystem;

                    bool isEnabled = false;
                    if (isOurs && 
                        isOursActive)
                    {
                        isEnabled = true;
                    }
                    else if (!isOurs &&
                        !isOursActive)
                    {
                        isEnabled = true;   
                    }    

                    if (isEnabled)
                    {
                        newSystem = eventSystems[i];
                        break;
                    }
                }

                if (newSystem != EventSystem.current)
                {
                    // Turn all off
                    for (int i = 0; i < eventSystems.Length; i++)
                    {
                        eventSystems[i].enabled = false;
                    }

                    // Turn only this on
                    if (newSystem != null)
                    {
                        newSystem.enabled = true;
                    }
                }

                // If our system is enabled, restore default controls
                if (newSystem == _eventSystem)
                {
                    restoreCursor = true;
                }
            }

            if (restoreCursor)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        public static string GetSafeSceneName(string path)
        {
            string ret = path;

            // This helps us survive webGL builds
            if (path.Contains(".unity"))
            {
                string[] splits = path.Split("/");
                string[] endSplits = splits[splits.Length - 1].Split(".");
                ret = endSplits[0];
            }

            return ret;          
        }
    }
}