using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implemented by (MC)
//Coroutine that manages the metal boxes seen in the level
public class BoxMover : MonoBehaviour
{
    //variables used throughout the code
    [SerializeField]
    private int m_MoveUnitsX;

    [SerializeField]
    private int m_MoveUnitsY;

    [SerializeField]
    private float m_MoveTime;

    [SerializeField]
    private float m_waitTime;

    private bool m_Moved = false;
    
    // If the Player collides with a metal box that box will move out of the way
    // The boxes are prefabs and are modified to fit the spot they are in 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(!m_Moved)
            {
                StartCoroutine(MoveBox());
                m_Moved = true;
            }
        }
    }

    //This is the coroutine that will move the box up, down, left, or right when touched
    private IEnumerator MoveBox()
    {
        yield return new WaitForSeconds(m_waitTime);
        float totalTime = 0;
        float originalX = transform.position.x;
        float originalY = transform.position.y;
        while(totalTime < m_MoveTime)
        {
            float x = Mathf.Lerp(0, m_MoveUnitsX, totalTime / m_MoveTime);
            float y = Mathf.Lerp(0, m_MoveUnitsY, totalTime / m_MoveTime);
            transform.position = new Vector3(originalX + x, originalY + y, transform.position.z);
            totalTime = totalTime + Time.deltaTime;
            yield return null;
        }
    }
}
