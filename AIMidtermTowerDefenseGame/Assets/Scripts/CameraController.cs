using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //private bool doMovement = true;
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float minY = 10f, maxY = 80f;

    public float panBoarderThickness = 10f;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameEnded)
        {
            this.enabled = false;
            return;
        }

        if (GameManager.gameVictory)
        {
            this.enabled = false;
            return;
        }
        //test
        // if (Input.GetKeyDown (KeyCode.Escape))
        // {
        //     doMovement = !doMovement;
        // }
        // if (doMovement == false)
        // {
        //     return;
        // }
        #region CameraMovement
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height-panBoarderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed *Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBoarderThickness)
        {
            transform.Translate(Vector3.back * panSpeed *Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width-panBoarderThickness)
        {
            transform.Translate(Vector3.right * panSpeed *Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBoarderThickness)
        {
            transform.Translate(Vector3.left * panSpeed *Time.deltaTime, Space.World);
        }

        Vector3 posPan = transform.position;
        posPan.x = Mathf.Clamp(posPan.x, -10, 40);
        posPan.z = Mathf.Clamp(posPan.z, -80, -10);
        transform.position = posPan;
        #endregion

        #region Scroller
        float scroll = Input.GetAxis ("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
        #endregion
    }
}
