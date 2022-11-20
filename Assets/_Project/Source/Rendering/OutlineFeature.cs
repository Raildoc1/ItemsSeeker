using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace ItemsSeeker.Rendering
{
    public class OutlineFeature : ScriptableRendererFeature
    {
        class RenderPass : ScriptableRenderPass
        {
            Material _material;
            RTHandle _tempTexture;
            RTHandle _sourceTexture;

            public RenderPass(Material material) : base()
            {
                _material = material;
            }

            public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
            {
                _sourceTexture = renderingData.cameraData.renderer.cameraColorTargetHandle;

                _tempTexture = RTHandles.Alloc(new RenderTargetIdentifier("_TempTexture"), "_TempTexture");
            }

            public override void OnCameraCleanup(CommandBuffer cmd)
            {
                base.OnCameraCleanup(cmd);

                _tempTexture.Release();
            }

            public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
            {
                CommandBuffer commandBuffer = CommandBufferPool.Get("Outline Feature");

                RenderTextureDescriptor targetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
                targetDescriptor.depthBufferBits = 0;
                commandBuffer.GetTemporaryRT(Shader.PropertyToID(_tempTexture.name), targetDescriptor, FilterMode.Bilinear);

                Blit(commandBuffer, _sourceTexture, _tempTexture, _material);
                Blit(commandBuffer, _tempTexture, _sourceTexture);

                context.ExecuteCommandBuffer(commandBuffer);
                CommandBufferPool.Release(commandBuffer);
            }
        }

        [SerializeField] Material _material;

        RenderPass _renderPass;

        public override void OnCameraPreCull(ScriptableRenderer renderer, in CameraData cameraData)
        {
            base.OnCameraPreCull(renderer, cameraData);
        }

        public override void Create()
        {
            _renderPass = new RenderPass(_material);
            _renderPass.renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(_renderPass);
        }
    }
}