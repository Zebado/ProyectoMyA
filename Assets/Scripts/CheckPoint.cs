using TMPro;
using UnityEngine;


public class CheckPoint : MonoBehaviour
{
    bool _IsTrigger;
    PInputManager _inputManager;
    [SerializeField] GameObject _text;
    bool _checkpoint;
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
        _checkpoint = false;
        _inputManager = FindAnyObjectByType<PInputManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_checkpoint)
        {
            _text.SetActive(true);
            _checkpoint = true;
            _IsTrigger = true;
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
