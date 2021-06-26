using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{

    [SerializeField]
    WaveSpawner spawner;

    [SerializeField]
    Animator waveAnimator;

    [SerializeField]
    Text waveCountText;

    [SerializeField]
    Text waveText;

    void Update()
    {
        if(spawner.NextWave == (spawner.waves.Length))
        {
            waveText.text = "WAVES";
            waveCountText.text = "COMPLETE";
            waveCountText.color = Color.green;
        }
        else if (spawner.NextWave == (spawner.waves.Length - 1))
        {
            waveCountText.text = "BOSS";
        }
        else
        {
            waveCountText.text = spawner.NextWave + "." + spawner.NewGamePlus;
            waveCountText.color = Color.red;
            waveText.text = "WAVE";
        }

        if (spawner.State == WaveSpawner.SpawnState.counting)
        {
            waveAnimator.SetBool("WaveInComing", true);
        }
        else
        {
            waveAnimator.SetBool("WaveInComing", false);
        }

    }

    
}
