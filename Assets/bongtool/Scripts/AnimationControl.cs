using UnityEngine;
using System.Collections;

public class AnimationControl : MonoBehaviour {

    public Animation monsterAnimation;
    
    
    // Use this for initialization

    public void PlayAnimation(string animationName)
    {
        monsterAnimation.CrossFade(animationName, 0.3f);
    }

	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
