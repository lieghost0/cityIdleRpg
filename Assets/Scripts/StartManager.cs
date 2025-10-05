using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject mainGamePanel;
    public GameObject gameTips;
    public CanvasGroup gameTipsCanvasGroup;

    public Transform[] layers;

    private float fadeDuration = 2f;// 淡入淡出的持续时间
    private float initTime = 0f;// 初始时间

    private void Start()
    {
        this.mainGamePanel.SetActive(false);
        this.startPanel.SetActive(false);
        StartCoroutine(EnterGame());
    }

    IEnumerator EnterGame()
    {
        yield return ShowGameTips();

        LayerManager.Instance.Init(this.layers);
        yield return DataManager.Instance.LoadData();

        this.startPanel.SetActive(true);
    }

    /// <summary>
    /// 渐变显示并隐藏游戏提示
    /// </summary>
    IEnumerator ShowGameTips()
    {
        float elapsedTime = initTime;
        gameTips.SetActive(true);
        // 渐变展示效果
        gameTipsCanvasGroup.alpha = 0f;
        while (elapsedTime < fadeDuration)
        {
            gameTipsCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameTipsCanvasGroup.alpha = 1f;
        yield return new WaitForSeconds(fadeDuration);

        // 渐变消失效果
        elapsedTime = initTime;
        while (elapsedTime < fadeDuration)
        {
            gameTipsCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        gameTipsCanvasGroup.alpha = 0f;
        gameTips.SetActive(false);
    }
}
