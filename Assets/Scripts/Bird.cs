using System.Collections;          // list of objects
using System.Collections.Generic; // list of birds(class name)
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;
    private bool _birdWasLaunched;
    private float _timeSittingAround;

    [SerializeField] float _launchPower;
    

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
         // bird will go towards initialposition
        GetComponent<LineRenderer>().SetPosition(0 , transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f)
        {
            _timeSittingAround += Time.deltaTime;
        }
        if (transform.position.y > 20f || transform.position.y < -20f || transform.position.x > 20f || transform.position.x < -20f || _timeSittingAround > 2f)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            
        }
        
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
        
    }

    private void OnMouseUp()
    {
        GetComponent <SpriteRenderer>().color = Color.green;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);

        // gravity scale is zero before launching the Bird (AddForce)  and after launch it should be 1 to look like projectile motion
        GetComponent<Rigidbody2D>().gravityScale = 1;
        // signal to start the counter
        _birdWasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;

    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x ,newPosition.y);   
        
    }
}
