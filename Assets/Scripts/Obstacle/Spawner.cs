using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [Header("스폰 간격")] [SerializeField] private float _spawnInterval;

    [Header("스폰 위치(조정하지 말 것)")] [SerializeField]
    private Vector3 _spawnPosition;

    [Header("장애물 종류")] [SerializeField] private string[] _obstacleTypes;

    [Header("아이템 종류")] [SerializeField] private string[] _itemTypes;

    [Header("아이템 스폰 위치")] [SerializeField] private Transform[] _itemSpawnPositions;

    [Header("아이템 확률")] [SerializeField] private int _itemSpawnProbability;

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

        Obstacle obstacle = ObjectPoolManager.Instance.GetObject<Obstacle>(_obstacleTypes[type]);
        if (obstacle == null) return;

        // 장애물 위치 조정
        var vector3 = obstacle.transform.position;
        vector3.x = _spawnPosition.x;
        obstacle.transform.position = vector3;

        // TopObstacle에서 아이템 생성하면 안 어울려서 예외처리
        if (type == 4)
            return;
        
        int probability = Random.Range(0, 100);
        if (probability <= _itemSpawnProbability)
        {
            SpawnItem(type, vector3.x);
        }
    }

    private void SpawnItem(int index, float spawnPosX)
    {
        // 아이템 종류 중 랜덤으로 선택
        int type = Random.Range(0, _itemTypes.Length);

        ItemEffectBase item = ObjectPoolManager.Instance.GetObject<ItemEffectBase>(_itemTypes[type]);
        if (item == null) return;

        // 아이템 위치 조정
        Vector3 pos = new Vector3(spawnPosX, _itemSpawnPositions[index].position.y, 0);
        item.transform.position = pos;
    }
}