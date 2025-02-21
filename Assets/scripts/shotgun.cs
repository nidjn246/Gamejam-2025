using UnityEngine;

public class shotgun : MonoBehaviour
{
    private Animator GunAnimation;
    [SerializeField] private Rigidbody Bullet;
    [SerializeField] private GameObject FireLocation1;
    [SerializeField] private GameObject FireLocation2;
    private float cooldown;

    private void Start()
    {
        GunAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        cooldown = cooldown - Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (cooldown <= 0)
            {
                GunAnimation.Play("shotgun", 0, 0f);
                Rigidbody bulletclone;
                bulletclone = Instantiate(Bullet, FireLocation1.transform.position, FireLocation1.transform.rotation);
                bulletclone.linearVelocity = transform.TransformDirection(Vector3.back * 10);

                bulletclone = Instantiate(Bullet, FireLocation2.transform.position, FireLocation2.transform.rotation);
                bulletclone.linearVelocity = transform.TransformDirection(Vector3.back * 10);
                cooldown = 2f;
            }
        }
    }
}
