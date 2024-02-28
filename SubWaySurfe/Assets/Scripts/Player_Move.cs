using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 _x_posotion;
    [SerializeField] float _jump;
    [SerializeField] float _scaleY;
    [SerializeField] Animator _animator;
    [SerializeField] ParticleSystem _particleSystem;
  //  [SerializeField] float _speed;

    private Rigidbody _rigidbody;
    private bool _isGrounded = true;
    private int _polosa = 2;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        
        Debug.Log("Полоса " + _polosa);
    }

    private void OnCollisionEnter(Collision collision) //Приземление
    {
        if (collision.gameObject.tag == "Ground" && !_isGrounded)
        {
            _isGrounded = true;
            _animator.SetBool("jump", false);
            _particleSystem.Play();
        }
        
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
        }

    }

    private void Jump()
    {
       

            _rigidbody.AddForce(Vector3.up * _jump, ForceMode.Impulse);
            _animator.SetBool("jump", true);
            _isGrounded = false;
        
    }

    private void Move(int polosa, Vector3 x_posotion)
    {
        _polosa += polosa;

        if (_polosa < 1)
        {
            _polosa = 1;
            
            
            Debug.Log("Полоса " + _polosa);
        }
        else if (_polosa > 3)
        {
            _polosa = 3;


            Debug.Log("Полоса " + _polosa);
        }
        else
        {
           // this.transform.position =  Vector3.MoveTowards(this.transform.position, this.transform.position + x_posotion, _speed * Time.deltaTime);
            //_rigidbody.AddForce(x_posotion * _speed * Time.deltaTime, ForceMode.Force);
            this.transform.position += x_posotion;
            
            
            Debug.Log(_polosa);
        }
    }
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))&&_isGrounded) //  ПРЫЖОК
        {
            Jump();
            Debug.Log("Jump");
        }


        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow))) // ПРИСЕД
        { 
            _rigidbody.AddForce(Vector3.up * -_jump * 1.2f, ForceMode.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            Move(-1, _x_posotion);
        }


        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            Move(1, -_x_posotion);

            
        }
    }
}
