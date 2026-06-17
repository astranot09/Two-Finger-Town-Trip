using UnityEngine;

public class GedungScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private Collider2D triggerCollider; 
    
    private bool sudahSpawn = false;
    private bool destroyIt = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.MovePosition(rb.position + Vector2.left * Time.deltaTime * GameplayManager.instance.ObstacleSpeed);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (destroyIt) return;

        if (collision.CompareTag("Spawner") && !sudahSpawn)
        {
            // Trik: Kita cek apakah 'triggerColliderKhusus' milik kita ini sudah TIDAK menyentuh spawner lagi
            // Jika collider spesifik ini yang keluar, maka fungsi IsTouching akan bernilai false
            if (!collision.IsTouching(triggerCollider))
            {
                sudahSpawn = true; // Tetap gunakan flag perlindungan agar anti-spam
                GedungSpawner.instance.SpawningObstacle();
            }
        }

        if (collision.CompareTag("Delete") && sudahSpawn)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                // Kalau ternyata ga punya parent, hancurin dirinya sendiri aja
                Destroy(gameObject);
            }
        }
    }
    private void OnApplicationQuit()
    {
        destroyIt = true;
    }
}
