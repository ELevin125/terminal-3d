using Terminal_3D.SceneManagement;
using Terminal_3D.Rendering;

namespace Terminal_3D.Core
{
    public class Engine
    {
        private Scene CurrentScene;
        private Renderer Renderer;
        public Engine(int width, int height, float charWidth, float charHeight)
        {
            CurrentScene = new Scene();
            Renderer = new Renderer(width, height, charWidth, charHeight, CurrentScene);
            Renderer.RenderFrame();
        }
    }
}
