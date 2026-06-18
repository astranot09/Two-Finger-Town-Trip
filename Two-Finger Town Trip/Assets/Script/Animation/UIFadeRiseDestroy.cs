using UnityEngine;
using DG.Tweening; // Jangan lupa namespace DOTween

[RequireComponent(typeof(CanvasGroup))]
public class UIFadeRiseDestroy : MonoBehaviour
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [Header("Movement Settings")]
    [SerializeField] private float moveDistance = 100f; // Total jarak bergerak ke atas
    [SerializeField] private float totalDuration = 2.0f; // Total waktu dari muncul sampai hilang

    [Header("Fade Settings")]
    [Range(0, 1)]
    [SerializeField] private float fadeInDurationPercent = 0.2f; // 20% dari total waktu untuk Fade In
    [Range(0, 1)]
    [SerializeField] private float fadeOutDurationPercent = 0.3f; // 30% dari total waktu untuk Fade Out

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        // 1. Setup kondisi awal (posisi awal, dan alpha mulai dari 0)
        float startY = rectTransform.anchoredPosition.y;
        canvasGroup.alpha = 0f;

        // Hitung durasi nyata berdasarkan persentase
        float fadeInDuration = totalDuration * fadeInDurationPercent;
        float fadeOutDuration = totalDuration * fadeOutDurationPercent;
        float stayDuration = totalDuration - (fadeInDuration + fadeOutDuration);

        // 2. Buat DOTween Sequence
        Sequence mySequence = DOTween.Sequence();

        // --- ANIMASI BERGERAK (Berjalan terus dari awal sampai akhir) ---
        mySequence.Join(rectTransform.DOAnchorPosY(startY + moveDistance, totalDuration).SetEase(Ease.OutQuad));

        // --- ANIMASI FADE IN (Mulai dari awal) ---
        mySequence.Join(canvasGroup.DOFade(1f, fadeInDuration).SetEase(Ease.InQuad));

        // --- ANIMASI FADE OUT (Berjalan setelah Fade In + Waktu Diam selesai) ---
        float delayBeforeFadeOut = fadeInDuration + stayDuration;
        mySequence.Insert(delayBeforeFadeOut, canvasGroup.DOFade(0f, fadeOutDuration).SetEase(Ease.OutQuad));

        // 3. ON COMPLETE -> Hancurkan GameObject
        mySequence.OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    private void OnDestroy()
    {
        // Supaya aman dan tidak memory leak jika objek dihancurkan manual sebelum kelar
        rectTransform.DOKill();
        canvasGroup.DOKill();
    }
}