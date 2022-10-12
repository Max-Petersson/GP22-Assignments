using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    BoxCollider2D coll;
    private AudioSource audioSource;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed;
    private float timer = 1f;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        
        AudioClip clip = audioClips[0];
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = mousePos - transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        AudioClip clip = audioClips[1];
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
        if (audioSource.isPlaying == false) // istället kanske gör en ienumerator istället
            Destroy(gameObject);
    }
}
