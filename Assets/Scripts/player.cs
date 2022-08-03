using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    public gameObject _laserPrefab;
    private float _canfire = 0.5f;
    private float _fireRate = -1f;
    private float duration = Time.time;
    private int _lives = 7;
    private bool _stopSpawn = false;
    private Manager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObjects.Find("Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        if(transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if(transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
        if(transform.position.x > 10.2f)
        {
            transform.position = new Vector3(-10.2f, transform.position.y, 0);
        }
        else if(transform.position.x < -10.2)
        {
            transform.position = new Vector3(10.2f, transform.position.y, 0);
        }
if (Input.GetKeyDown(KeyCode.Space) && duration > _canfire)
{
            _canfire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3( 0, 0.8f, 0) ,Quaternion.identity);
            
}  
    }
    public void Damage()
    {
        _lives--;
        if(_lives == 0)
        {
            _spawnManager.PlayerOnDeath();
            Destroy(this.GameObjects);
        }
    }
}
