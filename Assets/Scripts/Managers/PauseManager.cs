using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;

    #region UI Components
    [SerializeField] Canvas _settingCanvas;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _isPaused = true;
        _settingCanvas.enabled = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;
        _isPaused = false;
        _settingCanvas.enabled = false;
    }
}