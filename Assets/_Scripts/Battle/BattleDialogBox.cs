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
    public float timeToWaitAfterTex = 1f;
    public float charactersPersecond = 10.0f;
    [SerializeField] Color selectedColor = Color.blue;

    public bool isWriting = false;

    public IEnumerator SetDialog(string message){

        isWriting = true;

        dialogText.text = "";
        foreach (var character in message)
        {
            dialogText.text += character;
            yield return new WaitForSeconds(1/charactersPersecond);
        }

        yield return new WaitForSeconds(timeToWaitAfterTex);

        isWriting = false;
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

    public void SelectMovement(int selectMovement, Move move){
        for (int i = 0; i < movementTexts.Count; i++)
        {
            movementTexts[i].color  = (i == selectMovement ? selectedColor: Color.black);
        }

        ppText.text = $"PP {move.Pp}/{move.Base.Pp}";
        typeText.text = move.Base.Type.ToString();

    }

    public void  SetPokemonMovements(List<Move> moves){
        for(int i = 0; i < movementTexts.Count; i++){
            if(i < moves.Count){
                movementTexts[i].text = moves[i].Base.Name;
            }
            else{
                movementTexts[i].text = "---";
            }
        }
    }
}
