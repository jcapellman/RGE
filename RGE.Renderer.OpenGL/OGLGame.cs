using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using RGE.Lib.Objects.Config;

namespace RGE.Renderer.OpenGL
{
    public class OGLGame : GameWindow
    {
        public OGLGame(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        public OGLGame(Configuration config) : base(GameWindowSettings.Default, new NativeWindowSettings()
        {
            Size = (config.vid_xres, config.vid_yres), WindowState = config.vid_fullscreen ? WindowState.Fullscreen : WindowState.Normal, Title = "RGE",
        })
        {

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
    }
}