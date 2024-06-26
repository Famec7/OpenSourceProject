using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOption : MonoBehaviour
{
    private int _currentWidth;
    private int _currentHeight;
    private bool _isFullScreen;

    #region UI Components

    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private Toggle _fullScreenToggle;
    [SerializeField] private Button _applyButton;

    #endregion

    private void Awake()
    {
        _currentWidth = Screen.width;
        _currentHeight = Screen.height;
        _isFullScreen = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow);

        _resolutionDropdown.value = 0;
        _fullScreenToggle.isOn = _isFullScreen;

        InitUI();
    }

    /// <summary>
    /// UI 컴포넌트에 이벤트를 등록하는 함수
    /// </summary>
    private void InitUI()
    {
        _resolutionDropdown.onValueChanged.AddListener(ChangeResolution);
        _fullScreenToggle.onValueChanged.AddListener(OnClickFullScreenToggle);
        _applyButton.onClick.AddListener(OnClickApply);
    }

    /// <summary>
    /// 드롭다운에서 선택한 해상도에 따라 가로, 세로 해상도를 변경하는 함수
    /// </summary>
    /// <param name="index"></param>
    private void ChangeResolution(int index)
    {
        switch (index)
        {
            case 0:
                _currentWidth = 1920;
                _currentHeight = 1080;
                break;
            case 1:
                _currentWidth = 1280;
                _currentHeight = 720;
                break;
            case 2:
                _currentWidth = 800;
                _currentHeight = 600;
                break;
        }
    }

    /// <summary>
    /// 풀스크린 토글을 클릭했을 때 실행되는 함수
    /// </summary>
    private void OnClickFullScreenToggle(bool isFullScreen)
    {
        this._isFullScreen = isFullScreen;
    }

    /// <summary>
    /// 적용 버튼을 클릭했을 때 실행되는 함수
    /// </summary>
    private void OnClickApply()
    {
#if UNITY_EDITOR
        Debug.Log($"SetResolution: {_currentWidth}x{_currentHeight}, FullScreen: {_isFullScreen}");
#endif
        Screen.SetResolution(_currentWidth, _currentHeight, _isFullScreen);
    }
}