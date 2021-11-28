using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] ShovelStatistics _ss;

    private Button _thisButton;
    private bool _isActive;
    private int _countActive;

    public int CountActives
    {
        get { return this._countActive; }
        set { this._countActive = value;}
    }

    private void Start()
    {
        this._thisButton = GetComponent<Button>();
        this._thisButton.interactable = false;
        this._countActive = 0;
    }

    private void Update()
    {
        if (this.gameObject.name == "Dig" )
        {
            if(_ss.NumberOfUses == 0 && this._thisButton.interactable ==true) this._thisButton.interactable = false;
            else if (_ss.NumberOfUses > 0) CheckerActiveButtons();
        }
        else if (this.gameObject.name == "Get") CheckerActiveButtons();
    }

    private void CheckerActiveButtons()
    {
        if (this._countActive > 0)
        {
            this._thisButton.interactable = true;
        }
        else if (this._thisButton.interactable == true)
        {
            this._thisButton.interactable = false;
        }
    }
}
