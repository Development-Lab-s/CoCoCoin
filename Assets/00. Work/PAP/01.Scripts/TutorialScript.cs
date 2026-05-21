using System;
using UnityEngine;

namespace _00._Work.PAP._01.Scripts
{
    public class TutorialScript : MonoBehaviour
    {
        private int currentTuto = 1;
        private void ClearTuto()
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }

        private void ShowTuto()
        {
            gameObject.transform.Find(currentTuto.ToString()).gameObject.SetActive(true);
        }

        private void Start()
        {
            ClearTuto();
            ShowTuto();
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentTuto++;
                sss();
            }
            else if (Input.GetMouseButtonUp(1))
            {
                currentTuto = Mathf.Max(currentTuto-1,1);
                sss();
            }
        }

        private void sss()
        {
            if (currentTuto > transform.childCount)
            {
                _ = SceneManageHandler.instance.MoveScene(1);
            }
            else
            {
                ClearTuto();
                ShowTuto();
            }
        }
    }
}