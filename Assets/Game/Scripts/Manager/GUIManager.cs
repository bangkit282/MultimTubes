using TMPro;
using UnityEngine;

namespace MultimTubes
{
    public class GUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TextMeshProUGUI _coinText;

        private void OnEnable()
        {
            GameEventManager.OnGameOverEvent += DisplayGameOverPanel;
            GameEventManager.OnCoinAddEvent += UpdateCoinText;
        }

        private void OnDisable()
        {
            GameEventManager.OnGameOverEvent -= DisplayGameOverPanel;
            GameEventManager.OnCoinAddEvent -= UpdateCoinText;
        }

        public void DisplayWinPanel()
        {
            _winPanel.SetActive(true);
        }

        private void DisplayGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }

        private void UpdateCoinText(int coinValue)
        {
            _coinText.text = coinValue.ToString("00000");
        }
    }
}
