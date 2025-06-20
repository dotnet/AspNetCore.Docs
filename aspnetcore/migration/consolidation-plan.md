# ASP.NET Framework to ASP.NET Core Migration Documentation Consolidation Plan

## Current Issues

### 1. Fragmented Structure
- Incremental migration approach is isolated in `/inc` folder
- Main migration docs in `/proper-to-2x` don't integrate well with incremental approach
- Version-specific upgrades (50-to-60, 60-70, etc.) mixed with Framework→Core migration

### 2. Inconsistent Entry Points
- `mvc.md` - MVC/Web API migration
- `web_forms.md` - Web Forms migration  
- `proper-to-2x/index.md` - General Framework→Core migration
- `inc/overview.md` - Incremental migration overview

### 3. Duplicated Content
- Setup steps repeated across multiple files
- Similar guidance in different locations
- Inconsistent cross-references

## Proposed Consolidated Structure

### 1. Main Migration Hub (`migration/index.md`)
Create a central hub that:
- Presents migration options upfront (incremental vs. full rewrite)
- Provides decision tree for choosing approach
- Links to appropriate detailed guides

### 2. Restructured Content Organization

```
migration/
├── index.md                           # Main migration hub
├── getting-started/
│   ├── planning.md                   # Migration planning guide
│   ├── assessment.md                 # App assessment checklist
│   └── choosing-approach.md          # Incremental vs. full migration
├── incremental/
│   ├── overview.md                   # Incremental migration overview
│   ├── setup.md                      # Initial setup (YARP + adapters)
│   ├── mvc-webapi.md                # MVC/Web API specific guidance
│   ├── web-forms.md                 # Web Forms specific guidance
│   ├── session-state.md             # Session migration
│   ├── authentication.md            # Auth migration
│   ├── http-modules.md              # HTTP modules migration
│   └── testing.md                   # A/B testing during migration
├── full-migration/
│   ├── mvc-webapi.md                # Complete MVC/Web API rewrite
│   ├── web-forms.md                 # Complete Web Forms rewrite
│   ├── configuration.md             # Configuration migration
│   ├── identity.md                  # Identity migration
│   └── http-modules.md              # HTTP modules to middleware
├── version-upgrades/                # Keep version-specific upgrades separate
│   ├── 50-to-60.md
│   ├── 60-to-70.md
│   └── ...
└── reference/
    ├── breaking-changes.md
    ├── compatibility.md
    └── troubleshooting.md
```

### 3. Content Integration Strategy

#### A. Main Migration Hub
- **Migration Decision Tree**: Help users choose between incremental and full migration
- **Clear Callouts**: When incremental approach is recommended
- **Technology Matrix**: Support for different ASP.NET Framework technologies

#### B. Incremental Migration Integration
- **Unified Starting Point**: Single entry point for incremental migration
- **Technology-Specific Branches**: Separate paths for MVC/Web API vs Web Forms
- **Progressive Disclosure**: Step-by-step guidance with clear checkpoints

#### C. Cross-Referencing Strategy
- **Consistent Callouts**: Clear indicators when incremental approach can help
- **Related Content**: Links between full migration and incremental options
- **Success Stories**: Examples of when each approach works best

## Implementation Plan

### Phase 1: Create Main Hub
1. Create `migration/index.md` with decision tree
2. Add migration planning documentation
3. Consolidate getting-started guidance

### Phase 2: Restructure Incremental Content
1. Move `/inc` content to `/incremental`
2. Integrate with technology-specific guides
3. Add clear callouts for when to use incremental approach

### Phase 3: Reorganize Full Migration Content
1. Consolidate similar content across files
2. Remove duplication
3. Add cross-references to incremental options

### Phase 4: Update Cross-References
1. Update all internal links
2. Add consistent callouts
3. Update navigation structure

## Key Callout Strategies

### When to Recommend Incremental Migration
- **Large/Complex Applications**: Apps with extensive business logic
- **Production Constraints**: Cannot afford extended downtime
- **Gradual Team Transition**: Teams learning ASP.NET Core
- **Risk Mitigation**: Reduces migration risk through gradual approach

### Strategic Callout Placement
- **Planning Phase**: Mention incremental as option during assessment
- **Technology Guides**: Specific callouts for MVC/Web API/Web Forms
- **Complex Scenarios**: Authentication, session state, custom modules
- **Performance Considerations**: When incremental approach helps

## Success Metrics
- Reduced documentation redundancy
- Clearer migration path selection
- Better integration between approaches
- Improved user journey through migration process
