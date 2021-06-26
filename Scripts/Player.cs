using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;


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

    public Light2D playerLight;
    public Color healthColor;
    public Color damageColor;

    public int healthDrop;

    public int fallBoundry = -20;

    private void Start()
    {
        playerLight = GetComponent<Light2D>();
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
        playerLight.color = damageColor;
        
        StartCoroutine(WaitForSeconds());
        if(playerUI != null)
        {
            playerUI.SetHealth(playerStats.Health, playerStats.maxHealth);
        }

    }

    public void AddHealth(){
        playerStats.Health += healthDrop;
        playerLight.color = healthColor;

        if(playerStats.Health >= 100){
            playerStats.Health = 100;
        }

        if(playerUI != null)
        {
            playerUI.SetHealth(playerStats.Health, playerStats.maxHealth);
        }
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Health"){
            AddHealth();
            Destroy(other.gameObject);
            AudioManager.instance.Play("Health");
            playerLight.color = healthColor;
            StartCoroutine(WaitForSeconds());
        }
    }

    IEnumerator WaitForSeconds()
    {
        playerLight.intensity = 1f;
        yield return new WaitForSecondsRealtime(0.35f);
        playerLight.intensity = 0f;

    }
   
}
