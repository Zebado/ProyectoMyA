using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool winGame { get; private set; } = false;

    [SerializeField] GameObject _hudLanguage;
    GameObject _victoryHud;
    Stack<Memento> _checkpoints = new Stack<Memento>();
    List<IMemento> _iMemento = new List<IMemento>();

    Dictionary<EnemyRace, int> enemiesKilled = new Dictionary<EnemyRace, int>
    {
        {EnemyRace.Melee, 0 },
        {EnemyRace.Range, 0 }
    };
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
        SaveInitialCheckpoint();
        GameObject hudObject = GameObject.Find("HUD");
        if (hudObject != null)
        {
            _victoryHud = hudObject.transform.Find("Win")?.gameObject;
            if (_victoryHud != null)
            {
                _victoryHud.SetActive(false);
            }
        }
    }
    public void RegisterIMemento(IMemento memento)
    {
        if (!_iMemento.Contains(memento))
        {
            _iMemento.Add(memento);
        }
    }
    public void UnregisterIMemento(IMemento memento)
    {
        if (_iMemento.Contains(memento))
        {
            _iMemento.Remove(memento);
        }
    }
    private void OnEnable()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_Win, WinGame);
    }
    public void LoadCheckPoint()
    {
        if (_checkpoints.Count > 0)
        {
            Memento memento = _checkpoints.Peek();
            foreach (var mementoOrigin in _iMemento)
            {
                mementoOrigin.RestoreState(memento);
            }
        }
    }
    private void SaveInitialCheckpoint()
    {
        if (_checkpoints.Count == 0 && _iMemento.Count > 0)
        {
            foreach (var mementoOrigin in _iMemento)
            {
                Memento initialMemento = mementoOrigin.SaveState();
                _checkpoints.Push(initialMemento);
                Debug.Log("Initial checkpoint saved.");
            }
        }
    }
    public void SaveCheckPoint()
    {
        foreach (var mementoOrigin in _iMemento)
        {
            Memento memento = mementoOrigin.SaveState();
            _checkpoints.Push(memento);
        }
    }
    public void EnemyKilled(EnemyRace race)
    {
        if (enemiesKilled.ContainsKey(race))
            enemiesKilled[race]++;
        else
            enemiesKilled[race] = 1;
        ViewResume();
    }

    private void ViewResume() //usamos aggregate para recorrer nuestro diccionario y luego un lo pasamos como un unico resultado por un tipo anonimo para no definir una clase.
    {
        var resume = enemiesKilled.Aggregate(new { Melee = 0, Range = 0 }, (acumulador, key) =>
        {
            return key.Key == EnemyRace.Melee ?
               new { Melee = acumulador.Melee + key.Value, acumulador.Range } :
               new { acumulador.Melee, Range = acumulador.Range + key.Value };
        });
        Debug.Log($"Enemigos Melee derrotados: {resume.Melee}, Enemigos Rango derrotados: {resume.Range}");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ChangeScene()
    {
        winGame = false;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % 4;
        SceneManager.LoadScene(nextSceneIndex);
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

    internal void PlayerReachedDoor()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 3)
        {
            winGame = true;
            if (_victoryHud != null)
            {
                _victoryHud.SetActive(true);
            }
        }
        else
        {
            ChangeScene();
        }
    }
}
