using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform respawnPoint;
    public Player player;

    [Header("Fruits Management")]
    public bool fruitsHaveRandomLook;
    public int fruitsCollected;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void RespawnPlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        player = newPlayer.GetComponent<Player>();
    }

    public void AddFruit() => fruitsCollected++;

    public bool FruitsHaveRandomLook() => fruitsHaveRandomLook;
}
