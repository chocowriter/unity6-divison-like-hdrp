using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace DivisionLike
{
    /// <summary>
    /// 인트로 화면 GUI
    /// </summary>
    public class TitleUI : MonoBehaviour
    {
        [SerializeField] private Button m_SinglePlayButton;
        [SerializeField] private Button m_MultiPlayButton;
        [SerializeField] private Button m_TrainingButton;
        [SerializeField] private Button m_OptionButton;
        [SerializeField] private Button m_GithubButton;
        [SerializeField] private Button m_QuitButton;
        
        [SerializeField] private GameObject m_LoadingScreen;

        #region MonoBehaviour

        private void Awake()
        {
            m_SinglePlayButton.onClick.AddListener(OnClickSinglePlayButton);
            m_MultiPlayButton.onClick.AddListener(OnClickMultiButton);
            m_TrainingButton.onClick.AddListener(OnClickTrainingButton);
            m_OptionButton.onClick.AddListener(OnClickOptionButton);
            m_GithubButton.onClick.AddListener(OnClickGithubButton);
            m_QuitButton.onClick.AddListener(OnClickQuitButton);
        }

        #endregion

        private void OnClickSinglePlayButton()
        {
            LoadPlayScene();
        }

        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void OnClickMultiButton()
        {
        }

        private void OnClickTrainingButton()
        {
            SceneController.instance.LoadScene(SceneName.Training);
        }

        private void OnClickOptionButton()
        {
        }

        private void OnClickGithubButton()
        {
            Application.OpenURL("https://github.com/chocowriter/unity6-divison-like-hdrp");
        }

        private void OnClickQuitButton()
        {
            Application.Quit();
        }

        /// <summary>
        /// 플레이 씬을 불러들인다.
        /// </summary>
        public void LoadPlayScene()
        {
            m_LoadingScreen.SetActive(true);

            SceneManager.sceneLoaded += LoadedSceneComplete;

            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
        {
            SceneName sceneName = SceneName.SinglePlay;
            
            AsyncOperation operation = SceneController.instance.LoadSceneAsyn(sceneName);
            operation.allowSceneActivation = false;

            float timer = 0f;
            while (operation.isDone == false)
            {
                yield return null;
                timer += Time.deltaTime;

                if (operation.progress < 0.9f)
                {
                }
                else
                {
                    operation.allowSceneActivation = true;

                    yield break;
                }
            }

            yield break;
        }

        /// <summary>
        /// 씬을 불러들이는 작업이 완료되면 처리할 작업들
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="loadSceneMode"></param>
        private void LoadedSceneComplete(Scene scene, LoadSceneMode loadSceneMode)
        {
            if (scene.name == SceneController.instance.CurrentScene.ToString())
            {
                SceneManager.sceneLoaded -= LoadedSceneComplete;
            }
        }
    }
}