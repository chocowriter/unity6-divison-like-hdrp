using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DivisionLike
{
    /// <summary>
    /// 인트로 씬
    /// </summary>
    public class TitleScene : MonoBehaviour
    {
        [SerializeField] private TitleUI mTitleUI;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Update()
        {
            ProcessKeyInput();
        }

        /// <summary>
        /// 키 입력 처리
        /// </summary>
        private void ProcessKeyInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                Application.Quit();
            }

            if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetKeyDown(KeyCode.Return) == true)
            {
                mTitleUI.LoadPlayScene();
            }
        }
    }
}