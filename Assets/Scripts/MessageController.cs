using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    private MessageController _mc;
    private Text _messageText;

    private void Start()
    {
        this._mc = GetComponent<MessageController>();
        this._messageText = GetComponentInChildren<Text>();
        this.OffMessage();
    }

    public void SetNewMessage(string newText)
    {
        this._messageText.text = newText;
    }

    public void OnMessage()
    {
        this.gameObject.SetActive(true);
    }

    public void OffMessage()
    {
        this.gameObject.SetActive(false);
    }
}
