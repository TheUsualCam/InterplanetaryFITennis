#if UNITY_2017_3_OR_NEWER
using System;
using System.IO;
using System.Text;

using UnityEngine;


namespace UniGLTF
{
#if USE_UNIGLTF_SCRIPTEDIMPORTER
    [ScriptedImporter(1, "gltf")]
#endif
    public class gltfScriptedImporter : UnityEditor.AssetImporters.ScriptedImporter
    {
        public override void OnImportAsset(UnityEditor.AssetImporters.AssetImportContext ctx)
        {
            Debug.LogFormat("## Importer ##: {0}", ctx.assetPath);

            var json = File.ReadAllText(ctx.assetPath, Encoding.UTF8);

            gltfImporter.Import(new ScriptedImporterContext(ctx), json, new ArraySegment<byte>());
        }
    }
}
#endif