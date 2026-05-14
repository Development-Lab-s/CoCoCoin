using System;
using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManageHandler: MonoBehaviour
{
    [SerializeField] private GameObject fadeInOutUI;
    [SerializeField] private Image fadeInOutImage;
    public static SceneManageHandler instance;
    public bool CanMove { get; private set; } = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(fadeInOutUI);
        }
        else
        {
            Destroy(gameObject);
            Destroy(fadeInOutUI);
        }
    }
    
    async public Task MoveScene(int sceneNumber)
    {
        CanMove = false;
        await fadeInOutImage.DOFade(1f, 0.5f).AsyncWaitForCompletion();
        DOTween.KillAll();
        await SceneManager.LoadSceneAsync(sceneNumber);
        Time.timeScale = 1;
        CanMove = true;
        fadeInOutImage.DOFade(0f, 0.5f);
        
    }
}
