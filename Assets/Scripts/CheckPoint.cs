using TMPro;
using UnityEngine;


public class CheckPoint : MonoBehaviour
{
    bool _IsTrigger;
    PInputManager _inputManager;
    [SerializeField] GameObject _text;
    private void OnEnable()
    {
        _inputManager.OnCheckPoint += CheckPointOn;
        GameManager.Instance.SaveCheckPoint();
    }
    private void OnDisable()
    {
        _inputManager.OnCheckPoint -= CheckPointOn;
    }
    private void Awake()
    {
        _inputManager = FindAnyObjectByType<PInputManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _text.SetActive(true);
            _IsTrigger = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _IsTrigger = false;
        }
    }
    public void CheckPointOn()
    {
        if (_IsTrigger)
        {
            GameManager.Instance.SaveCheckPoint();
            Debug.Log("CheckPoint Saved");
            _text.SetActive(false);
        }
    }
}
