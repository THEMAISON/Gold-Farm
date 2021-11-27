using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
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
        CheckerActiveButtons();
    }

    private void CheckerActiveButtons()
    {
        if (this.CountActives > 0)
        {
            this._thisButton.interactable = true;
        }
        else if (this._thisButton.interactable == true)
        {
            this._thisButton.interactable = false;
        }
    }
}
