using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBehaviour : MonoBehaviour
{
    public RectTransform RectTransform;
    public TextMeshProUGUI Message;
    public Button Button;
    private List<string> messages;

    public void Init(string message, float time)
    {
        Image image = GetComponent<Image>();
        Color color = image.color;
        color.a = 0;
        image.color = color;
        Message.text = message;
        Button.gameObject.SetActive(false);
        StartCoroutine(TimedPopup(time));
    }

    public void Init(List<string> messages, string buttonName)
    {
        this.messages = messages;
        Message.text = messages[0];
        Button.GetComponentInChildren<TextMeshProUGUI>().text = buttonName;
    }

    private IEnumerator TimedPopup(float time)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            RectTransform.anchoredPosition += new Vector2(0, 1) * 25 * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    public void OnButtonClick()
    {
        messages.RemoveAt(0);
        if (messages.Count == 0)
        {
            Destroy(gameObject);
            return;
        }

        Message.text = messages[0];
        if (messages.Count == 1)
            Button.GetComponentInChildren<TextMeshProUGUI>().text = "Close";
    }
}