using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Vector3 _groundCheckOffset;
    [SerializeField] private float _jumpForce;
    private CharacterAnimation _characterAnimations;
    private bool _isMoving;
    private bool _isGrounded;
    private Vector3 _input;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterAnimations = GetComponentInChildren<CharacterAnimation>();  
    }

    private void Update()
    {
        Move();
        CheckGround();

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_isGrounded)
            {
                Jump();
                _characterAnimations.Jump();
            }
        }
    }

    private void CheckGround()
    {
        float rayLength = 0.3f;
        Vector3 rayStartPosition = transform.position + _groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, rayStartPosition + Vector3.down, rayLength);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Platform"))
            {
                _isGrounded = true;
            }

            else
            {
                _isGrounded = false;
            }
        }

        else
        {
            _isGrounded = false;
        }
    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _speed * Time.deltaTime * _input;
        _isMoving = _input.x != 0;
        _characterAnimations.IsMoving = _isMoving;

        if (_input.x != 0)
        {
            if (_input.x < 0)
            {
                _spriteRenderer.flipX = true;
            }

            else
            {
                _spriteRenderer.flipX = false;
            }
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }
}
