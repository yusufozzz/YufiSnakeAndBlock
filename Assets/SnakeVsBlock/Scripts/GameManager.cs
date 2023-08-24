using SnakeVsBlock.Scripts.Snake;
using UnityEngine;

namespace SnakeVsBlock.Scripts
{
    public class GameManager: MonoSingleton<GameManager>
    {
        public bool IsGameStarted { get; set; }

        [field: SerializeField]
        public SnakeController SnakeController { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Application.targetFrameRate = 60;
            Input.multiTouchEnabled = false;
        }
        
        public void StartGame()
        {
            IsGameStarted = true;
            SnakeController.Init();
        }
    }

    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;
        public static T Instance => _instance ? _instance : (_instance = FindObjectOfType<T>());
        
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = (T) this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
        
        protected virtual void OnApplicationQuit()
        {
            _instance = null;
        }
    }
}