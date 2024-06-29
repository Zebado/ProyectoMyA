using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool winGame { get; private set; } = false;

    [SerializeField] GameObject _hudLanguage;
    Stack<Memento> _checkpoints = new Stack<Memento>();
    MementoPlayer _player;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _player = FindObjectOfType<MementoPlayer>();
    }
    private void OnEnable()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_Win, WinGame);
    }
    public void LoadCheckPoint()
    {
        if (_checkpoints.Count > 0)
        {
            Memento memento = _checkpoints.Pop();
            _player.RestoreState(memento);
        }
    }
    public void SaveCheckPoint()
    {
        if (_player != null)
        {
            Memento memento = _player.SaveState();
            _checkpoints.Push(memento);
        }
    }
    public void ChangeScene()
    {
        winGame = false;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (currentSceneIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void WinGame(object[] parameters)
    {
        winGame = true;
    }
    private void OnDisable()
    {
        EventManager.UnsusbcribeToEvent(EventsType.Event_Win, WinGame);
    }
}
