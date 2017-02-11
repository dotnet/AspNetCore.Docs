@* This Twitter helper is compatible with version 1.1 of the Twitter API. *@

@using System.Globalization

@* For more about the twitter follow button, please visit
   https://dev.twitter.com/docs/follow-button *@
@helper FollowButton(
            string userName,
            bool showCount = false,
            bool showUserName = true,
            bool largeButton = false,
            bool optOutOfTailoring = false,
            string language = "",
            bool alignLeft = true)
{
    var showCountAttribute = new HtmlString(showCount ? "" : "data-show-count=\"false\"");
    var showUserNameAttribute = new HtmlString(showUserName ? "" : "data-show-screen-name=\"false\"");
    var largeButtonAttribute = new HtmlString(largeButton ? "data-size=\"large\"" : "");
    var optOutOfTailoringAttribute = new HtmlString(optOutOfTailoring ? "data-dnt=\"true\"" : "");
    var languageAttribute = new HtmlString(!language.IsEmpty() && !language.Equals("en", StringComparison.OrdinalIgnoreCase) ? String.Format(CultureInfo.InvariantCulture, " data-lang=\"" + HttpUtility.HtmlAttributeEncode(language) + "\"") : "");
    var alignAttribute = new HtmlString(alignLeft ? "" : "data-align=\"right\"");
    <a href="https://twitter.com/@HttpUtility.UrlEncode(userName)" class="twitter-follow-button" @showCountAttribute @showUserNameAttribute @largeButtonAttribute @optOutOfTailoringAttribute @languageAttribute @alignAttribute>Follow @@@userName)</a>
    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
}

@* For more about the tweet button, please visit https://dev.twitter.com/docs/tweet-button *@
@helper TweetButton(string url = "",
            string tweetText = "",
            bool showCount = true,
            string via = "",
            string recommend = "",
            string hashtag = "",
            bool largeButton = false,
            bool optOutOfTailoring = false,
            string language = "")
{
    var urlAttribute = new HtmlString(url.IsEmpty() ? "" : String.Format(CultureInfo.InvariantCulture, " data-url=\"" + HttpUtility.HtmlAttributeEncode(url) + "\""));
    var tweetTextAttribute = new HtmlString(tweetText.IsEmpty() ? "" : "data-text=\"" + HttpUtility.HtmlAttributeEncode(tweetText) + "\"");
    var showCountAttribute = new HtmlString(showCount ? "" : "data-show-count=\"false\"");
    var viaAttribute = new HtmlString(via.IsEmpty() ? "" : "data-via=\"" + HttpUtility.HtmlAttributeEncode(via) + "\"");
    var recommendAttribute = new HtmlString(recommend.IsEmpty() ? "" : "data-related=\"" + HttpUtility.HtmlAttributeEncode(recommend) + "\"");
    var hashtagAttribute = new HtmlString(hashtag.IsEmpty() ? "" : "data-hashtags=\"" + HttpUtility.HtmlAttributeEncode(hashtag) + "\"");
    var largeButtonAttribute = new HtmlString(largeButton ? "data-size=\"large\"" : "");
    var optOutOfTailoringAttribute = new HtmlString(optOutOfTailoring ? "data-dnt=\"true\"" : "");
    var languageAttribute = new HtmlString(!language.IsEmpty() && !language.Equals("en", StringComparison.OrdinalIgnoreCase) ? String.Format(CultureInfo.InvariantCulture, " data-lang=\"{0}\"", HttpUtility.HtmlAttributeEncode(language)) : "");
    <a href="https://twitter.com/share" class="twitter-share-button" @urlAttribute @tweetTextAttribute @showCountAttribute @viaAttribute @recommendAttribute @hashtagAttribute @largeButtonAttribute @optOutOfTailoringAttribute @languageAttribute>Tweet</a>
    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
}

@helper TimeLine(string userName,
            string widgetId,
            string theme = "",
            string linkColor = "",
            string language = "",
            int? tweetLimit = null,
            string relatedUsers = "",
            string ariaPolite = "",
            int? width = null,
            int? height = null,
            string title = "Tweets")
{
    var themeAttribute = new HtmlString(theme.IsEmpty() ? "" : "data-theme=\"" + theme + "\"");
    var linkColorAttribute = new HtmlString(linkColor.IsEmpty() ? "" : "data-link-color=\"" + linkColor + "\"");
    var languageAttribute = new HtmlString(!language.IsEmpty() && !language.Equals("en", StringComparison.OrdinalIgnoreCase) ? String.Format(CultureInfo.InvariantCulture, " data-lang=\"{0}\"", HttpUtility.HtmlAttributeEncode(language)) : "");
    var relatedUsersAttribute = new HtmlString(relatedUsers.IsEmpty() ? "" : "data-related=\"" + relatedUsers + "\"");
    var ariaPoliteAttribute = new HtmlString(ariaPolite.IsEmpty() ? "" : "data-aria-polite=\"" + ariaPolite + "\"");
    <a class="twitter-timeline" href="https://twitter.com/@userName" width="@width.ToString()" height="@height.ToString()" data-widget-id="@HttpUtility.HtmlEncode(widgetId)" @themeAttribute @linkColorAttribute @languageAttribute data-tweet-limit="@tweetLimit.ToString()" @relatedUsersAttribute @ariaPoliteAttribute>@title</a>
    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + "://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } }(document, "script", "twitter-wjs");</script>
}

@helper Profile(string userName,
            string widgetId,
            string theme = "",
            string linkColor = "",
            string language = "",
            int? tweetLimit = null,
            string relatedUsers = "",
            string ariaPolite = "",
            int? width = null,
            int? height = null)
{
    @Twitter.TimeLine(userName, widgetId, theme, linkColor, language, tweetLimit, relatedUsers, ariaPolite, width, height, "Tweets by @" + HttpUtility.HtmlEncode(userName));
}

@helper Faves(string userName,
            string widgetId,
            string theme = "",
            string linkColor = "",
            string language = "",
            int? tweetLimit = null,
            string relatedUsers = "",
            string ariaPolite = "",
            int? width = null,
            int? height = null)
{
    @Twitter.TimeLine(userName + "/favorites", widgetId, theme, linkColor, language, tweetLimit, relatedUsers, ariaPolite, width, height, "Favorite Tweets by @" + HttpUtility.HtmlEncode(userName));
}

@helper List(string userName,
            string list,
            string widgetId,
            string theme = "",
            string linkColor = "",
            string language = "",
            int? tweetLimit = null,
            string relatedUsers = "",
            string ariaPolite = "",
            int? width = null,
            int? height = null)
{
    @Twitter.TimeLine(userName + "/" + list, widgetId, theme, linkColor, language, tweetLimit, relatedUsers, ariaPolite, width, height, "Tweets from @" + HttpUtility.HtmlEncode(userName) + "/" + HttpUtility.HtmlEncode(list));
}

@helper Search(string query,
            string widgetId,
            string theme = "",
            string linkColor = "",
            string language = "",
            int? tweetLimit = null,
            string relatedUsers = "",
            string ariaPolite = "",
            int? width = null,
            int? height = null)
{
    @Twitter.TimeLine("search?q=" + HttpUtility.UrlEncode(query), widgetId, theme, linkColor, language, tweetLimit, relatedUsers, ariaPolite, width, height, "Tweets about \"" + HttpUtility.HtmlEncode(query) + "\"");
}