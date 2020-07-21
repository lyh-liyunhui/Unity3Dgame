using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float maxSpeed = 10;
    public float minSpeed = 5;
    private SpriteRenderer sp;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;

    public AudioClip hurtClip;
    public AudioClip dead;
    public AudioClip birdCollision;
    public bool isPig = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioPlay(birdCollision);
            collision.transform.GetComponent<Bird>().Hurt();

        }
            if (collision.relativeVelocity.magnitude > maxSpeed)
            {
                Dead();
            }
            else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
            {

            AudioPlay(hurtClip);
            sp.sprite = hurt;
                
            }
        
    }

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead() {
        if (isPig) 
        {
            GameManager._instance.pig.Remove(this);
        }
        //播放死亡音乐
        AudioPlay(dead);
        Destroy(gameObject);
        Instantiate(boom,transform.position, Quaternion.identity);
       
        GameObject go = Instantiate(score, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity); ;
        Destroy(go, 1.5f);
        

    }
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

}
