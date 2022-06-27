using Models;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Dialogues;
using System.Collections.Generic;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private Button button;
    private List<Button> buttons = new List<Button>();
    private DialogueView dialogueView;

    private void Start()
    {
        dialogueView = GetComponentInParent<DialogueView>();
    }

    public void ActivateButtons(Dialogue dialogue)
    {
        Button btn = Instantiate(button, gameObject.transform);
        buttons.Add(btn);
        btn.GetComponentInChildren<TextMeshProUGUI>().text = dialogue.choice_description;
        btn.onClick.AddListener(dialogueView.NextScene);
        btn.onClick.AddListener(delegate { DestroyButton(btn); });
    }

    private void DestroyButton(Button btn)
    {
        Destroy(btn.gameObject);
    }
}