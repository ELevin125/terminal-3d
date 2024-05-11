using Terminal_3D.SceneManagement;
using Terminal_3D.Rendering;

namespace Terminal_3D.Core
{
    public class Engine
    {
        private readonly Scene CurrentScene;
        private readonly Renderer Renderer;
        public Engine(int width, int height, float charWidth, float charHeight)
        {
            CurrentScene = new MainScene();
            Renderer = new Renderer(width, height, charWidth, charHeight, CurrentScene);
        }

        public void Update()
        {
            InputManager.Instance.Listen();
            Renderer.RenderFrame();

            Thread.Sleep(1000 / 100);
        }
    }
}
