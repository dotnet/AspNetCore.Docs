---
name: archive-out-of-support-content
description: >
  Archive out-of-support ASP.NET Core documentation and samples from this repository
  into the separate archive repository in coherent batches. Use when asked to
  archive unsupported .NET content, select the next legacy documentation chunk,
  remove obsolete versioned sections, or clean up navigation after archiving.
  Covers copy-before-delete preservation, supported-version dependencies,
  archive index and TOC updates, redirects, and validation. Excludes release notes.
---

# Archive out-of-support content

This repository publishes ASP.NET Core guidance and samples. Archive obsolete
guidance into the separate previous-versions repository while keeping supported
guidance complete and usable here. Archiving means **copying and verifying the
content in the archive**, not just deleting it from this repository.

## Defaults and scope

* The previous requests target .NET 9 and earlier. Use that cutoff unless the
  current request specifies another one; don't silently expand it as time passes.
* Select one coherent chunk of roughly **500-1,500 removed files**, unless the
  user specifies another size or requests specific sections. Prefer a self-contained
  topic or tutorial over unrelated files selected only to reach the count.
* The default archive content folder from those requests is
  `\aspnet-docs-archive-pr\aspnet-core`. Verify that it exists
  and inspect its repository instructions and worktree before changing it. If
  unavailable, obtain the destination from the user; don't delete source content
  or silently substitute another archive.
* **Don't archive release notes**, including files under `aspnetcore\release-notes`.
* Preserve existing work in both repositories. Don't commit, push, or open a PR
  unless requested.

Relevant paths:

* `aspnetcore`: active articles, includes, samples, and images.
* `aspnetcore\toc.yml`: active navigation.
* `.openpublishing.redirection.json`: redirects for removed or renamed articles.
* Archive `aspnet-core\index.yml` and `aspnet-core\toc.yml`: archive landing page
  and navigation.

Use Windows paths for local filesystem operations. Link destinations and
`source_path` values in publishing configuration still use forward slashes.

## Inspect and select a chunk

1. Inspect both worktrees and record the source commit and pre-existing changes.
   Keep temporary manifests and validation scripts outside tracked content.
1. Review relevant earlier archiving PRs for established patterns, including
   `dotnet/AspNetCore.Docs#38044`, `dotnet/AspNetCore.Docs#38114`,
   `dotnet/AspNetCore.Docs#38116`, `dotnet/AspNetCore.Docs#38128`, and
   `dotnet/AspNetCore.Docs#38179`. Follow the current request and the rules below
   over older examples that retained obsolete referrals.
1. Identify candidate articles, versioned sections, includes, samples, and assets.
   Inspect moniker ranges, include chains, snippet references, project targets,
   and surrounding prose. A legacy folder name or target framework alone doesn't
   prove its content is unused by supported documentation.
1. Trace incoming links and all dependencies, including images, tabbed includes,
   snippet regions, shared project files, and references outside the selected
   directory or repository.
1. State the selected topic, expected removal count, and supported content that
   will remain. Stay within the requested scope; don't pad the batch with
   unrelated deletions.

## Preserve the archive before removing content

1. Copy the original articles and every required include, sample, and asset,
   preserving paths relative to `aspnetcore` beneath the archive's `aspnet-core`.
   For mixed-version articles, preserve the original unsupported guidance and
   its dependencies before editing the active article.
1. Compare copied files with the source using hashes or byte comparisons before
   deleting them. If an archive file already exists, verify it contains the
   content being removed. Merge missing material without overwriting earlier
   archived versions or unrelated edits. Never assume that an existing filename
   means preservation is complete.
1. Preserve local uncommitted content as well as committed originals. A copy from
   `HEAD` alone is insufficient if the removed worktree content differs.
1. Make archived content self-contained. Copy external snippet dependencies
   when needed and adjust references to resolve in the archive. Fix relative
   links and includes affected by the new root.
1. Pin source/download links that would otherwise point to deleted files on the
   active branch to the recorded source commit. Don't pin to a commit that lacks
   the referenced content.
1. For intentional archive-only link or metadata changes, verify preservation
   before those edits and account for the resulting differences explicitly.

## Remove obsolete content and retain supported guidance

1. Delete only the files and sections whose archive preservation is verified.
   Inspect **every** versioned block in the selected articles, not just the oldest
   include: later unsupported sections can remain after an initial cleanup.
1. In mixed-version articles, remove unsupported-only prose, tabs, includes, and
   moniker blocks. Simplify wrappers made redundant by the removal, but preserve
   distinctions between retained versions and balanced moniker/tab syntax.
1. Keep supported and shared guidance, snippets, images, and samples. If supported
   guidance uses a legacy sample, retain the dependency or migrate the smallest
   necessary sample to the supported version specified by the task and repository
   conventions. Update directly dependent references and validate its behavior.
1. Remove unsupported-only referrals and surrounding obsolete prose instead of
   merely replacing their links with `/previous-versions/aspnet/core` URLs.
   Keep and repair a link only when it still serves supported guidance; prefer
   an appropriate supported replacement.
1. Remove active TOC entries for fully archived articles or sections, including
   empty parent nodes. **Don't leave archive-only TOC nodes pointing at the
   previous-versions site.** Keep navigation for articles that still contain
   supported guidance.
1. Add a redirect for every deleted or renamed published Markdown article, not
   for includes, samples, or removed sections in an article whose URL survives.
   Use the verified archive URL, normally
   `/previous-versions/aspnet/core/<article path>`, without the `.md` extension.
   Don't set `redirect_document_id` (it defaults to `false`), avoid duplicate `source_path` entries, and keep entries alphabetically ordered. Redirects preserve old inbound URLs;
   they aren't a reason to retain obsolete content in active navigation.

## Update archive discovery

* Add the archived topics to `aspnet-core\toc.yml`, merging entries into existing
  category or tutorial nodes where applicable. Don't create duplicate categories,
  articles, or parallel nodes for the same topic.
* Update `aspnet-core\index.yml` when the chunk adds a discoverable topic. Reuse
  existing landing-page groups and avoid duplicate links.
* Use archive-relative article links and verify that every added destination
  exists. Preserve the archive's metadata and formatting conventions.

## Verify and finish

* Verify that every removed file or section is present in the archive, including
  dependencies. Report actual removed-file counts separately from copied files
  and edited articles; section removals aren't file removals.
* Compare retained supported-version content with the pre-edit source, resolving
  includes for each retained moniker. Investigate any difference beyond the
  intended cleanup or sample migration.
* Check affected active and archive links, includes, images, snippet paths and
  region names, moniker/tab balance, TOCs, landing-page YAML, and redirect JSON.
  Check incoming references outside the selected directory as well.
* Confirm release notes and unrelated work are unchanged.
* Run `git diff --check` in both repositories and inspect both final diffs,
  including newly added files. Run existing relevant documentation checks or
  linters when available; distinguish new findings from baseline issues.
* If a sample changed, run its targeted build/tests and verify the documented
  behavior, using HTTP checks where appropriate. Don't try to modernize archived
  samples or build every unsupported sample.
* If a PR was requested, follow the repository PR template and monitor publishing
  checks. Resolve introduced OpenPublishing.Build warnings. Never claim hosted
  checks ran when only local checks were available.
* Summarize the archived topic, removal count, destination, retained supported
  content, navigation/redirect changes, validation results, and commit status of
  both repositories. State any blocked or unrun checks plainly.
