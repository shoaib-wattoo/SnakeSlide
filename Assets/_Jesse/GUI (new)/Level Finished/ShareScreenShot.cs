using System.Collections;
using UnityEngine;

using VoxelBusters.NativePlugins;

public class ShareScreenShot : MonoBehaviour
{

    private bool isSharing = false;

    public void RateMyApp()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            NPBinding.Utility.OpenStoreLink("com.example.example");
        }

        else 
        {
            Application.OpenURL("https://upwork.com");
        }
    }

    public void ShareSocialMedia()
    {
        isSharing = true;
    }

    void LateUpdate()
    {
        if (isSharing == true)
        {
            isSharing = false;

            StartCoroutine(CaptureScreenShoot());
        }
    }

    IEnumerator CaptureScreenShoot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D texture = ScreenCapture.CaptureScreenshotAsTexture();

        ShareSheet(texture);

        Object.Destroy(texture);

    }

    private void ShareSheet(Texture2D texture)
    {
        ShareSheet _shareSheet = new ShareSheet();

        _shareSheet.Text = "Check this game out!";
        _shareSheet.AttachImage(texture);
        _shareSheet.URL = "https://upwork.com";

        NPBinding.Sharing.ShowView(_shareSheet, FinishSharing);
    }

    private void FinishSharing(eShareResult _result)
    {
        Debug.Log(_result);
    }
}