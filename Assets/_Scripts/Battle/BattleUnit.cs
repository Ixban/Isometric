using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
[RequireComponent(typeof(Image))]
public class BattleUnit : MonoBehaviour
{
    public PokemonBase _base;
    public int _level;
    public bool isPlayer;

    public Pokemon Pokemon {get; set;}

    private Image pokemonImage;
    private Vector3 initialPosition;

    private Color initialColor;

    [SerializeField] private float startTimeAnim = 1.0f, attackTimeAnim = 0.3f, dieTimeAim = 1.0f, hitTimeAnim = 0.15f;

    private void Awake(){
        pokemonImage = GetComponent<Image>();
        initialPosition = pokemonImage.transform.localPosition;
        initialColor = pokemonImage.color;
    }

    public void SetupPokemon()
    {
        Pokemon = new Pokemon(_base, _level);
        
        pokemonImage.sprite = (isPlayer ? Pokemon.Base.BackSprite : Pokemon.Base.FrontSprite);
        
        PlayStartAnimation();
    }

    public void PlayStartAnimation(){
        pokemonImage.transform.localPosition = new Vector3(initialPosition.x + (isPlayer? -1:1)*400, initialPosition.y);
        pokemonImage.transform.DOLocalMoveX(initialPosition.x, startTimeAnim);
    }

    public void PlayAttackAnimation(){
        var seq = DOTween.Sequence();
        seq.Append(pokemonImage.transform.DOLocalMoveX(initialPosition.x + (isPlayer? 1:-1)*60, attackTimeAnim));
        seq.Append(pokemonImage.transform.DOLocalMoveX(initialPosition.x, attackTimeAnim));
    }

    public void PlayReceiveAttackAnimation(){
        var seq = DOTween.Sequence();
        seq.Append(pokemonImage.DOColor(Color.grey, hitTimeAnim));
        seq.Append(pokemonImage.DOColor(initialColor, hitTimeAnim));
    }

    public void PlayFaintAnimation(){
        var seq = DOTween.Sequence();
        seq.Append(pokemonImage.transform.DOLocalMoveY(initialPosition.y - 200, dieTimeAim));
        seq.Join(pokemonImage.DOFade(0f, dieTimeAim));
    }
}
