using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private float bulletSpeed;

    private AudioSource audioSource;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    private float timer = 1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PlayClips(0);

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = mousePos - transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

    }

    private void PlayClips(int index)
    {
        AudioClip clip = audioClips[index];
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);
    }
    void Update()
    {
        Destroy(gameObject, timer);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayClips(1);
        Destroy(gameObject);
    }
   
   
}
