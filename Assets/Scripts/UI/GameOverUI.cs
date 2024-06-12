using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    
    private void Start()
    {
        _restartButton.onClick.AddListener(() =>
        {
            SceneController.Instance.LoadScene(SceneName.InGame);
        });
        
        _exitButton.onClick.AddListener(Application.Quit);
    }
}