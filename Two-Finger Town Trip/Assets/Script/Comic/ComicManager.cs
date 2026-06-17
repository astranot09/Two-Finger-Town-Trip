using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class ComicManager : MonoBehaviour
{
    [Header("Comic Panel Settings")]
    [SerializeField] private List<GameObject> panelList;
    [SerializeField] private float panelFadeDuration = 0.5f;
    [SerializeField] private float delayBetweenPanels = 0.8f;

    [Header("Transition Settings")]
    [SerializeField] private float delayBeforeSceneTransition = 1.0f;

    private void Start()
    {
        InitializeComic();
    }

    public void InitializeComic()
    {
        // 1. Sembunyikan semua panel komik di awal dan reset Alpha
        foreach (GameObject panel in panelList)
        {
            panel.SetActive(false);

            CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0f;
            }
        }

        // 2. Mulai sekuens animasi komik
        PlayComicSequence();
    }

    private void PlayComicSequence()
    {
        Sequence comicSequence = DOTween.Sequence();

        foreach (GameObject panel in panelList)
        {
            CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

            if (canvasGroup != null)
            {
                // Aktifkan panel, lalu mainkan efek fade in
                comicSequence.AppendCallback(() => panel.SetActive(true));
                comicSequence.Append(canvasGroup.DOFade(1f, panelFadeDuration).SetEase(Ease.OutQuad));
                comicSequence.AppendInterval(delayBetweenPanels);
            }
            else
            {
                // Fail-safe jika CanvasGroup lupa dipasang
                comicSequence.AppendCallback(() => panel.SetActive(true));
                comicSequence.AppendInterval(delayBetweenPanels);
                Debug.LogWarning($"Objek '{panel.name}' tidak memiliki CanvasGroup! Efek fade tidak aktif.");
            }
        }

        // Setelah seluruh sekuens komik selesai, jalankan transisi scene
        comicSequence.OnComplete(() => StartCoroutine(TransitionToMainMenu()));
    }

    private IEnumerator TransitionToMainMenu()
    {
        yield return new WaitForSeconds(delayBeforeSceneTransition);
        SceneController.instance.MainMenuScene();
    }
}