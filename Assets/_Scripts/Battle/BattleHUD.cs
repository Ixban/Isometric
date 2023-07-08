using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text pokemonName;
    public Text pokemonLevel;
    public HealthBar healthbar;
    public Text pokemonHealth;

    private Pokemon _pokemon;

    public void SetPokemonData(Pokemon pokemon){
        _pokemon = pokemon;
        pokemonName.text = pokemon.Base.Name;
        pokemonLevel.text = $"LV: {pokemon.Level}";
        UpdatePokemonData(pokemon.HP);
    }

    public void UpdatePokemonData(int oldHPVal){
        StartCoroutine( healthbar.SetSmoothHp((float)_pokemon.HP / _pokemon.MaxHp) ); 
        StartCoroutine(DecreseHealthPoints(oldHPVal));
    }

    private IEnumerator DecreseHealthPoints(int oldHPVal){
        while (oldHPVal>_pokemon.HP)
        {
            oldHPVal--;
            pokemonHealth.text = $"{oldHPVal}/{_pokemon.MaxHp}";
            yield return new WaitForSeconds(0.1f);
        }
        pokemonHealth.text = $"{_pokemon.HP}/{_pokemon.MaxHp}";
    }
}
