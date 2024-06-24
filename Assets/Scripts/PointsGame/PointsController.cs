using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    
    [Header("Player Components")] 
    [SerializeField] private TMP_Text playerAmount;
    [SerializeField] private Slider playerSlider;
    [Header("Enemy Components")]
    [SerializeField] private TMP_Text enemyAmount;
    [SerializeField] private Slider enemySlider;

    #region Properties
    
        private float _timer;
        private bool _enemyWin = false;
        private bool _playerWin = false;
        private int _enemyAmount = 0;
        private int _playerAmount = 0;

    #endregion

    private void Start()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        _enemyAmount = PlayerPrefs.GetInt("EnemyPoints");
        _playerAmount = PlayerPrefs.GetInt("PlayerPoints");
        
        playerAmount.text = _playerAmount.ToString();
        enemyAmount.text = _enemyAmount.ToString();
        
        playerSlider.value = _playerAmount;
        enemySlider.value = _enemyAmount;
    }
    private void OnEnable()
    {
        EventManager.onDeathEnemy.AddListener(AddPointPlayer);
        EventManager.onDeathPlayer.AddListener(AddPointEnemy);
    }

    private void OnDisable()
    {
        EventManager.onDeathEnemy.RemoveListener(AddPointPlayer);
        EventManager.onDeathPlayer.RemoveListener(AddPointEnemy);
    }

    private void Update()
    {
        if (_enemyWin)
        {
            _timer += Time.deltaTime;

            if (_timer >= 5)
            {
                if (_enemyAmount == 3)
                {
                    loseUI.SetActive(true);
                    PlayerPrefs.DeleteKey("EnemyPoints");
                    PlayerPrefs.DeleteKey("PlayerPoints");
                    Time.timeScale = 0f;
                }
                else
                {
                    EventManager.onReloadLevel.Invoke();
                }
            }
        }
        if (_playerWin)
        {
            _timer += Time.deltaTime;

            if (_timer >= 5)
            {
                if (_playerAmount == 3)
                {
                    winUI.SetActive(true);
                    PlayerPrefs.DeleteKey("EnemyPoints");
                    PlayerPrefs.DeleteKey("PlayerPoints");
                    Time.timeScale = 0f;
                }
                else
                {
                    EventManager.onReloadLevel.Invoke();
                }
            }
        }
        
    }

    private void AddPointEnemy()
    {
        
        _enemyAmount += 1;
        PlayerPrefs.SetInt("EnemyPoints",_enemyAmount);
        enemySlider.value = _enemyAmount;
        enemyAmount.text = _enemyAmount.ToString();
        _enemyWin = true;
    }

    private void AddPointPlayer()
    {
        _playerAmount += 1;
        PlayerPrefs.SetInt("PlayerPoints",_playerAmount);
        playerSlider.value = _playerAmount;
        playerAmount.text = _playerAmount.ToString();
        _playerWin = true;
    }
}
