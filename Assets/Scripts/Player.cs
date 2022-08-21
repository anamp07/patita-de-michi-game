using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float h;
    float v;
    bool immortal = false;
    [SerializeField] float speed = 3;
    [SerializeField] int health;
    [SerializeField] float damageTimeout = 1;

    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        moveDirection.x = h;
        moveDirection.y = v;
        transform.position += moveDirection * Time.deltaTime * speed;
    }

    void TakeDamage()
    {
        health--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!immortal && collision.CompareTag("Enemy"))
        {
            TakeDamage();
            StartCoroutine(damageTimer());
        }

        if (health <= 0)
        {
            ResetGame();
        }
    }

    private IEnumerator damageTimer()
    {
        immortal = true;
        yield return new WaitForSeconds(damageTimeout);
        immortal = false;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
