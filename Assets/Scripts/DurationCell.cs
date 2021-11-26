using UnityEngine;
using UnityEngine.UI;

public class DurationCell : MonoBehaviour
{
    [Header("Gold Options")]
    [SerializeField] private CountAllGolds _text;

    [Header("Pit Options")]
    [SerializeField] private GameObject _player;
    [Range(0.2f,5.0f)]
    [SerializeField] private float _distanceToInteraction;
    [SerializeField] private Sprite[] _conditionSprites;

    [SerializeField] private SpriteRenderer _borderPitSprite;
    [SerializeField] private SpriteRenderer _overPitSprite;

    private SpriteRenderer _sr;
    private Vector3 _posThis;

    private int _condition;
    private int _goldFloor;

    bool isGold = false;
    bool isMiningPit = false;

    void Start()
    {
        this._sr = GetComponent<SpriteRenderer>();
        this._condition = 3;
        this._goldFloor = Random.Range(0,4);
    }

    private void Update()
    {

        this._posThis = GetPositionPlayer();

        if (Vector2.Distance(this._posThis, this._player.transform.position) <= this._distanceToInteraction)
        {
            if (this.isMiningPit == false)
            {
                this._borderPitSprite.color = new Color(255, 255, 255, 255);
                this.isMiningPit = true;
            }
        }
        else
        {
            if (this.isMiningPit == true)
            {
                this.isMiningPit = false;
                this._borderPitSprite.color = new Color(255, 255, 255, 0);
            }
        }

        if (isGold == true && isMiningPit == true)
        {
            ToCollectGold();
        }
    }

    private Vector3 GetPositionPlayer()
    {
        this._posThis = this.transform.position;
        this._posThis.y += 1;
        return this._posThis;
    }

    public void OnMouseDown()
    {
        if (isGold == false && isMiningPit == true)
        {
            this._condition--;
            SetNewCondition(this._condition);
        }
    }

    private void SetNewCondition(int currentConditionIndex)
    {
        this._sr.sprite = _conditionSprites[currentConditionIndex];
        if (_goldFloor == currentConditionIndex)
        {
            isGold = true;
            Debug.Log("Gold is found!");
            GetComponentInChildren<SpawnGold>().Go();
        }
    }

    private void ToCollectGold()
    {
        if (Input.GetKeyDown(KeyCode.R)) GetGold();
    }

    private void GetGold()
    {
        isGold = false;
        Debug.Log("You get up the item!");

        int newGold = GetComponentInChildren<SpawnGold>().DeleteAllGold();
        this._text.UpdateCountGoldsText(newGold);

    }

    private void OnMouseOver()
    {
        _overPitSprite.color = new Color(255, 255, 255, 255);
    }
    private void OnMouseExit()
    {
        _overPitSprite.color = new Color(255, 255, 255, 0);
    }
}
