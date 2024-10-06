using UnityEngine;

public class HeroControls : MonoBehaviour
{
    private HeroInputAction _heroInputAction;
    private Rigidbody2D _heroRigidbody;

    [Header("Hero Information")] 
    [SerializeField] private float _heroSpeed = 10f;

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
    }
}
