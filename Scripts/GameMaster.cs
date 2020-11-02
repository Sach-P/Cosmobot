using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    [SerializeField]
    private GameObject gameOverUI;

    private void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public void EndGame()
    {
        gameOverUI.SetActive(true);
    }
    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.EndGame();
    }
    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
