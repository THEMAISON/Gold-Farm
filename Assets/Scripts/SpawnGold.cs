using UnityEngine;

public class SpawnGold : MonoBehaviour
{
    [SerializeField] private GameObject _gold;
    [SerializeField] private int _maxCountGold;
    [Range(0.1f, 0.9f)]
    [SerializeField] private float _radiusToSpawn;
    private int _countGoldToSpawn;

    private void Start()
    {
        this._radiusToSpawn = 1 - this._radiusToSpawn;
    }

    public void Spawn()
    {
        this._countGoldToSpawn = Random.Range(1, this._maxCountGold + 1);

        for (int i = 0; i < this._countGoldToSpawn; i++)
        {
            var newGold = Instantiate(this._gold, this.RandPos(), Quaternion.identity);
            newGold.transform.parent = this.transform;
        }
    }

    public int DeleteAllGold()
    {
        foreach (Transform child in transform) Destroy(child.gameObject);
        return _countGoldToSpawn;
    }

    private Vector2 RandPos()
    {
        float rX = Random.Range(transform.parent.position.x - _radiusToSpawn, transform.parent.position.x + _radiusToSpawn);
        float rY = Random.Range(transform.parent.position.y - _radiusToSpawn, transform.parent.position.y + _radiusToSpawn);

        return new Vector2(rX, rY);
    }
}
