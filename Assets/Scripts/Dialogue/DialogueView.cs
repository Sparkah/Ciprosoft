using Controllers;
using Helpers;
using Models;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Dialogues
{
    public class DialogueView : MonoBehaviour
    {
        private DialogueCntrl dialogueCntrl = new DialogueCntrl();
        private ButtonView buttonView;

        private int dialogueSwitcher;
        private int dialogueSystemCurrentId;
        [SerializeField] private UnityEngine.UI.Image bgImage;
        [SerializeField] private Button nextScreenBtn;
        [SerializeField] private TextMeshProUGUI descriptionTxt;
        [SerializeField] private UnityEngine.UI.Image descriptionImage;
        [SerializeField] private UnityEngine.UI.Image thoughtBubble;
        [SerializeField] private TextMeshProUGUI thoughtBubbleTxt;

        void Start()
        {
            buttonView = GetComponentInChildren<ButtonView>();
            dialogueCntrl.DialogueSystemModel = JsonUtils.ImportJson<DialogueSystemModel>("json/edge_task");
            dialogueCntrl.DialogueModel = JsonUtils.ImportJson<DialogueModel>("json/quest_step_task");

            nextScreenBtn.onClick.AddListener(NextScene);

            dialogueSystemCurrentId = 0;
            dialogueSwitcher = dialogueCntrl.DialogueSystemModel.DialoguesSystem[dialogueSystemCurrentId].source_id;

            HideAllUI();
            SetUpScene();
        }

        public void NextScene()
        {
            int index = 0;
            foreach (DialogueSystem dialogue in dialogueCntrl.DialogueSystemModel.DialoguesSystem)
            {
                if (dialogue.source_id == dialogueSwitcher)
                {
                    dialogueSystemCurrentId = index;
                }
                index++;
            }
            dialogueSwitcher = dialogueCntrl.DialogueSystemModel.DialoguesSystem[dialogueSystemCurrentId].target_id;

            HideAllUI();
            SetUpScene();
        }

        //Разбить метод на несколько для удобства дальнейшей разработки !!!
        private void SetUpScene()
        {
            foreach (Dialogue dialogue in dialogueCntrl.DialogueModel.Dialogues)
            {
                if (dialogue.id == dialogueSwitcher)
                {
                    Debug.Log(dialogueSwitcher);
                    bgImage.sprite = Resources.Load<Sprite>("sprites/" + dialogue.card.image.file_id);

                    if (dialogue.visualisations[0].description == "плашка другого (чёрного) цвета сверху экрана")
                    {
                        descriptionImage.gameObject.SetActive(true);
                        descriptionTxt.gameObject.SetActive(true);
                        descriptionTxt.text = dialogue.description;
                        Debug.Log(dialogue.description);
                    }

                    if (dialogue.visualisations[0].description == "мысленный баббл")
                    {
                        thoughtBubble.gameObject.SetActive(true);
                        thoughtBubbleTxt.gameObject.SetActive(true);
                        thoughtBubbleTxt.text = dialogue.description;
                        Debug.Log(dialogue.description);
                    }

                    if (dialogue.choice_description == "")
                    {
                        nextScreenBtn.gameObject.SetActive(true);
                    }
                    else
                    {
                        nextScreenBtn.gameObject.SetActive(false);
                        buttonView.ActivateButtons(dialogue);
                    }
                }
            }
        }

        private void HideAllUI()
        {
            //bgImage.gameObject.SetActive(false);
            nextScreenBtn.gameObject.SetActive(false);
            descriptionTxt.gameObject.SetActive(false);
            descriptionImage.gameObject.SetActive(false);
            thoughtBubble.gameObject.SetActive(false);
            thoughtBubbleTxt.gameObject.SetActive(false);
        }
    }
}