using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;

    [SerializeField] private float currHealth;
    public float CurrHealth => currHealth;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Damage"))
                TakingDamage(1);
            else if (collision.gameObject.CompareTag("End"))
                TakingDamage(5);
        }
    }


    public void TakingDamage(float damage)
    {
        currHealth -= damage;
        if(currHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        Destroy(gameObject);
    }
}
