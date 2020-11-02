using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {spawning, waiting, counting}
    
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public Transform enemy2;
        public int count;
        public float rate = 1f;
        public int range;

    }

    public Wave[] waves;
    private int nextWave = 0;
    public int NextWave
    {
        get { return nextWave+1; }
    }

    private int newGamePlus = 0;
    public int NewGamePlus
    {
        get { return newGamePlus; }
    }

    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;

    public bool bossBattle;



    private float waveCountDown;
    private float endCountDown;

    private float searchEnemy = 1f;

    public SpawnState state = SpawnState.counting;
    public SpawnState State
    {
        get { return state; }
    }

    private void Start()
    {
        waveCountDown = timeBetweenWaves;

    }

    bool EnemyIsThere()
    {
        searchEnemy -= Time.deltaTime;

        if (searchEnemy <= 0f)
        {
            searchEnemy = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {              
                return false;
            }

        }


        return true;
    }

    void Update()
    {
        if (state == SpawnState.waiting)
        {
            if (!EnemyIsThere())
            {

               WaveCompleted(); 
                
            }
            else
            {
                return;
            }
        }

       
            if (waveCountDown <= 0)
            {
                if (state != SpawnState.spawning)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountDown -= Time.deltaTime;
            }
        
        
        
    }


    void WaveCompleted()
    {
        Debug.Log("Wave Completed");
        state = SpawnState.counting;
        waveCountDown = timeBetweenWaves;
  
        if (nextWave + 1 > waves.Length - 1)
        {
             bossBattle = true;
             nextWave = 0;
             newGamePlus++;
             
        }
        else
        {
             nextWave++;
             bossBattle = false;

        }                
        
    }




    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.spawning;

        for(int i = 0; i < _wave.count; i++)
        {
            if(Random.Range(1,256) <= _wave.range)
            {
                SpawnEnemy(_wave.enemy2);
                yield return new WaitForSeconds(_wave.rate);
            }
            else
            {
                SpawnEnemy(_wave.enemy);
                yield return new WaitForSeconds(_wave.rate);
            }
            
        }

      

        state = SpawnState.waiting;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
