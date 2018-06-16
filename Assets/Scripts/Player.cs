using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rayLength = 10;
    public Transform playerHead;

    public Weapon weapon;

    private float shootTimer = 0.0f;

    private WaitForSeconds lineRendereVisibillityTime;

    private ImageProgressBar imgProgressBar;

    void Start()
    {
        weapon.Init();

        lineRendereVisibillityTime = new WaitForSeconds(weapon.fireRate * 0.4f);
    }

    void Update()
    {
        Raycast();

        shootTimer += Time.deltaTime;
    }

    private void Raycast()
    {
        Ray ray = new Ray(playerHead.position, playerHead.forward);
        RaycastHit hit;

        Debug.DrawRay(playerHead.position, playerHead.forward * rayLength, Color.white, 1.0f);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Target") && shootTimer >= weapon.fireRate)
            {
                MakeShot(hit.collider.GetComponent<Rigidbody>(), hit);
                return;
            }
            if (hit.collider.gameObject.CompareTag("VR_UI"))
            {
                imgProgressBar = hit.collider.gameObject.GetComponent<ImageProgressBar>();
                imgProgressBar.GazeOver = true;
                imgProgressBar.StartFillingProgressBar();
                return;
            }
            else if(imgProgressBar != null)
            {
                imgProgressBar.GazeOver = false;
                imgProgressBar.StopFillingProgressBar();
                imgProgressBar = null;
                return;
            }
        }
    }

    private void MakeShot(Rigidbody targetRb, RaycastHit hit)
    {
        weapon.Shoot(hit.point, -hit.normal, targetRb);
        shootTimer = 0.0f;
        StartCoroutine(HandleLineRenderer());
    }

    private IEnumerator HandleLineRenderer()
    {
        yield return lineRendereVisibillityTime;
        weapon.ClearShootTrace();
    }
}
