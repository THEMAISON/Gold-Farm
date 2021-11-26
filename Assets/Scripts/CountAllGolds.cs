using UnityEngine;
using UnityEngine.UI;

public class CountAllGolds : MonoBehaviour
{
    private int _countGold;
    public int CountGold => _countGold;

    private Text _countGoldsText;

    private void Start()
    {
        this._countGold = 0;
        this._countGoldsText = GetComponent<Text>();
    }

    public void UpdateCountGoldsText(int newCount)
    {
        this._countGold += newCount;
        this._countGoldsText.text = this._countGold.ToString();
    }
}
