using UnityEngine;
using DG.Tweening;

public class UIHoverEffect : MonoBehaviour
{
    private RectTransform rectTransform;

    [Header("Settings")]
    [SerializeField] private float moveDistance = 20f; // Jarak naik turunnya
    [SerializeField] private float duration = 1.5f;     // Waktu untuk satu kali jalan

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Ambil posisi awal Y dari UI
        float startY = rectTransform.anchoredPosition.y;

        // Jalankan animasi DOTween
        rectTransform.DOAnchorPosY(startY + moveDistance, duration)
            .SetEase(Ease.InOutQuad) // Bikin gerakannya mulus di awal dan akhir
            .SetLoops(-1, LoopType.Yoyo); // -1 artinya infinity loop, Yoyo artinya bolak-balik
    }

    private void OnDestroy()
    {
        // Kebiasaan baik: bunuh tween saat objek dihancurkan agar tidak memory leak
        rectTransform.DOKill();
    }
}