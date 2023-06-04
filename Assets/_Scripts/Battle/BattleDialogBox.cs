using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText;
    
    [SerializeField] GameObject actionSelect;
    [SerializeField] GameObject movementSelect;
    [SerializeField] GameObject movementDesc;

    
    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> movementTexts;
    
    [SerializeField] Text ppText;
    [SerializeField] Text typeText;

    public float charactersPersecond = 10.0f;
    [SerializeField] Color selectedColor = Color.blue;

    public IEnumerator SetDialog(string message){
        dialogText.text = "";
        foreach (var character in message)
        {
            dialogText.text += character;
            yield return new WaitForSeconds(1/charactersPersecond);
        }
    }

    public void ToggleDialogText(bool activated){
        dialogText.enabled = activated;
    }

    public void ToggleActions(bool activated){
        actionSelect.SetActive(activated);
    }

    public void ToggleMovements(bool activated){
        movementSelect.SetActive(activated);
        movementDesc.SetActive(activated);
    }

    public void SelectAction(int selectedAction){
        for (int i = 0; i < actionTexts.Count; i++)
        {
            actionTexts[i].color  = (i == selectedAction ? selectedColor: Color.black);
        }
    }
}
