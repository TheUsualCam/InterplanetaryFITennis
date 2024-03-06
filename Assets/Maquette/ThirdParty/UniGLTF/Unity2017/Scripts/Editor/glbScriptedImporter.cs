#if UNITY_2017_3_OR_NEWER
using System.IO;

using UnityEngine;


namespace UniGLTF
{
#if USE_UNIGLTF_SCRIPTEDIMPORTER
    [ScriptedImporter(1, "glb")]
#endif
    public class glbScriptedImporter: UnityEditor.AssetImporters.ScriptedImporter
    {
        public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
        {
            Debug.LogFormat("## glbImporter ##: {0}", ctx.assetPath);

            var bytes = File.ReadAllBytes(ctx.assetPath);

            glbImporter.Import(new ScriptedImporterContext(ctx), bytes);
        }
    }
}
#endif