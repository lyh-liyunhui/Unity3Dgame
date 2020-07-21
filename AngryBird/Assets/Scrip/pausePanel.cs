using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausePanel : MonoBehaviour
{

    private Animator anim;
    public GameObject button;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Retry() {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    /*
     * 点击了pause按钮
     */
    public void Pause() {
      
        anim.SetBool("ispause", true);
        button.SetActive(false);
        if (GameManager._instance.birds.Count > 0) {
            if (GameManager._instance.birds[0].isReleasev == false) {
                GameManager._instance.birds[0].canMove = false;
            }
        }
    }
    public void Home() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    /*
     点击了继续按钮
     */
    public void Resume() {
        Time.timeScale = 1;
        anim.SetBool("ispause", false);

        if (GameManager._instance.birds.Count > 0)
        {
            if (GameManager._instance.birds[0].isReleasev == false)
            {
                GameManager._instance.birds[0].canMove = true;
            }
        }
    }

    /*
     pause动画播放完调用
     */
    public void pauseAnimEnd() {
        Time.timeScale = 0;
    }
    public void ResumeAnimEnd() {
        button.SetActive(true);
    }
}

