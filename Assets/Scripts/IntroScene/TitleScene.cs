using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DivisionLike
{
    public class TitleScene : MonoBehaviour
    {
        [SerializeField] private TitleUI m_TitleUI;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Update()
        {
            ProcessKeyInput();
        }
        
        private void ProcessKeyInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {
                Application.Quit();
            }
        }
    }
}