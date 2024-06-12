using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField]
    private Button _inGameButton;
    [SerializeField]
    private Button _exitButton;
    
    private void Start()
    {
        _inGameButton.onClick.AddListener(() =>
        {
            SceneController.Instance.LoadScene(SceneName.InGame);
        });
        
        _exitButton.onClick.AddListener(Application.Quit);
    }
}