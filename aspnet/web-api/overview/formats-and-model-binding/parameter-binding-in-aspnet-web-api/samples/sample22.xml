public abstract class ETagMatchAttribute : ParameterBindingAttribute
{
    private ETagMatch _match;

    public ETagMatchAttribute(ETagMatch match)
    {
        _match = match;
    }

    public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
    {
        if (parameter.ParameterType == typeof(ETag))
        {
            return new ETagParameterBinding(parameter, _match);
        }
        return parameter.BindAsError("Wrong parameter type");
    }
}

public class IfMatchAttribute : ETagMatchAttribute
{
    public IfMatchAttribute()
        : base(ETagMatch.IfMatch)
    {
    }
}

public class IfNoneMatchAttribute : ETagMatchAttribute
{
    public IfNoneMatchAttribute()
        : base(ETagMatch.IfNoneMatch)
    {
    }
}