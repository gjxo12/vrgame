using UnityEngine;
using System.Collections;

public class EnemyCreate : MonoBehaviour
{
    public bool enableSpawn = false;
    public GameObject Enemy; 
    public int EnemyTimeNumber;


    void SpawnEnemy()
    {
        float randomX = Random.Range(-25f, 5f); 
        float randomY = Random.Range(0f, 0f);
        float randomZ = Random.Range(-5f, 3f);

        if (enableSpawn)
        {
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX,randomY, randomZ), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해준다
        }
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 5, EnemyTimeNumber);   //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킨다
    }
    void Update()
    {

    }
}


