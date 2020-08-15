namespace Cake.OpenApiGenerator.Maven
{
    /// <summary>
    /// Represents a Maven package descriptor
    /// </summary>
    public sealed class MavenCoordinates
    {
        /// <summary>
        /// Gets or sets the package group identifier
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the package artifact identifier
        /// </summary>
        public string ArtifactId { get; set; }

        /// <summary>
        /// Gets or sets the package version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Creates a new Maven package descriptor
        /// </summary>
        /// <param name="groupId">The package group identifier</param>
        /// <param name="artifactId">The package artifact identifier</param>
        /// <param name="version">The package version (optional)</param>
        public MavenCoordinates(string groupId, string artifactId, string version = null)
        {
            GroupId = groupId;
            ArtifactId = artifactId;
            Version = version;
        }
    }
}
