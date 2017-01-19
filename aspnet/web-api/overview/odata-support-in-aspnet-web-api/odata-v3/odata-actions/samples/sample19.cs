checkoutAction.HasActionLink(ctx =>
{
    var movie = ctx.EntityInstance as Movie;
    if (movie.IsAvailable) {
        return new Uri(ctx.Url.ODataLink(
            new EntitySetPathSegment(ctx.EntitySet), 
            new KeyValuePathSegment(movie.ID.ToString()),
            new ActionPathSegment(checkoutAction.Name)));
    }
    else
    {
        return null;
    }
}, followsConventions: true);