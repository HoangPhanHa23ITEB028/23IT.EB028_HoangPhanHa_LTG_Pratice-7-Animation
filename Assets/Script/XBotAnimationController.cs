
using UnityEngine;
using UnityEngine.InputSystem;

public class XBotAnimationController : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current == null || animator == null)
            return;

        // W: Đi bộ
        bool walking = Keyboard.current.wKey.isPressed;

        // E: Chạy
        bool running = Keyboard.current.eKey.isPressed;

        // Ưu tiên Running nếu giữ đồng thời W và E
        if (running)
            walking = false;

        // Cập nhật trạng thái di chuyển
        animator.SetBool("IsWalking", walking);
        animator.SetBool("IsRunning", running);

        // Q: Nhảy
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            animator.ResetTrigger("Dance");
            animator.SetTrigger("Dance");
        }
    }
}
