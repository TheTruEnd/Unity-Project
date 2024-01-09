using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable once CheckNamespace
namespace GameTool
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class LoadSceneManager : SingletonMonoBehaviour<LoadSceneManager>
    {
        public const string nameSceneSpl = "SPL";
        public const string nameSceneHome = "HomeScene";
        public const string nameSceneGame = "GameScene";

        protected override void Awake()
        {
            base.Awake();
            this.PostEvent(eEventType.SceneLoaded);
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadAsyncScene(sceneName));
        }

        public void LoadSceneSpl()
        {
            StartCoroutine(LoadAsyncScene(nameSceneSpl));
        }

        public void LoadSceneHome()
        {
            StartCoroutine(LoadAsyncScene(nameSceneHome));
        }

        public void LoadSceneGame()
        {
            StartCoroutine(LoadAsyncScene(nameSceneGame));
        }

        protected IEnumerator LoadAsyncScene(string nameScene)
        {
            yield return TransistionFX.Instance.OnLoadScene();
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameScene);
            this.PostEvent(eEventType.SceneLoaded);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            TransistionFX.Instance.EndLoadScene();
        }
    }
}