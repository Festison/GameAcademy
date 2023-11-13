using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance = null;
    bool isPaused;
    public event Action onPause;
    public event Action onResume;

    public bool IsPaused
    {
        get { return isPaused; }
        set
        {
            isPaused = value;
            if (isPaused)
                Pause();
            else
                Resume();
        }
    }
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    public void ChangePauseState()
    {
        IsPaused = !IsPaused;
    }

    public void Pause()
    {
        onPause();
    }
    public void Resume()
    {
        onResume();
    }
}
