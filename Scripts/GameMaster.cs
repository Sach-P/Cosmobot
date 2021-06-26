
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    [SerializeField]
    private GameObject gameOverUI;

    public GameAudioManager gameAudioManager;

    private void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public void EndGame()
    {
        FindObjectOfType<UI>().GameOver();
    }
    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.gameAudioManager.Play("Gameover");
        gm.EndGame();
    }
    public static void KillEnemy(Enemy enemy, int size)
    {
        if(size == 1){
            gm.gameAudioManager.Play("SmallDeath");
        }
        else if(size == 2){
            gm.gameAudioManager.Play("BigDeath");
        }
        else if(size == 3){
            gm.gameAudioManager.Play("Boss");
        }
        Destroy(enemy.gameObject);
    }
}
