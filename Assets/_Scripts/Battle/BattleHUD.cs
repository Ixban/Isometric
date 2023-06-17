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
        UpdatePokemonData();
    }

    public void UpdatePokemonData(){
        StartCoroutine( healthbar.SetSmoothHp((float)_pokemon.HP / _pokemon.MaxHp) ); 
        pokemonHealth.text = $"{_pokemon.HP}/{_pokemon.MaxHp}";
    }
}
