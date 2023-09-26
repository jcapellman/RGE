using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace RGE.Renderer.OpenGL
{
    public class OGLGame : GameWindow
    {
        public OGLGame(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        public OGLGame(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
    }
}
