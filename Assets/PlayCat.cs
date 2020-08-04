using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayCat : MonoBehaviour
{
    [SerializeField]
    [Header("Действия с котом")]
    [Tooltip("Номер реакции в списке это номер в списке настроений")]
    public Action[] actions; // список действий с реакциями на них в зависимости от настроения
    private Reaction curReaction; // текущее состояние кошки, понадобится в будующем для анимации персонажа

    [SerializeField]
    [Header("Настроения")]
    public String[] moods;
    private int curMood = 0; //текущее настроение кошки

    [SerializeField]
    private Text reaction;

    [SerializeField]
    private Text mood;
    [SerializeField]
    private Canvas canvas;

    private GameObject[] actionButtons;

    [SerializeField]
    private GameObject buttonPref;

    // Start is called before the first frame update
    void Start()
    {
        if (actions.Length == 0 || moods.Length == 0) {
            reaction.text = "Нет доступных действий";
            return;
        }
        curReaction = actions[0].getReaction(curMood);
        reaction.text = curReaction.ReactionDescription;
        mood.text = moods[curMood];
        actionButtons = new GameObject[actions.Length];

        for (int i = 0; i < actions.Length; i++) {
            if (actions[i].getName() != "")
            {
                actionButtons[i] = Instantiate(buttonPref, canvas.transform);
                actionButtons[i].transform.localPosition = new Vector2(-500, 300 - i * 50);
                actionButtons[i].transform.GetChild(0).GetComponent<Text>().text = actions[i].getName();
                ActionButton actionButton = actionButtons[i].GetComponent<ActionButton>();
                actionButton.ActionIndex = i;
                actionButtons[i].GetComponent<Button>().onClick.AddListener(delegate { ButtonPress(actionButton.ActionIndex); });
            }
        }
    }

    public void ButtonPress(int action)
    {
        try
        {

            curReaction = actions[action].getReaction(curMood);
            curMood = curReaction.AfterMood; // меняем текущее настроение на то что следует после реакции на действие

            reaction.text = curReaction.ReactionDescription;
            mood.text = moods[curMood];

        }
        catch (IndexOutOfRangeException)
        {
            reaction.text = "Кошка не понимает что ей делать, поведение с таким настроением непредсказуемо (опишите в его в инспекторе)";
        }
    }
}
