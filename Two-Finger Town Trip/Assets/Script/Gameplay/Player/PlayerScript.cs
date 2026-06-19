using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;

    [SerializeField] private float currHealth;
    public float CurrHealth => currHealth;

    private void Start()
    {
        currHealth = MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pastikan collision tidak null
        if (collision == null) return;

        // Gunakan kurung kurawal {} secara tegas untuk mengisolasi logika tag
        if (collision.CompareTag("Damage"))
        {
            TakingDamage(1);
        }
        else if (collision.CompareTag("End"))
        {
            TakingDamage(5);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision != null)
    //    {
    //        if (collision.gameObject.CompareTag("Damage"))
    //            TakingDamage(1);
    //        else if (collision.gameObject.CompareTag("End"))
    //            TakingDamage(5);
    //    }
    //}


    public void TakingDamage(float damage)
    {
        if(SceneController.instance.OnTransition) return;
        currHealth -= damage;
        if(currHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        UIManager.instance.LoseSetUp();
    }
}
