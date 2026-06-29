using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class GameVisualManager : NetworkBehaviour
{
    private const float GRID_SIZE = 3.1f;

    [SerializeField] private Transform crossPrefab;
    [SerializeField] private Transform circlePrefab;

    private void Start()
    {
        GameManager.instance.onClickedOnGridPosition += GameManager_onClickedOnGridPosition;
    }

    private void GameManager_onClickedOnGridPosition(object sender, GameManager.onClickedGridPositionEventArgs e)
    {
        Debug.Log("GameManager_onClickedOnGridPosition");
        SpawnObjectRpc(e.x, e.y);
    }

    [Rpc(SendTo.Server)]
    private void SpawnObjectRpc(int x, int y)
    {
        Debug.Log("SpawnObject");
        Transform spawnedCrossTransform = Instantiate(crossPrefab, GetGridWorldPosition(x, y), Quaternion.identity);
        spawnedCrossTransform.GetComponent<NetworkObject>().Spawn(true);
    }

    private Vector2 GetGridWorldPosition(int x, int y)
    {
        return new Vector2(-GRID_SIZE + x * GRID_SIZE, -GRID_SIZE + y * GRID_SIZE);
    }
}