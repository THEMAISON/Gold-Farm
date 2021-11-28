using UnityEngine;
using UnityEngine.UI;

public class ShovelStatistics: MonoBehaviour
{
    [SerializeField] private Image[] _imgShovel;

    private int _numberOfUses;

    public int NumberOfUses
    {
        get { return this._numberOfUses; }
        set { this._numberOfUses = value; }
    }

    void Start()
    {
        this._numberOfUses = this._imgShovel.Length * 5;
    }

    void Update()
    {
        if (this._numberOfUses % 5 == 0 && this._numberOfUses < 25 && this._numberOfUses >=0)
        {
            this._imgShovel[this._numberOfUses / 5].color = new Color(0,0,0,55);
        }
    }
}
