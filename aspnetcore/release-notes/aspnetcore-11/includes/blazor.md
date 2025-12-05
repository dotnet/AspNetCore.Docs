### New `DisplayName` component and support for `[Display]` and `[DisplayName]` attributes

The <xref:Microsoft.AspNetCore.Components.Forms.DisplayName%601> component can be used to display property names from metadata attributes:

```csharp
[Required, DisplayName("Production Date")]
public DateTime ProductionDate { get; set; }
```

The [`[Display]` attribute](xref:System.ComponentModel.DataAnnotations.DisplayAttribute) on the model class property is supported:

```csharp
[Required, Display(Name = "Production Date")]
public DateTime ProductionDate { get; set; }
```

Between the two approaches, the `[Display]` attribute is recommended, which makes additional properties available. The `[Display]` attribute also enables assigning a resource type for localization. When both attributes are present, `[Display]` takes precedence over `[DisplayName]`. If neither attribute is present, the component falls back to the property name.

Use the `DisplayName` component in labels or table headers:

```razor
<label>
    <DisplayName For="@(() => Model!.ProductionDate)" />
    <InputDate @bind-Value="Model!.ProductionDate" />
</label>
```

### Blazor script () startup options format now used for Blazor Server and Blazor WebAssembly scripts

The Blazor Web App script (`blazor.web.js`) options object passed to `Blazor.start()` uses the following format since the release of .NET 8:

```javascript
Blazor.start({
  ssr: { ... },
  circuit: { ... },
  webAssembly: { ... },
});
```

Now, Blazor Server (`blazor.server.js`) and Blazor WebAssembly (`blazor.webassembly.js`) scripts can use the same options format.

The following example shows the prior options format, which remains supported:

```javascript
Blazor.start({
  loadBootResource: function (...) {
      ...
    },
  });
```

The newly supported options format for the preceding example:

```javascript
Blazor.start({
  webAssembly: {
    loadBootResource: function (...) {
      ...
    },
  },
});
```

For more information, see <xref:blazor/fundamentals/startup#startup-process-and-configuration>.
