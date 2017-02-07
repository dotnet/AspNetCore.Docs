// Programmatically add a <meta> element to the Header
HtmlMeta keywords = new HtmlMeta();
keywords.Name = "keywords";
keywords.Content = "master page,asp.net,tutorial";

Page.Header.Controls.Add(keywords);