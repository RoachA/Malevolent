

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

internal class BlitPass : ScriptableRenderPass
{
    //ProfilingSampler m_ProfilingSampler = new ProfilingSampler("ColorBlit");
    ProfilingSampler m_ProfilingSampler = null;
    public Material m_Material;
    public RTHandle m_CameraTarget;

    /// <summary>
    /// BlitPass
    /// </summary>
    /// <param name="profilingSampler">name in profiler</param>
    /// <param name="material">material to use</param>
    /// <param name="_renderPassEvent">when to pass the render event</param>
    public BlitPass(string profilingSampler, Material material, RenderPassEvent? _renderPassEvent)
    {
        m_ProfilingSampler = new ProfilingSampler(profilingSampler);

        m_Material = material;

        if (_renderPassEvent == null)
        {
            renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        }
        else
        {
            renderPassEvent = (RenderPassEvent)_renderPassEvent;
        }
        
    }

    public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
    {
        ConfigureTarget(m_CameraTarget);
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        var cameraData = renderingData.cameraData;
        if (cameraData.camera.cameraType != CameraType.Game)
            return;

        if (m_Material == null)
            return;

        if (m_CameraTarget == null)
            return;

        CommandBuffer cmd = CommandBufferPool.Get();
        using (new ProfilingScope(cmd, m_ProfilingSampler))
        {
            Blit(cmd, m_CameraTarget, m_CameraTarget, m_Material, 0);
        }
        context.ExecuteCommandBuffer(cmd);
        cmd.Clear();

        CommandBufferPool.Release(cmd);
    }
}