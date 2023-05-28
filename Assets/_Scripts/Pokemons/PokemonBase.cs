using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Nuevo Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] private int ID;
    [SerializeField] private string name;
    public string Name => name;

    [TextArea][SerializeField] private string description;
    public string Description => description;

    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;

    [SerializeField] private PokemonType  type1;
    public PokemonType  Type1 => type1;
    
    [SerializeField] private PokemonType  type2;
    public PokemonType  Type2 => type2;

    //stats

    [SerializeField] private int maxHp;
    public int MaxHp => maxHp;

    [SerializeField] private int attack;
    public int Attack => attack;

    [SerializeField] private int defense;
    public int Defense => defense;
    
    [SerializeField] private int spAttack;
    public int SpAttack => spAttack;

    [SerializeField] private int spDefense;
    public int SpDefense => spDefense;

    [SerializeField] private int speed;
    public int Speed => speed;

    [SerializeField] private List<LearnableMove> learnableMoves;
    public List<LearnableMove> LearnableMoves => learnableMoves;

}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Fight,
    Ice,
    Poison,
    Ground,
    Fly,
    Psychic,
    Rock,
    Bug,
    Ghost,
    Dragon,
    Dark,
    Fairy,
    Steel
}

[Serializable]
public class LearnableMove
{
[SerializeField] private MoveBase move;
[SerializeField] private int level;

public MoveBase Move => move;
public int Level => level;
}