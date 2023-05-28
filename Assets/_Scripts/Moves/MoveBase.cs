using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Nuevo movimiento")]
public class MoveBase : ScriptableObject
{
    [SerializeField] private string name;
    public string  Name => name;

    [TextArea][SerializeField] private string description;
    public string  Description => description;

    [SerializeField] private PokemonType type;
    public PokemonType  Type => type;

    [SerializeField] private int power;
    public int  Power => power;

    [SerializeField] private int accuracy;
    public int  Accuracy => accuracy;

    [SerializeField] private int pp;
    public int  Pp => pp;

    public List<Move> moves;

}
