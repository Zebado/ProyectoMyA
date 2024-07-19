using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoPlayer : MonoBehaviour, IMemento, ICheckpointTrigger, IRespawneable
{
    private Vector3 position;
    private LifePlayerHandler lifeHandler;

    private void Awake()
    {
        lifeHandler = GetComponent<LifePlayerHandler>();
        position = transform.position;
        GameManager.Instance.RegisterIMemento(this);
    }

    public void SetPosition(Vector3 newPosition)
    {
        position = newPosition;
        transform.position = position;
    }

    public Memento SaveState()
    {
        position = transform.position;
        return new Memento(position, lifeHandler.currentLife);
    }

    public void RestoreState(Memento memento)
    {
        SetPosition(memento.PlayerPosition);
        lifeHandler.SetCurrentLife(memento.PlayerHealth);
    }
    public void ActivateCheckpoint()
    {
        GameManager.Instance.SaveCheckPoint();
        Debug.Log("Checkpoint activated by player.");
    }
    private void OnDestroy()
    {
        GameManager.Instance.UnregisterIMemento(this);
    }

    public void Respawn()
    {
        GameManager.Instance.LoadCheckPoint();
    }
}
