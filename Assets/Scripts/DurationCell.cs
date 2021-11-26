using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurationCell : MonoBehaviour
{
    [Header("Gold Options")]
    [SerializeField] private Text _textCountGold;

    [Header("Pit Options")]
    [SerializeField] private GameObject player;
    [Range(0.2f,5.0f)]
    [SerializeField] private float _distanceToInteraction;
    [SerializeField] private Sprite[] conditionSprites;

    [SerializeField] private SpriteRenderer border;
    [SerializeField] private SpriteRenderer over;   

    private SpriteRenderer sr;
    private Vector3 posThis;

    int condition = 3;
    int goldFloor = -1;

    bool isGold = false;
    bool isMiningPit = false;

    static private int _allGolds = 0;

    void Start()
    {
        this.sr = GetComponent<SpriteRenderer>();
        goldFloor = Random.Range(0,4);
    }

    private void Update()
    {
        //Если игрок достаточно близко к яме то может ее выкопать
        this.posThis = this.transform.position;
        this.posThis.y += 1;

        if (Vector2.Distance(this.posThis, this.player.transform.position) <= this._distanceToInteraction)
        {
            if (isMiningPit == false)
            {
                border.color = new Color(255, 255, 255, 255);
                isMiningPit = true;
            }
        }
        else
        {
            if (isMiningPit == true)
            {
                isMiningPit = false;
                border.color = new Color(255, 255, 255, 0);
            }
        }

        if (isGold == true && isMiningPit == true)
        {
            ToCollectGold();
        }
    }
    
    private void ChangeSprite(int index)
    {
        this.sr.sprite = conditionSprites[index];
    }
    private bool CheckGold(int index)
    {
        if (goldFloor == index)
        {
            isGold = true;
            return true;
        }
        return false;
    }
    private void ToCollectGold()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetGold();
        }
    }

    public void OnMouseDown()
    {
        if (isGold == false && isMiningPit==true)
        {
            this.condition--;

            if (condition == 2)
            {
                ChangeSprite(0);
                if (CheckGold(2))
                {
                    Debug.Log("Gold is found!");
                    GetComponentInChildren<SpawnGold>().GetComponent<SpawnGold>().Go();
                }
            }
            else if (condition == 1)
            {
                ChangeSprite(1);
                if (CheckGold(1))
                {
                    Debug.Log("Gold is found!");
                    GetComponentInChildren<SpawnGold>().GetComponent<SpawnGold>().Go();
                }
            }
            else if (condition == 0)
            {
                ChangeSprite(2);
                if (CheckGold(0))
                {
                    Debug.Log("Gold is found!");
                    GetComponentInChildren<SpawnGold>().GetComponent<SpawnGold>().Go();
                }
            }
        }
    }
    private void OnMouseOver()
    {
        //Cursor.SetCursor(_newCursos, Vector2.zero, CursorMode.Auto);
        over.color = new Color(255, 255, 255, 255);
    }
    private void OnMouseExit()
    {
        //Cursor.SetCursor(_newCursos, Vector2.zero, CursorMode.Auto);
        over.color = new Color(255, 255, 255, 0);
    }
    public void GetGold()
    {
        isGold = false;
        Debug.Log("You get up the item!");
        _allGolds += GetComponentInChildren<SpawnGold>().GetComponent<SpawnGold>().DeleteAllGold();
        _textCountGold.text = _allGolds.ToString();
    }
}
