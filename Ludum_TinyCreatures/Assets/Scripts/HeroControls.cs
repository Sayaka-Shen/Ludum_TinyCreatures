using UnityEngine;

public class HeroControls : MonoBehaviour
{
    private HeroInputAction _heroInputAction;
    private Rigidbody2D _heroRigidbody;

    [Header("Hero Information")] 
    [SerializeField] private float _heroSpeed = 10f;
    [SerializeField] private SpriteRenderer _sprite;

    private void Awake()
    {
        _heroRigidbody = GetComponent<Rigidbody2D>();
        
        _heroInputAction = new HeroInputAction();
        _heroInputAction.Hero.Move.Enable();
    }

    private void Update()
    {
        if (GameManager.Instance.LetPlayerMove)
        {
            Movement();
           
        }
    }

    private void Movement()
    {
        Vector2 inputVector = _heroInputAction.Hero.Move.ReadValue<Vector2>();

        _heroRigidbody.velocity = new Vector2(inputVector.x, inputVector.y) * _heroSpeed;
        RotateHero(inputVector);
    }

    private void RotateHero(Vector2 inputVector)
    {
        if (inputVector.x > 0)
        {
            _sprite.flipX = true;
        }else if(inputVector.x < 0)
        {
            _sprite.flipX = false;
        }
    }
}
