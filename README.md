# Data Pipeline

## Purpose

Offer tools to use for use in data pipelines, specializing in the work that happens before data is imported into a database.

## Planned features

- directory crawling
- file moving and organization
- manifest creation
    - file list
    - file metadata
- manifest reading/writing
    - json
    - xlsx
- data file reading/writing
    - csv
    - tsv
    - xlsx
    - json
- file hash calculation
- file hash comparison
- data file metadata creation
    - row count
    - column count
    - numeric column totals
- database connectivity
    - SQL Server
    - DuckDB
- filename normalization
- json serialization
- data file identification
    - by filename
    - by xlsx structure
    - by csv or tsv structure
    - by json schea
- logging
    - to text files
    - to database tables

## Manifest model

A manifest identifies a named set of files. Each file uses a repository-relative
path so the manifest remains portable between machines, plus its length, UTC
last-write time, optional content type, and a hash with its algorithm explicitly
specified.

```csharp
using DataCall.Core;

var manifest = new Manifest(
    Name: "daily-import",
    Version: "1",
    CreatedAtUtc: DateTimeOffset.UtcNow,
    Files:
    [
        new ManifestFile(
            RelativePath: "incoming/customers.csv",
            Length: 42_108,
            LastWriteTimeUtc: new DateTimeOffset(2026, 10, 15, 0, 0, 0, TimeSpan.Zero),
            Hash: new ManifestFileHash("SHA-256", "a1b2c3d4..."),
            ContentType: "text/csv")
    ]);
```