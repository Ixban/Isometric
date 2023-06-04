using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum  BattleState {
    StartBattle,
    PlayerSelectAction,
    PlayerMove,
    EnemyMove,
    Busy
}

public class BattleManager : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHUD playerHUB;

    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHUD enemyHUB;

    [SerializeField] BattleDialogBox battleDialogBox;

    public BattleState state;

    private void Start(){
        StartCoroutine(SetupBatte());
    }

    public IEnumerator SetupBatte(){

        state = BattleState.StartBattle;

        playerUnit.SetupPokemon();
        playerHUB.SetPokemonData(playerUnit.Pokemon);

        enemyUnit.SetupPokemon();
        enemyHUB.SetPokemonData(enemyUnit.Pokemon);

        yield return battleDialogBox.SetDialog($"Un {enemyUnit.Pokemon.Base.Name} salvaje apareció.");
        yield return new WaitForSeconds(1f);

        if(enemyUnit.Pokemon.Speed > playerUnit.Pokemon.Speed){
            StartCoroutine(battleDialogBox.SetDialog("El enemigo ataca primero"));
        }else{
            PlayerAction();
        }
    }

    void PlayerAction(){

        state = BattleState.PlayerSelectAction;
        StartCoroutine(battleDialogBox.SetDialog("Selecciona una acción"));
        battleDialogBox.ToggleActions(true);
        currentSelectedAction = 0;
        battleDialogBox.SelectAction(currentSelectedAction);

    }

    void EnemyAction(){
        print("Enemy");
    }

    private void Update(){
        timeSinceLastClick += Time.deltaTime;
        if (state == BattleState.PlayerSelectAction){
            HandlePlayerActionSelection();
        }
    }

    private int currentSelectedAction;
    private float timeSinceLastClick;
    public float timeBeetweenClicks = 1.0f;

    void HandlePlayerActionSelection(){

        if(timeSinceLastClick < timeBeetweenClicks){
            return;
        }

        if(Input.GetAxisRaw("Vertical") != 0)
        {
            timeSinceLastClick = 0;

            currentSelectedAction = (currentSelectedAction+1) % 2;

            battleDialogBox.SelectAction(currentSelectedAction);
        }

        if(Input.GetAxisRaw("Submit") != 0)
        {
            timeSinceLastClick = 0;
            if(currentSelectedAction == 0){
                
            }
            else if (currentSelectedAction == 1){
                
            }
        }

    }

}
