namespace DataCall.Core;

/// <summary>
/// Describes a named collection of files and the metadata needed to identify them.
/// </summary>
public sealed record Manifest(
    string Name,
    string Version,
    DateTimeOffset CreatedAtUtc,
    IReadOnlyList<ManifestFile> Files);

/// <summary>
/// Describes one file contained in a <see cref="Manifest"/>.
/// </summary>
public sealed record ManifestFile(
    string RelativePath,
    long Length,
    DateTimeOffset LastWriteTimeUtc,
    ManifestFileHash Hash,
    string? ContentType = null);

/// <summary>
/// Identifies a file's content using a specific hash algorithm and encoded digest.
/// </summary>
public sealed record ManifestFileHash(
    string Algorithm,
    string Digest);
