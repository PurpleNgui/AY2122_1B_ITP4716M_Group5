using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoManager : MonoBehaviour
{
    [SerializeField]
    private VideoClip SkyboxVideo;

    private RenderTexture SkyboxRenderTexture;

    [SerializeField]
    private Material SkyboxMaterial;

    private VideoPlayer vp;

    [SerializeField]
    [RangeAttribute(0,1)]
    private float TargetMileStone;
    
    private float milestone = 0.5f;
    public float Milestone
    {
        set
        {
            milestone = value;

            vp.Pause();
            GoToMilestone(milestone);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        InitRenderTexture();

        InitVideoPlayer();

        InitMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        PlayOrPause();

        //Bad in performance
        //Rewind();

        UpdateMilestone();
    }

    public void InitRenderTexture()
    {
        SkyboxRenderTexture = new RenderTexture(2048, 2048, 24);
    }

    public void InitVideoPlayer()
    {
        vp = GetComponent<VideoPlayer>();

        vp.renderMode = VideoRenderMode.RenderTexture;
        vp.targetTexture = SkyboxRenderTexture;

        vp.clip = SkyboxVideo;

        vp.playOnAwake = false;
        vp.waitForFirstFrame = false;
        vp.skipOnDrop = false;
        vp.aspectRatio = VideoAspectRatio.Stretch;

        vp.Prepare();
        vp.isLooping = true;

        vp.frame = (long)vp.frameCount;
    }

    public void InitMaterial()
    {
        SkyboxMaterial.shader = Shader.Find("Skybox/Panoramic");
        SkyboxMaterial.SetFloat("_ImageType", 0);
        SkyboxMaterial.SetFloat("_Exposure", 1);
        SkyboxMaterial.SetTexture("_MainTex", SkyboxRenderTexture);

        RenderSettings.skybox = SkyboxMaterial;
    }

    public void PlayOrPause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (vp.isPlaying)
            {
                vp.Pause();
            }
            else
            {
                vp.Play();
            }
        }
    }

    public void UpdateMilestone()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Milestone = 0.25f;
            TargetMileStone = milestone;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Milestone = 0.5f;
            TargetMileStone = milestone;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Milestone = 0.75f;
            TargetMileStone = milestone;
        }

        if (TargetMileStone != milestone)
        {
            Milestone = TargetMileStone;
        }
    }

    private void GoToMilestone(float mileStone)
    {
        vp.frame = (int)(vp.frameCount * mileStone);
    }


    /* Bad in performance
    private bool bRewind = false;
    public bool BRewind 
    {
        get
        {
            return bRewind;
        }
        set
        {
            bRewind = value;
            //if(bRewind)
            //{
            //    vp.Pause();
            //}
        }
    }

    public void Rewind()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bRewind = !bRewind;
        }
        if (bRewind)
        {
            //vp.frame--;
            vp.time = vp.time - Time.deltaTime * FRewindSpeed;
        }
    }
    public float FRewindSpeed = 3;
    */
}
