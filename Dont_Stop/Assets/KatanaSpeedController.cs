using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaSpeedController : MonoBehaviour
{
    public Animator katanaAnim;
    public float katana_animation_speed;
    // Start is called before the first frame update
    void Start()
    {
        katanaAnim.speed = katana_animation_speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
