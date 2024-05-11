using Terminal_3D.Geometry;
using Terminal_3D.Rendering;

namespace Terminal_3D.SceneManagement
{
    public class MainScene : Scene
    {
        public MainScene() : base() { }

        protected override Camera SetupMainCamera()
        {
            return new Camera(Vector3.Zero, Vector3.Zero);
        }

        protected override void InitializeScene()
        {
            AllMeshes.Add(PrimitiveMeshes.CreateCube(new Vector3(-50, 0, 400), new Vector3(200, 100, 200)));
            AllMeshes.Add(PrimitiveMeshes.CreateCube(new Vector3(-500, -100, 500), new Vector3(200, 200, 1000)));
            AllMeshes.Add(PrimitiveMeshes.CreateCube(new Vector3(1000, -100, 2000), new Vector3(200, 200, 200)));
        }
    }
}
