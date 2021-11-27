using UnityEngine;
using UnityEngine.UI;

public class DurationCell : MonoBehaviour
{
    [Header("Message")]
    [SerializeField] private MessageController _message;

    [Header("Buttons")]
    [SerializeField] private Button _digButton;
    [SerializeField] private Button _getButton;

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

    private bool _isGold = false;
    private bool _isMiningPit = false;

    void Start()
    {
        this._sr = GetComponent<SpriteRenderer>();
        this._condition = 3;
        this._goldFloor = Random.Range(0,4);
    }

    private void Update()
    {
        Debug.Log(this._getButton.GetComponent<ButtonController>().CountActives);

        this._posThis = this.GetPositionPlayer();

        if (Vector2.Distance(this._posThis, this._player.transform.position) <= this._distanceToInteraction)
        {
            if (this._isMiningPit == false)
            {
                this._isMiningPit = true;
                this._borderPitSprite.color = new Color(255, 255, 255, 255);

                this._digButton.GetComponent<ButtonController>().CountActives++;
            }
            if (_isGold == true && _isMiningPit == true && Input.GetKeyDown(KeyCode.R)) this.GetGold();
        }

        else if (this._isMiningPit == true)
        {
            this._isMiningPit = false;

            this._borderPitSprite.color = new Color(255, 255, 255, 0);
            this._digButton.GetComponent<ButtonController>().CountActives--;
        }
    }

    private Vector3 GetPositionPlayer()
    {
        Vector3 newPositiom = this.transform.position;
        newPositiom.y += 1;
        return newPositiom;
    }

    public void OnMouseDown()
    {
        if (_isGold == false && _isMiningPit == true && this._condition > 0)
        {
            this._condition--;
            this.SetNewCondition(this._condition);
        }
    }

    private void SetNewCondition(int currentConditionIndex)
    {
        this._sr.sprite = this._conditionSprites[currentConditionIndex];
        if (this._goldFloor == currentConditionIndex)
        {
            this._isGold = true;

            GetComponentInChildren<SpawnGold>().Spawn();

            this._getButton.GetComponent<ButtonController>().CountActives++;

            this._message.SetNewMessage("Нажмите R, чтобы собрать!");
            this._message.OnMessage();

            this._player.GetComponent<PlayerController>().IsMoving = false;
        }
    }

    public void GetGold()
    {
        if (this._isGold == true)
        {
            this._isGold = false;

            int newGold = GetComponentInChildren<SpawnGold>().DeleteAllGold();
            this._text.UpdateCountGoldsText(newGold);

            this._getButton.GetComponent<ButtonController>().CountActives--;

            this._message.SetNewMessage("Золото собрано!");
            this._message.OnMessage();
            this._message.Invoke("OffMessage", 4);

            this._player.GetComponent<PlayerController>().IsMoving = true;
        }
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
