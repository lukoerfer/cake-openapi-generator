namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MavenPackage
    {
        /// <summary>
        /// 
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Artifact { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="artifact"></param>
        /// <param name="version"></param>
        public MavenPackage(string group, string artifact, string version = null)
        {
            Group = group;
            Artifact = artifact;
            Version = version;
        }
    }
}
