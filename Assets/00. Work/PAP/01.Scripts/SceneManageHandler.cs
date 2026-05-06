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
        await fadeInOutImage.DOFade(1f, 0.5f).AsyncWaitForCompletion();
        await SceneManager.LoadSceneAsync(sceneNumber);
        fadeInOutImage.DOFade(0f, 0.5f);
        
    }
}
