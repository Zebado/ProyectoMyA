using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool winGame { get; private set; } = false;

    [SerializeField] GameObject _hudLanguage;
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
    private void OnEnable()
    {
        EventManager.SusbcribeToEvent(EventsType.Event_Win, WinGame);
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
        UnityEditor.EditorApplication.isPlaying = false;
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
