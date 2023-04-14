using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speedPlayer;
    [SerializeField] private float _speedSpawn = 5f;
    [SerializeField] private float _shiftSpeed = 8f;
    [SerializeField] private Vector2 ourSavePos;

    private bool _flip;
    public bool isMove = false;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _speedPlayer = _speedSpawn;
        _sprite = transform.GetComponentInChildren<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speedPlayer = _shiftSpeed;
        }
        else
        {
            _speedPlayer = _speedSpawn;
        }

        float transV = Input.GetAxis("Vertical") * _speedPlayer * Time.fixedDeltaTime;

        float transH = Input.GetAxis("Horizontal") * _speedPlayer * Time.fixedDeltaTime;

        //RotateToMove(transH);

        if (transV != 0 || transH != 0)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        transform.Translate(new Vector3(transH, transV));
    }

    void RotateToMove(float transH)
    {
        if (transH < 0)
        {
            _flip = true;
        }

        if (transH > 0)
        {
            _flip = false;
        }

        if (_flip)
        {
            _sprite.transform.rotation = new Quaternion(transform.rotation.x, 180f, transform.rotation.z, 5f);
        }
        else
        {
            _sprite.transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, 5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SavePoint")
        {
            ourSavePos = transform.position;
        }
        if (other.tag == "KillPoint")
        {
            transform.position = ourSavePos;
        }
    }
}
