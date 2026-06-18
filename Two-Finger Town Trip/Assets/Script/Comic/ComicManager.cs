using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.InputSystem;

public class ComicManager : MonoBehaviour
{
    [Header("Comic Panel Settings")]
    [SerializeField] private CanvasGroup allCanvas;
    [SerializeField] private List<GameObject> panelList;
    [SerializeField] private float panelFadeDuration = 0.5f;
    [SerializeField] private float delayBetweenPanels = 0.8f;

    [Header("Transition Settings")]
    [SerializeField] private float delayBeforeSceneTransition = 1.0f;
    [SerializeField] private float screenFadeDuration = 0.5f; // Durasi layar menggelap saat pindah scene
    private bool comicFinished = false;
    private bool isTransitioning = false; // Mencegah double-tap saat transisi

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
        comicSequence.OnComplete(() => comicFinished = true);
    }


    public void GoToMainMenu(InputAction.CallbackContext ctx)
    {
        // Hanya jalan jika komik selesai, tombol ditekan, dan TIDAK sedang dalam proses transisi
        if (ctx.performed && comicFinished && !isTransitioning)
        {
            isTransitioning = true; // Kunci input agar tidak terjadi spam klik
            StartCoroutine(TransitionToMainMenu());
        }
    }

    private IEnumerator TransitionToMainMenu()
    {
        // 1. Fade out seluruh UI komik secara halus (alpha menjadi 0)
        if (allCanvas != null)
        {
            allCanvas.DOFade(0f, screenFadeDuration);
        }

        // 2. Beri sedikit jeda waktu tunggu agar animasinya selesai
        yield return new WaitForSeconds(delayBeforeSceneTransition);

        // 3. Pindah ke Scene Main Menu
        SceneController.instance.MainMenuScene();
    }
}