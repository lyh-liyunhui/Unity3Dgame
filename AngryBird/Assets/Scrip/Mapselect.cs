using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapselect : MonoBehaviour
{
    public int starsNum = 0;
    private bool isSelect = false;

    public GameObject locks;
    public GameObject stars;
    public GameObject panel;
    public GameObject map;
    public Text starstext;

    public int startnum=1;
    public int endnum = 3;

    private void Start()
    {
        if (PlayerPrefs.GetInt("totalNum", 0) >= starsNum) {
            isSelect = true;
        }
        if (isSelect) {
            locks.SetActive(false);
            stars.SetActive(true);

            //显示星星总数
            int counts = 0;
            for (int i = startnum; i < endnum; i++) {
                counts += PlayerPrefs.GetInt("level" + i.ToString(),0);
            }
            starstext.text = counts.ToString()+"/9";
        }

    }
    public void Selected()
    {
        if (isSelect) {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }

    public void panelSelected() {
        panel.SetActive(false);
        map.SetActive(true);
    }
}
