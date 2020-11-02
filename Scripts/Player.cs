using UnityEngine;


public class Player : MonoBehaviour
{
   [System.Serializable]
   public class PlayerStats{
        public int Health = 100;
        public int maxHealth = 100;
    }

    [SerializeField]
    private PlayerUI playerUI;

    public PlayerStats playerStats = new PlayerStats();

    public GameObject destEffect;

    public int fallBoundry = -20;

    private void Start()
    {
        playerUI.SetHealth(playerStats.Health, playerStats.maxHealth);
    }

    void Update()
    {
        
        if (transform.position.y <= fallBoundry)
        {
            DamagePlayer(99999);
        }
        if (playerStats.Health <= 0)
        {
            
            GameMaster.KillPlayer(this);
            Instantiate(destEffect, transform.position, Quaternion.identity);
          
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        

        if(playerUI != null)
        {
            playerUI.SetHealth(playerStats.Health, playerStats.maxHealth);
        }
    }

   
}
