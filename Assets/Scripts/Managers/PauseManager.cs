using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool _isPaused = false;

    #region UI Components
    [SerializeField] Canvas _settingCanvas;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC 키를 누르면 일시정지 (버튼에도 적용)
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

    /// <summary>
    /// 게임을 일시정지하는 함수 (일시정지 후 settingCanvas를 활성화)
    /// </summary>
    public void Pause()
    {
        Time.timeScale = 0;
        _isPaused = true;
        _settingCanvas.enabled = true;
    }

    /// <summary>
    /// 게임을 재개하는 함수 (일시정지 해제 후 settingCanvas를 비활성화)
    /// </summary>
    private void Resume()
    {
        Time.timeScale = 1;
        _isPaused = false;
        _settingCanvas.enabled = false;
    }
}