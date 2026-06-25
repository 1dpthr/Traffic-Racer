using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Add this line!
using System.IO;

public class SceneSwitcher : MonoBehaviour
{

    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float speed =1f;

    private void Awake()
    {
      Time.timeScale = 1f;

      if (canvasGroup != null)
      {
        canvasGroup.alpha= 1f;
      }

    }

    private void Start()
    {
      if (canvasGroup != null)
      {
        StartCoroutine(FadeIn());
      }
      }

     IEnumerator FadeIn()
 {
      if (canvasGroup == null)
      {
        yield break;
      }

  while(canvasGroup.alpha>0f)
  {
    canvasGroup.alpha -= speed*Time.unscaledDeltaTime;
    yield return null;
  }
canvasGroup.alpha=0f;

 }

 
 IEnumerator FadeOut(string sceneName )
 {

 if (canvasGroup == null)
 {
  LoadSceneSafely(sceneName);
  yield break;
 }

 while(canvasGroup.alpha<1f)
 {
  canvasGroup.alpha += speed*Time.unscaledDeltaTime;
  yield return null;

 }
  if (!LoadSceneSafely(sceneName))
  {
   // Avoid staying on a black screen if the target scene name is invalid.
   StartCoroutine(FadeIn());
  }

  }
   public void SceneLoader(string sceneName)
   {
   Time.timeScale = 1f;
    StartCoroutine(FadeOut(sceneName));
   }

  public void LoadMainMenu()
  {
   Time.timeScale = 1f;
   SceneManager.LoadScene(0);
  }

   public void QuitGame()
   {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
   }

   bool LoadSceneSafely(string sceneName)
   {
    string resolvedSceneName;
    if (!TryResolveSceneName(sceneName, out resolvedSceneName))
    {
      Debug.LogError("Scene not found in Build Settings: " + sceneName);
      return false;
    }

    SceneManager.LoadScene(resolvedSceneName);
    return true;
   }

   bool TryResolveSceneName(string sceneName, out string resolvedSceneName)
   {
    resolvedSceneName = sceneName;
    if (string.IsNullOrWhiteSpace(sceneName))
    {
      return false;
    }

    string trimmed = sceneName.Trim();
    if (Application.CanStreamedLevelBeLoaded(trimmed))
    {
      resolvedSceneName = trimmed;
      return true;
    }

    for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
    {
      string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
      string buildSceneName = Path.GetFileNameWithoutExtension(scenePath);

      if (string.Equals(buildSceneName, trimmed, System.StringComparison.OrdinalIgnoreCase))
      {
        resolvedSceneName = buildSceneName;
        return true;
      }
    }

    if (string.Equals(trimmed, "MainMenu", System.StringComparison.OrdinalIgnoreCase))
    {
      if (Application.CanStreamedLevelBeLoaded("MainManu"))
      {
        resolvedSceneName = "MainManu";
        return true;
      }
    }

    return false;
   }
}
