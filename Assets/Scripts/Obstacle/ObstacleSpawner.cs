using UnityEngine;
using UnityEngine.Serialization;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("스폰 간격")]
    [SerializeField] private float _spawnInterval;
    
    [Header("스폰 위치(조정하지 말 것)")]
    [SerializeField] private Vector3 _spawnPosition;
    
    [Header("장애물 종류")]
    [SerializeField]
    private string[] _obstacleTypes;

    private float _spawnTimer = 0f;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnInterval)
        {
            _spawnTimer = 0f;
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        // 장애물 종류 중 랜덤으로 선택
        int type = Random.Range(0, _obstacleTypes.Length);

        Debug.Log(type);
        
        Obstacle obstacle = ObjectPoolManager.Instance.GetObject<Obstacle>(_obstacleTypes[type]);
        if (obstacle == null) return;

        // 장애물 위치 조정
        var vector3 = obstacle.transform.position;
        vector3.x = _spawnPosition.x;
        obstacle.transform.position = vector3;
    }
}