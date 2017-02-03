' Programmatically add a <meta> element to the Header
Dim keywords As New HtmlMeta()
keywords.Name = "keywords"
keywords.Content = "master page,asp.net,tutorial"

Page.Header.Controls.Add(keywords)