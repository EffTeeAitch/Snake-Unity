using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentFood : MonoBehaviour
{
    public BoxCollider2D expandedGridArea;
    public GameObject player;
    private AudioSource _audio = new AudioSource();
    public int score = 0;

    private void Start()
    {
        RandomizePosition();
        _audio = GetComponent<AudioSource>();
    }

    public void RandomizePosition()
    {
        Bounds bounds = this.expandedGridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RandomizePosition();
            _audio.PlayOneShot(_audio.clip, 0.2f);
        }
        
        if (other.CompareTag("Obstacle"))
        {
            RandomizePosition();
        }


    }

}
