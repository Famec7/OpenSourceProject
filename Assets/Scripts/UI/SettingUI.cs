using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private Button _lobbyButton;
    
    private void Start()
    {
        _lobbyButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneController.Instance.LoadScene(SceneName.Lobby);
        });
    }
}