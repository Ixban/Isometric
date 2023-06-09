using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    
    public float speed;
    private Vector2 input;

    public LayerMask solidObjectsLayer, pokemonLayer;
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!isMoving){
            /*input.x = new Vector2(Input.GetAxisRaw("Horizontal",  Input.GetAxisRaw("Vertical"));*/
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0){
                input.y = 0;
            }

            if(input != Vector2.zero){

                _animator.SetFloat("Move X", input.x);
                _animator.SetFloat("Move Y", input.y);

                var targetPositon = transform.position;
                targetPositon.x += input.x;
                targetPositon.y += input.y;

                //transform.position = targetPositon;
                if (IsAvailable(targetPositon)){
                    StartCoroutine(MoveTowards(targetPositon));
                    print("Move");
                }
            }
        }
        
    }

    private void LateUpdate()
    {
        _animator.SetBool("Is Moving", isMoving);
    }
    IEnumerator MoveTowards(Vector3 destination){

        isMoving = true; 

        while (Vector3.Distance(transform.position, destination) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        transform.position = destination;

        isMoving = false; 

        checkForPokemon();
    }

    private bool IsAvailable(Vector3 target){
        
        if(Physics2D.OverlapCircle(target, 0.1f, solidObjectsLayer) != null){
            return false;            
        }

        return true;
    }

    private void checkForPokemon(){
        
        if(Physics2D.OverlapCircle(transform.position, 0.1f, pokemonLayer) != null){
            if(Random.Range(0,100) < 15){
                Debug.Log("Empezar batalla pokemon");
            }
        }

    }

}
